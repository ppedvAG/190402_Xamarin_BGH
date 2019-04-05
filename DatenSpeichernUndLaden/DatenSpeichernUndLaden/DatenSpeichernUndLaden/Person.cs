using System;
using System.Collections.Generic;
using System.Text;
using SQLite;


namespace DatenSpeichernUndLaden
{
    // Definition, wie alles in der DB aussieht
    // [Table("Personen")]
    class Person
    {
        [PrimaryKey,AutoIncrement]
        public int ID { get; set; }
        [MaxLength(255)] // Column("Vornamen")
        public string Vorname { get; set; }
        [Unique]
        public string Nachname { get; set; }
    }
}
