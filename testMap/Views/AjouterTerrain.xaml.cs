using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace testMap.Views
{
    public partial class AjouterTerrain : ContentPage
    {
        public AjouterTerrain()
        { 
            InitializeComponent();
            positionAsync();

        }
        public async Task positionAsync()
        {
            var locat = CrossGeolocator.Current;
            locat.DesiredAccuracy = 500;
            var position = await locat.GetPositionAsync(timeoutMilliseconds: 100000);
            lat.Text = position.Latitude.ToString();
            lon.Text = position.Longitude.ToString();
        }
    }
}
