using Plugin.ExternalMaps;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using XamarinForms.ViewModels;
using Plugin.ExternalMaps.Abstractions;
namespace testMap
{
    public partial class MainPage : ContentPage
    {
        private FoursquareViewModel fvm;
        public MainPage(FoursquareViewModel f)
        {
            InitializeComponent();
            fvm = f;
        
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            var items = fvm.FoursquareVenues.Response.Groups[0].Items;
            map1.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(36.89, 10.18), Distance.FromKilometers(10)));
            foreach (var i in items)
            {
                var p = new Pin
                {
                    Position = new Position(i.Venue.Location.Lat, i.Venue.Location.Lng),
                    Label = i.Venue.Name,
                    Address = i.Venue.Location.Address
                    

            };
                p.Clicked += Pin_Clicked;
                map1.Pins.Add(p);
                
            }
          
            var pin = new Pin
            {
                Position = new Position(36.18, 10.510),
                Label = "premier pin",
                Address = "machya m3ak"


            };
          
            var pin2 = new Pin
            {
                Position = new Position(36.58, 10.610),
                Label = "2 pin",
                Address = "machya m3ak"


            };
           
            var pin3 = new Pin
            {
                Position = new Position(35.86, 10.160),
                Label = "3 pin",
                Address = "machya m3ak"


            };
            pin.Clicked += Pin_Clicked;
            pin2.Clicked += Pin_Clicked;
            pin3.Clicked += Pin_Clicked;
            map1.Pins.Add(pin);
            map1.Pins.Add(pin2);
            map1.Pins.Add(pin3);
        }
        private Pin s;
        private void Pin_Clicked(object sender, System.EventArgs e)
        {
            s = sender as Pin;
            place.BindingContext = fvm.FoursquareVenues.Response.Groups[0].Items.Find(item => item.Venue.Name == s?.Label);
           // DisplayAlert(s?.Label, s.Address, "OK");

        }

        private void Button_Clicked(object sender, System.EventArgs e)
        {
            CrossExternalMaps.Current.NavigateTo(s.Label, s.Position.Latitude, s.Position.Longitude,NavigationType.Driving);
        }
    }
}
