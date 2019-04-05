using Plugin.LocalNotification;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace DatenSpeichernUndLaden
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        // DependencyService:
        // 1) Interface im .NET Standard erstellen (ITextFileHelper)
        // 2) Interface im Android/iOS/UWP - Projekt implementieren
        // 3) Attribut bei der Android/iOS/UWP hinzufügen ([assembly: Xamarin.Forms.Dependcy(meinDatentyp))]
        // 4) Service mit DependencyService.Get<IMeinInterface> holen

        private void ButtonSpeichern_Clicked(object sender, EventArgs e)
        {
            //// Variante 1) Xamarin:Essentials
            //string fullPath = Path.Combine(FileSystem.AppDataDirectory, "demo.txt");
            //File.WriteAllText(fullPath, entryText.Text);

            //DisplayAlert("Speichern", $"Datei wurde unter: {fullPath} gespeichert", "OK");


            // Variante 2) DependencyService
            ITextFileHelper helper = DependencyService.Get<ITextFileHelper>();
            helper.SaveIntoTextFile("demo.txt",entryText.Text);
            DisplayAlert("Speichern", "Datei wurde mit dem DependencyService gespeichert", "OK");
        }

        private void ButtonLaden_Clicked(object sender, EventArgs e)
        {
            //// Variante 1) Xamarin:Essentials
            //string fullPath = Path.Combine(FileSystem.AppDataDirectory, "demo.txt");
            //string content = File.ReadAllText(fullPath);

            //DisplayAlert("Laden", content, "OK");

            // Variante 2) DependencyService
            ITextFileHelper helper = DependencyService.Get<ITextFileHelper>();
            string text = helper.LoadFromTextFile("demo.txt");
            DisplayAlert("Laden mit DependencyService", text, "OK");
        }

        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            // Zugriff auf die Application-Properties
            labelMesswert.Text = App.Current.Properties["Messwert"].ToString();
            switchDarkmode.IsToggled = (bool)App.Current.Properties["Darkmode"];
        }

        private void SwitchDarkmode_Toggled(object sender, ToggledEventArgs e)
        {
            App.Current.Properties["Darkmode"] = switchDarkmode.IsToggled;
            //Sicherheitshalber
            App.Current.SavePropertiesAsync();

        }
    }
}
