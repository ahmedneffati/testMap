using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace testMap.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            Xamarin.FormsMaps.Init("ewblMkcjh7HZTg8CyuXv~01cOZLo26aFoXVypmeTphw~AqrTNHkjt-4L-HHoriiBFSWM03jz4uVSpEyWviWi0zQijXltUcQX-x8OYgCYtMOH"); 
            LoadApplication(new testMap.App());
        }
    }
}
