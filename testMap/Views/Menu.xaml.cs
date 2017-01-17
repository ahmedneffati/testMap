using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testMap.ViewModels;
using Xamarin.Forms;

namespace testMap.Views
{
    public partial class Menu : MasterDetailPage
    {
        public Menu()
        {
            InitializeComponent();
            IsPresented = true;
        }

        private async void AllerListTerrainAsync(object sender, EventArgs e)
        {

            var four = new TerrainViewModel();
            await four.InitializerDataASYNC();
            Detail = new NavigationPage(new MainPage(four));

            // Detail = new NavigationPage(new AjouterTerrain());
        }
        public void AllerAjouterTerrain(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new AjouterTerrain());
        }
        }
}
