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
            // StaticResource: Element ist editierbar, aber darf nicht ausgetauscht werden

            // DynamicResource: Erlaubt das Austauschen der Elemente in der Ressource
            // Idee: Button verweist mit einem Binding auf die Ressource "currentButtonStyle"
            // Im Code: this["currentButtonStyle"]= this.Ressource["lightMode"]

            if (e.Value == true)
                this.Resources["currentButtonStyle"] = this.Resources["buttonDarkTheme"];
            else
                this.Resources["currentButtonStyle"] = this.Resources["buttonLightTheme"];
        }

        private void ButtonLogin_Clicked(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(entryUsername.Text) == false && entryPasswort.Text == "geheim")
            {
                Navigation.PushAsync(new DataTabPage());
            }
            else
            {
                DisplayAlert("Login", "Username oder Passwort falsch", "OK");
            }
        }
    }
}
