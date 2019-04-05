using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MessagingCenter_Demo
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Seite2 : ContentPage
	{
		public Seite2 ()
		{
			InitializeComponent ();
		}

        private void SliderWert_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            // Publisher -> Schickt "Benachrichtigung" an alle Subscriber, die sich für die Nachricht "ValueChanged" interessieren
            MessagingCenter.Send(sliderWert, "ValueChanged", sliderWert.Value); 
        }
    }
}