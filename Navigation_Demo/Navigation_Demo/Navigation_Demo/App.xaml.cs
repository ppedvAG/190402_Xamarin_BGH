using Navigation_Demo.MD;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Navigation_Demo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Wahl des Einstiegspunktes:
            // MainPage = new NavigationPage(new MainPage()); // <-- MainPage in einer NavigationPage kapseln
            // MainPage = new TabbedPage_Demo();
            // MainPage = new CarouselPage_Demo();
            MainPage = new MasterDetail_Root();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
