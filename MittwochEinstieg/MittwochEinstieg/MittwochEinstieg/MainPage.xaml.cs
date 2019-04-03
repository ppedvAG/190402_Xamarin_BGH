using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MittwochEinstieg
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void SwitchDarkMode_Toggled(object sender, ToggledEventArgs e)
        {
            if (e.Value == true)
                buttonLogin.Style = (Style)this.Resources["buttonDarkTheme"];
            else
                buttonLogin.Style = this.Resources["buttonLightTheme"] as Style;
        }
    }
}
