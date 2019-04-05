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

        private void ButtonSpeichern_Clicked(object sender, EventArgs e)
        {
            // Variante 1) Xamarin:Essentials
            string fullPath = Path.Combine(FileSystem.AppDataDirectory, "demo.txt");
            File.WriteAllText(fullPath, entryText.Text);

            DisplayAlert("Speichern", $"Datei wurde unter: {fullPath} gespeichert", "OK");
        }

        private void ButtonLaden_Clicked(object sender, EventArgs e)
        {
            // Variante 1) Xamarin:Essentials
            string fullPath = Path.Combine(FileSystem.AppDataDirectory, "demo.txt");
            string content = File.ReadAllText(fullPath);

            DisplayAlert("Laden", content, "OK");
        }
    }
}
