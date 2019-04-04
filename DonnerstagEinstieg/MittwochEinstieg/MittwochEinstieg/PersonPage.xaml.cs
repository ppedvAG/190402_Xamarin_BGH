using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MittwochEinstieg
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PersonPage : ContentPage
	{
		public PersonPage ()
		{
			InitializeComponent ();
		}

        // ObservableCollection gibt änderungen an der Liste (Add/Remove/Sort/Clear usw..) an das UI weiter
        // -> "Refresh" ist nicht notwendig !
        private ObservableCollection<Person> personen;

        private void LadePersonen()
        {
            personen = new ObservableCollection<Person>
            {
                new Person{Vorname="Tom",Nachname="Ate",Alter=10,Kontostand=100},
                new Person{Vorname="Anna",Nachname="Nass",Alter=20,Kontostand=2200},
                new Person{Vorname="Peter",Nachname="Silie",Alter=30,Kontostand=-300},
                new Person{Vorname="Franz",Nachname="Ose",Alter=40,Kontostand=1444},
                new Person{Vorname="Martha",Nachname="Pfahl",Alter=50,Kontostand=5550},
                new Person{Vorname="Albert",Nachname="Tross",Alter=60,Kontostand=-666},
                new Person{Vorname="Klara",Nachname="Fall",Alter=70,Kontostand=88754335},
                new Person{Vorname="Rainer",Nachname="Zufall",Alter=80,Kontostand=123456},
                new Person{Vorname="Axel",Nachname="Schweiß",Alter=90,Kontostand=-9886765},
                new Person{Vorname="Anna",Nachname="Bolika",Alter=100,Kontostand=1000000},
            };
        }


        private void ButtonSuchen_Clicked(object sender, EventArgs e)
        {
            LadePersonen();

            listViewPersonen.ItemsSource = personen;
        }

        private void ListViewPersonen_Refreshing(object sender, EventArgs e)
        {
            LadePersonen();

            listViewPersonen.ItemsSource = personen;

            // Variante 1
            // listViewPersonen.IsRefreshing = false;

            // Variante 2
            listViewPersonen.EndRefresh();
        }

        private void MenuItemInfo_Clicked(object sender, EventArgs e)
        {
            MenuItem item = sender as MenuItem;
            Person aktuellePerson = (Person)item.BindingContext;

            DisplayAlert("Personendaten", $"{aktuellePerson.GanzerName}, Alter:{aktuellePerson.Alter}, Kontostand: {aktuellePerson.Kontostand}€", "Ok");
        }

        private void MenuItemDelete_Clicked(object sender, EventArgs e)
        {
            MenuItem item = sender as MenuItem;
            Person aktuellePerson = (Person)item.BindingContext;

            personen.Remove(aktuellePerson);
        }

        private void SearchBarSuchtext_TextChanged(object sender, TextChangedEventArgs e)
        {
            listViewPersonen.ItemsSource = personen.Where(x => x.GanzerName.StartsWith(searchBarSuchtext.Text));
        }

        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            ButtonSuchen_Clicked(sender, e);
        }
    }
}