using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MessagingCenter_Demo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            // Subscribe
            MessagingCenter.Subscribe<Slider, double>(this, "ValueChanged", LabelÄndern);

            // Unsubscribe:
            // MessagingCenter.Unsubscribe<Slider,double>(this, "ValueChanged");
        }

        private void LabelÄndern(Slider arg1, double arg2)
        {
            labelWert.Text = arg2.ToString();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Seite2()); // Es wird jedes Mal eine neue Seite2-Instanz erstellt
        }
    }
}
