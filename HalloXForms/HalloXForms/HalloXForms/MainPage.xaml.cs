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
        private string aktuelleFarbe;

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
            aktuelleFarbe = farbe;
        }

        private void ButtonLogin_Clicked(object sender, EventArgs e)
        {
            if(entryPasswort.Text == "geheim")
            {
                DisplayAlert("Login", "Login erfolgreich", "Yay");
            }
        }

        private async void ButtonZeit_Clicked(object sender, EventArgs e)
        {
            var aktuelleZeit = timePicker.Time;
            var aktuellesDatum = datePicker.Date;

            await DisplayAlert("Zeit", aktuelleZeit.ToString(), "OK");
            await DisplayAlert("Datum", aktuellesDatum.ToString(), "OK");

            // StringInterpolation C# 6
            string text1 = "Hallo";
            string text2 = "Welt";
            string text3 = "!";

            int zahl1 = 5;
            int zahl2 = 10;

            string ausgabe = text1 + " " + text2 + " " + text3;
            // "Die Summe von " + zahl1 + " und " + zahl2 + " ist " + ergebnis;

            string ausgabe2 = $"{text1} {text2}";

            var x = $"Die Summe von {zahl1} und {zahl2} ist {zahl1 + zahl2}";
        }
    }
}
