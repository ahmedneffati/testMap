using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using XamarinForms.ViewModels;
using XamarinForms.Views;

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
        
           
            var four = new FoursquareViewModel(); 
            await four.InitDataAsync();
            MainPage = new TabbedPage
            {
                Children ={
                    new MainPage(four),
                new FoursquareViewPage(four)
                }

            };

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
