using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinPlugins
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LocationPage : ContentPage
	{
		public LocationPage ()
		{
			InitializeComponent ();
		}

        private async void ButtonGetLocation_Clicked(object sender, EventArgs e)
        {
            try
            {
                var Location = await Geolocation.GetLastKnownLocationAsync();
                //var Location = await Geolocation.GetLocationAsync();
                await Location.OpenMapsAsync();
            }
            catch (Exception ex)
            {

            }

            // Unterschiede im Code:

            if(Device.RuntimePlatform == Device.UWP)
            {
                if(Device.Idiom == TargetIdiom.Desktop)
                {
                    // gilt nur für UWP am Desktop
                }
            }
        }

        private void ButtonUWPOpenMaps_Clicked(object sender, EventArgs e)
        {
            Map.OpenAsync(-55.084,37.422,new MapLaunchOptions { NavigationMode = NavigationMode.Walking });
        }
    }
}