using MVVM_Beispiel.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MVVM_Beispiel.ViewModels
{
    public class PersonenViewModel
    {
        public PersonenViewModel()
        {
            service = new PersonenService();
            LadePersonenCommand = new Command(LadePersonen);
        }
        private readonly PersonenService service;



        // Öffentlich für die View sichtbar:
        public List<Person> Personenliste { get; set; }
        public Command LadePersonenCommand { get; set; } // Ersatz für Button.Clicked - Events
        private void LadePersonen(object obj)
        {


            throw new NotImplementedException();
        }
    }
}
