using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DatenSpeichernUndLaden
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RESTPage : ContentPage
    {
        public RESTPage()
        {
            InitializeComponent();
        }

        private async void ListView_Refreshing(object sender, EventArgs e)
        {
            // 1) Webseite als string herunterladen
            // 2) Daten(json-string) Deserialisieren
            // 3) Daten in die ListView eintragen

            using (HttpClient client = new HttpClient())
            {
                // Option in VisualStudio "Enable Single-Click URL Navigation" - Abdrehen
                string json = await client.GetStringAsync("https://jsonplaceholder.typicode.com/todos");
                listViewToDo.ItemsSource = JsonConvert.DeserializeObject<List<ToDoItem>>(json);
            } // Sobald wir den using-block verlassen, wird der HTTPClient für uns ordnungsgemäß geschlossen


            listViewToDo.EndRefresh();
        }
    }
}