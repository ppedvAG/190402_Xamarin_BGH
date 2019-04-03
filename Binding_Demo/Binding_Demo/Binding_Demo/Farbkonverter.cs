using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Binding_Demo
{
    class Farbkonverter : IValueConverter
    {
        // OneWay-Binding
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string farbe = (string)value;

            // "#FF00FF" => RGB
            if(farbe[0] == '#')
            {
                return Color.FromHex(farbe);
            }

            // Variante "einfach"
            //if (farbe == "Red")
            //    return Color.Red;
            //else if (farbe == "Green")
            //    return Color.Green;
            //else
            //    return Color.Black;

            // Variante mit Reflection ->
            var allFields = typeof(Color).GetFields();
            
            if(allFields.Any(x => x.Name.ToLower() == farbe.ToLower())) // Gibt es ein Feld mit dem selben Namen ?
            {
                return allFields.First(x => x.Name.ToLower() == farbe.ToLower()).GetValue(typeof(Color));
            }
            else // Es gibt kein Feld mit diesem Namen
            {
                return Color.Black;
            }
        }

        // TwoWay-Binding 
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
