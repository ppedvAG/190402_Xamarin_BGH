using System;
using System.Collections.Generic;
using System.Text;

namespace DatenSpeichernUndLaden
{
    // Datenquelel: https://jsonplaceholder.typicode.com/todos
    class ToDoItem
    {
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public bool completed { get; set; }
    }
}
