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
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Foursquare.Model;
using Page = Windows.UI.Xaml.Controls.Page;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace FoursquareApi_Sample
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private FoursquareApi foursquareApi;

        public MainPage()
        {
            this.InitializeComponent();

            foursquareApi = new FoursquareApi("CQ0WNZJ0DW00UQVVFKJVT3ZZTTLEOP3PQVUGXS1LORUB32KI", "R1EBBOSUB4AEEBWWZYTIJR45JX50CTIOFO12JLPCF04HMINZ");
        }

        private async void button_Click(object sender, RoutedEventArgs e)
        {
            var venues = await foursquareApi.SearchVenues(new Foursquare.Model.FoursquareLocation(25.767368, -80.18930));
            listView.ItemsSource = venues.response.venues;
        }

        private async void ListView_OnItemClick(object sender, ItemClickEventArgs e)
        {
            var venue = (e.ClickedItem as Venue).id;
            var result = await foursquareApi.VenueDetails(venue);
            if (result?.response != null)
            {
                Debug.WriteLine("Success");
            }
        }
    }
}
