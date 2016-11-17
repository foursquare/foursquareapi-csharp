using Foursquare.Api;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Devices.Geolocation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Foursquare.Model;
using Page = Windows.UI.Xaml.Controls.Page;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Popups;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MrJitters.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Geolocator locations = new Geolocator();

        public MainPage()
        {
            this.InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            Shaker.RepeatBehavior = RepeatBehavior.Forever;
            Shaker.Begin();

            var status = await Geolocator.RequestAccessAsync();
            if (status == GeolocationAccessStatus.Denied)
            {
                // You should give me a location
            } else
            {
                // Got it
                locations.DesiredAccuracy = PositionAccuracy.Default;
                locations.DesiredAccuracyInMeters = 1000;

                await FetchNearbyCoffee();
            }
        }

        public static FoursquareLocation FoursquareLocationFromGeoposition(Geoposition pos)
        {
            var foursq = new FoursquareLocation();
            foursq.Accuracy = pos.Coordinate.Accuracy;
            foursq.Lat = pos.Coordinate.Point.Position.Latitude;
            foursq.Lng = pos.Coordinate.Point.Position.Longitude;
            foursq.Speed = pos.Coordinate.Speed.GetValueOrDefault(0.0);
            return foursq;
        }

        private async void ListView_OnItemClick(object sender, ItemClickEventArgs e)
        {
            var venue = (e.ClickedItem as Venue).id;
            var result = await App.API.VenueDetails(venue);
            if (result?.response != null)
            {
                var dialog = new MessageDialog(result.response.venue.name);
                await dialog.ShowAsync();
            }
        }

        private async Task FetchNearbyCoffee()
        {
            var location = await locations.GetGeopositionAsync();
            if (location == null)
            {
                // Error
                return;
            }

            SearchRecommendationFilters f = new SearchRecommendationFilters();
            f.intent = new SearchRecommendationIntent { id = "coffee" };

            var venues = await App.API.SearchRecommendations(f, location: FoursquareLocationFromGeoposition(location));
            if (venues.response != null)
            {
                VenueList.ItemsSource = venues.response.group.results.Select(r => r.venue);
            }

            Sticker.Visibility = Visibility.Collapsed;
            Shaker.Stop();
        }
    }
}
