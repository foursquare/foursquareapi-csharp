//-----------------------------------------------------------------------
// <copyright file="FoursquareRequest.cs" company="Foursquare Labs Inc.">
//     Copyright (c) Kyle Fowler, Foursquare Labs Inc.. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Foursquare.Model;
using Newtonsoft.Json;

using System.Diagnostics;
using System.IO;
using System.Threading;
using Foursquare.Response;

namespace Foursquare.Api
{
    public class FoursquareRequest
    {
        public enum HttpMethod
        {
            GET,
            POST,
            PHOTO_POST
        }

        public FoursquareRequest(string url, HttpMethod method = HttpMethod.GET)
        {
            Url = url;
            Method = method;
            Params = new Dictionary<string, string>();

            if (_client == null)
            {
                SetupClient();
            }
        }

        public string Url { get; set; }
        public HttpMethod Method { get; set; }
        public Stream File { get; set; }
        private Dictionary<string, string> Params { get; set; }
        private List<FoursquareRequest> SubRequests { get; set; }

        private CancellationTokenSource _cancellationToken = new CancellationTokenSource();

        public void AddParam(string key, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                if (HasParam(key))
                {
                    Params[key] = value;
                }
                else
                {
                    Params.Add(key, value);
                }

            }
        }

        public void AddParamIf(string key, bool value)
        {
            if (value)
            {
                AddParam(key, "true");
            }
        }

        public bool HasParam(string key)
        {
            return !string.IsNullOrEmpty(key) && Params.ContainsKey(key);
        }

        public void AddSubRequest(FoursquareRequest request)
        {
            SubRequests = SubRequests ?? new List<FoursquareRequest>();
            SubRequests.Add(request);
        }

        public string GetFullUrl()
        {
            StringBuilder fullUrl = new StringBuilder(Url);
            if (!Url.EndsWith("?"))
            {
                fullUrl.Append("?");
            }
            foreach(var param in Params) {
                fullUrl.Append(string.Format("{0}={1}",param.Key, Uri.EscapeDataString(param.Value)));
                fullUrl.Append("&");
            }
            if (SubRequests != null)
            {
                List<string> requestUris = new List<string>();
                foreach (var request in SubRequests)
                {
                    requestUris.Add(Uri.EscapeDataString(request.GetFullUrl()));
                }
                fullUrl.Append(string.Format("{0}={1}", "requests", string.Join(",", requestUris)));
            }
            return fullUrl.ToString();
        }

        private HttpContent GetPostContent()
        {
            var data = new List<KeyValuePair<string, string>>();
            foreach (var param in Params)
            {
                data.Add(new KeyValuePair<string, string>(param.Key, param.Value));
            }

            HttpContent content = new FormUrlEncodedContent(data);
            return content;
        }

        public async Task<FoursquareResponse<T>> MakeRequest<T>(CancellationToken? cancellationToken = null) where T : IFoursquareType
        {
            try
            {
                if (cancellationToken == null)
                {
                    cancellationToken = _cancellationToken.Token;
                }

                string respString = string.Empty;
                FoursquareResponse<T> parsedResponse = null;
                HttpResponseMessage responseMessage = null;
                switch (Method)
                {
                    case HttpMethod.GET:
                        Debug.WriteLine(GetFullUrl());
                        responseMessage = await GetClient().GetAsync(GetFullUrl(), cancellationToken.Value).ConfigureAwait(false);
                        break;
                    case HttpMethod.POST:
                        Debug.WriteLine(GetFullUrl());
                        responseMessage = await GetClient().PostAsync(Url, GetPostContent(), cancellationToken.Value).ConfigureAwait(false);
                        break;
                    case HttpMethod.PHOTO_POST:
                        MultipartFormDataContent content = new MultipartFormDataContent();
                        StreamContent baContent = new StreamContent(File);
                        baContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/jpeg");
                        content.Add(baContent, "image", "image.jpeg");
                        responseMessage = await GetClient().PostAsync(GetFullUrl(), content, cancellationToken.Value).ConfigureAwait(false);
                        break;
                    default:
                        throw new Exception("Unsupported HttpMethod type");
                }
                HandleHttpResponseMessage(responseMessage);
                respString = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
                if (!string.IsNullOrEmpty(respString))
                {
                    parsedResponse = JsonConvert.DeserializeObject<FoursquareResponse<T>>(respString, new FoursquareResponseConverter<T>());
                }
                else
                {
                    throw new FoursquareNetworkException(FoursquareNetworkException.NetworkError.NoData);
                }
                ProcessNotifications(parsedResponse);
                return parsedResponse;
            }
            catch (Exception e)
            {
                Debug.WriteLine("Network exception: " + e.Message);
                var response = new FoursquareResponse<T>
                {
                    Exception = e
                };
                return response;
            }
            
        }

        public async Task<TwoResponses<T, V>> MakeRequest<T, V>(CancellationToken? cancellationToken = null)
            where T : IFoursquareType
            where V : IFoursquareType
        {
            try
            {
                if (cancellationToken == null)
                {
                    cancellationToken = _cancellationToken.Token;
                }
                switch (Method)
                {
                    case HttpMethod.GET:
                        string resp = await MakeGetRequest(cancellationToken);
                        var twoParsedResponse = JsonConvert.DeserializeObject<TwoResponses<T, V>>(resp, new FoursquareTwoResponseConverter<T, V>());
                        ProcessMultiNotifications(twoParsedResponse);
                        return twoParsedResponse;
                    default:
                        throw new Exception("Unsupported HttpMethod type");
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Network exception: " + e.Message);
                var response = new TwoResponses<T,V>
                {
                    Exception = e
                };
                return response;
            }
        }

        public async Task<ThreeResponses<T, V, C>> MakeRequest<T, V, C>(CancellationToken? cancellationToken = null)
            where T : IFoursquareType
            where V : IFoursquareType
            where C : IFoursquareType
        {
            try
            {
                if (cancellationToken == null)
                {
                    cancellationToken = _cancellationToken.Token;
                }
                switch (Method)
                {
                    case HttpMethod.GET:
                        string resp = await MakeGetRequest(cancellationToken);
                        var twoParsedResponse = JsonConvert.DeserializeObject<ThreeResponses<T, V, C>>(resp, new FoursquareThreeResponseConverter<T, V, C>());
                        ProcessMultiNotifications(twoParsedResponse);
                        return twoParsedResponse;
                    default:
                        throw new Exception("Unsupported HttpMethod type");
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Network exception: " + e.Message);
                var response = new ThreeResponses<T, V, C>
                {
                    Exception = e
                };
                return response;
            }
        }

        public async Task<FourResponses<T, V, C, D>> MakeRequest<T, V, C, D>(CancellationToken? cancellationToken = null)
            where T : IFoursquareType
            where V : IFoursquareType
            where C : IFoursquareType
            where D : IFoursquareType
        {
            try
            {
                if (cancellationToken == null)
                {
                    cancellationToken = _cancellationToken.Token;
                }
                switch (Method)
                {
                    case HttpMethod.GET:
                        string resp = await MakeGetRequest(cancellationToken);
                        var fourParsedResponse = JsonConvert.DeserializeObject<FourResponses<T, V, C, D>>(resp, new FoursquareFourResponseConverter<T, V, C, D>());
                        ProcessMultiNotifications(fourParsedResponse);
                        return fourParsedResponse;
                    default:
                        throw new Exception("Unsupported HttpMethod type");
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Network exception: " + e.Message);
                var response = new FourResponses<T, V, C, D>
                {
                    Exception = e
                };
                return response;
            }
        }

        public async Task<FiveResponses<T, V, C, D, E>> MakeRequest<T, V, C, D, E>(CancellationToken? cancellationToken = null)
            where T : IFoursquareType
            where V : IFoursquareType
            where C : IFoursquareType
            where D : IFoursquareType
            where E: IFoursquareType
        {
            try
            {
                if (cancellationToken == null)
                {
                    cancellationToken = _cancellationToken.Token;
                }
                switch (Method)
                {
                    case HttpMethod.GET:
                        string resp = await MakeGetRequest(cancellationToken);
                        var fiveParsedResponse = JsonConvert.DeserializeObject<FiveResponses<T, V, C, D, E>>(resp, new FoursquareFiveResponseConverter<T, V, C, D, E>());
                        ProcessMultiNotifications(fiveParsedResponse);
                        return fiveParsedResponse;
                    default:
                        throw new Exception("Unsupported HttpMethod type");
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Network exception: " + e.Message);
                var response = new FiveResponses<T, V, C, D, E>
                {
                    Exception = e
                };
                return response;
            }
        }

        private async Task<string> MakeGetRequest(CancellationToken? cancellationToken = null)
        {
            HttpResponseMessage msg = await GetClient().GetAsync(GetFullUrl(), cancellationToken.Value).ConfigureAwait(false);
            string resp = await msg.Content.ReadAsStringAsync();
            if (string.IsNullOrEmpty(resp))
            {
                throw new FoursquareNetworkException(FoursquareNetworkException.NetworkError.NoData);
            }
            return resp;
        }

        private static HttpClient _client;
        private static HttpClientHandler _compression;
        private static void SetupClient()
        {
            _compression = new HttpClientHandler();
            _client = new HttpClient(_compression);
            _client.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Language", FoursquareApi.UserLanguage);
            //_client.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", AppHelper.GetDeviceIdentifier());
            //_client.DefaultRequestHeaders.TryAddWithoutValidation(ConsumerConstants.CONSUMER_HEADER, AppHelper.GetAppConsumerHeader().ToString(CultureInfo.InvariantCulture));
            if (_compression.SupportsAutomaticDecompression)
            {
                _compression.AutomaticDecompression = System.Net.DecompressionMethods.Deflate | System.Net.DecompressionMethods.GZip;
                _client.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Encoding", "gzip, deflate");
            }
        }

        private static HttpClient GetClient()
        {
            return _client;
        }

        private void HandleHttpResponseMessage(HttpResponseMessage msg)
        {
            if (msg == null) return;
        }

        private void ProcessNotifications<T>(FoursquareResponse<T> response)
            where T : IFoursquareType
        {
            if (response == null || response.notifications == null)
            {
                return;
            }

            foreach (var notif in response.notifications)
            {
                if (notif.type == "pendingFriendRequests")
                {
                }
                else if (notif.type == "notificationTray")
                {
                }
                else if (notif.type == "plans")
                {
                }
            }
        }

        private void ProcessMultiNotifications<T,V>(TwoResponses<T, V> response)
            where T : IFoursquareType
            where V : IFoursquareType
        {
            if (response == null || response.notifications == null)
            {
                return;
            }

            foreach (var notif in response.notifications)
            {
                if (notif.type == "pendingFriendRequests")
                {
                }
                else if (notif.type == "notificationTray")
                {
                }
                else if (notif.type == "plans")
                {
                }
            }
        }

        public sealed class FoursquareNetworkException : Exception
        {
            public enum NetworkError
            {
                NoData
            }

            public NetworkError ErrorType;

            public FoursquareNetworkException(NetworkError error = NetworkError.NoData, string message = "")
                : base(message)
            {

            }
        }
    }
}
