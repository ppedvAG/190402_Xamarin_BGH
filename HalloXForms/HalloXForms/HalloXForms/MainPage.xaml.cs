using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HalloXForms
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            // 3 Arten für Nachrichten:

            // 1) DisplayAlert mit einer Antwort
            // await DisplayAlert("Meine erste Nachricht", "Hallo Welt", "OK");

            // 2) DisplayAlert mit zwei Antworten ("Ja/Nein")
            //bool antwort = await DisplayAlert("Meine Frage", "Wollen wir Mittagspause machen ?", "Ja","Nein");
            //await DisplayAlert("Deine Antwort war:", antwort.ToString(), "OK");

            // 3) DisplayActionSheet mit mehreren Antworten ("Ja/Nein")
            string farbe = await DisplayActionSheet("Wähle deine Lieblingsfarbe", null, null, "Rot", "Gelb", "Grün", "Blau", "Orange");
            await DisplayAlert("Deine Farbe war:", farbe, "Yay");

        }
    }
}
