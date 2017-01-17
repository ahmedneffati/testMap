using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using testMap.ViewModels;
using testMap.Views;
using Xamarin.Forms;


namespace testMap
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new ContentPage();                   
        }
    

        protected override async void OnStart()
        {
            MainPage = new Menu();
           
         /*   var four = new TerrainViewModel(); 
            await four.InitializerDataASYNC();
            MainPage = new TabbedPage
            {
                Children ={
                    new MainPage(four),
                   new InscriptionJoueur()


                }

            };
            */

        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
