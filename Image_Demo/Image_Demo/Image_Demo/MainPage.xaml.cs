using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Image_Demo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            // Variante 1
            //var source = (UriImageSource)ImageSource.FromUri(new Uri("asdasdasda"));
            //source.CachingEnabled = true; // Standardfall ist True
            //source.CacheValidity = TimeSpan.FromMinutes(10); // Standardfall ist 24h

            //image1.Source = source;

            // Variante 2:
            // image1.Source = ImageSource.FromFile("katze.jpg");

            // Variante 3:
            // Automatisch generierte Resourcen-ID: Projektname.Ordnername.Dateiname.Extension
            // image1.Source = ImageSource.FromResource("Image_Demo.Images.hund.jpg");
        }
    }
}
