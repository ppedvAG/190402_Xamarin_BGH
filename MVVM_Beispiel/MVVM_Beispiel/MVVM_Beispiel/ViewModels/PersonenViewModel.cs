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
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Personenliste)));
        }
    }
}
