using System;
using System.Collections.Generic;
using System.Text;

namespace MVVM_Beispiel.Models
{
    public class PersonenService
    {
        public List<Person> LadePersonen()
        {
            // Webservice aufrufen, REST-API ... WCF ...
            return new List<Person>
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
    }
}
