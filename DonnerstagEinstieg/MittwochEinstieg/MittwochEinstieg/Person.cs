using System;
using System.Collections.Generic;
using System.Text;

namespace MittwochEinstieg
{
    class Person
    {
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public string GanzerName
        {
            get
            {
                return $"{Vorname} {Nachname}";
            }
        }

        public byte Alter { get; set; }
        public decimal Kontostand { get; set; }
    }
}
