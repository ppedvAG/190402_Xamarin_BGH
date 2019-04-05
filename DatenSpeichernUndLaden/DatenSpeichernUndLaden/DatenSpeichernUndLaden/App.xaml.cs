using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace DatenSpeichernUndLaden
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new TabbedPageRoot();

            // Anwendungseigenschaften (empfohlen: nur primitive Datentypen (string,int,double usw....)
            // Properties.Add("Darkmode", true);
            // WICHTIG: Bei einem Absturz wird nichts gespeichert !!!

            // Speichern erzwingen:
            // SavePropertiesAsync();

            // Setup für Startwerte
            if (Properties.ContainsKey("Darkmode") == false)
                Properties.Add("Darkmode", false);
            if (Properties.ContainsKey("Messwert") == false)
                Properties.Add("Messwert", 1234567);

            SavePropertiesAsync(); // Speichern erzwingen
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // HIER werden die ApplicationProperties gespeichert !!
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
