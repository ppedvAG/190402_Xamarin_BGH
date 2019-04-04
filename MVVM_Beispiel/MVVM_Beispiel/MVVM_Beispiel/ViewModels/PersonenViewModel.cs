using MVVM_Beispiel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace MVVM_Beispiel.ViewModels
{
    public class PersonenViewModel : INotifyPropertyChanged
    {
        public PersonenViewModel()
        {
            service = new PersonenService();
            LadePersonenCommand = new Command(LadePersonen);
        }
        private readonly PersonenService service;
        public event PropertyChangedEventHandler PropertyChanged;




        // Öffentlich für die View sichtbar:
        public List<Person> Personenliste { get; set; }
        public Command LadePersonenCommand { get; set; } // Ersatz für Button.Clicked - Events
        private void LadePersonen(object obj)
        {
            Personenliste = service.LadePersonen();

            // C#6 NullConditional Operator
            //if(PropertyChanged != null)
            //{
            //    PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(Personenliste)));
            //}

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Personenliste)));

            // Anwendungsfall
            // Person.Adresse.Straße
            // if(person != null && person.adresse != null && person.adresse.straße != null)

            // if(person?.adresse?.straße != null)

            // StringBuilder
            // (stringbuilder != null && stringbuilder.Length > 10)
            // (stringbuilder?.Length > 10)
        }
    }
}
