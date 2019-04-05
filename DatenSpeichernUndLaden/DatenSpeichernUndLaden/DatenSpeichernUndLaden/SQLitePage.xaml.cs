using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using SQLite;
using System.IO;
using Xamarin.Essentials;

namespace DatenSpeichernUndLaden
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SQLitePage : ContentPage
	{
		public SQLitePage ()
		{
			InitializeComponent ();

            string fullPath = Path.Combine(FileSystem.AppDataDirectory, "db.sqlite");
            connection = new SQLiteConnection(fullPath); // Erstellt die DB wenn sie nicht existiert und öffnet die Datei, wenn sie existiert

            connection.CreateTable<Person>(); // Wenn die Tabelle noch nicht existieren sollte, wird sie erstellt. Wenn die Tabelle bereits existiert, passiert NICHTS !
        }
        private SQLiteConnection connection;

        private void ButtonEinfügen_Clicked(object sender, EventArgs e)
        {
            Person p = new Person();
            p.Vorname = entryVorname.Text;
            p.Nachname = entryNachname.Text;

            // Einfügen in die DB:
            connection.Insert(p); // Speichert automatisch !!!
        }

        private void ListViewPersonen_Refreshing(object sender, EventArgs e)
        {
            listViewPersonen.ItemsSource = connection.Table<Person>(); // Gibt die gesamte Tabelle für den Datentyp "Person" zurück
            listViewPersonen.EndRefresh();

            // Table<T>() als TableQuery
            // Arbeiten mit LINQ ist ebenfalls möglich:
            // connection.Table<Person>().Where(x => x.ID > 20);
        }
    }
}