using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MessagingCenter_Demo
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LabledEntry : ContentView
	{
		public LabledEntry ()
		{
			InitializeComponent ();
            this.BindingContext = this;
		}

        // Variante "Lang"

        //public string LabelText { get; set; }
        //public string EntryText { get; set; }
        //public string Placeholder { get; set; }

        // BindableProperties
        // Spezielles Property das auch Styling,Binding, uvm... unterstützt

        // propdp => "DependencyProperty" aus WPF
        // Vorschlag: DependencyProperty (WPF) erstellen und zu BindableProperty (Xamarin) umbauen

        /* Erstellen:
         * 1) propdp + TAB + TAB
         * 2) "DependencyProperty" durch "BindableProperty" ersetzen
         * 3) .Register - Methode durch die .Create - Methode ersetzen
         * 4) Parameter1: Propertyname und Parametername gleichsetzen (beides auf "LabelText")
         * 5) Parameter2: Datentyp gleichsetzen (im Get;Set; und im 2ten Parameter)
         * 6) Parameter3: ownerclass durch den eigenen Klassennamen ersetzen (hier "LabledEntry")
         * 7) Parameter4: "new PropertyMetadata(0)" durch den Standardwert/NullWert ersetzen
         * 8) Name des BindableProperteis "MyPropertyProperty" zu "LabelTextProperty" ändern
         */


        public string LabelText
        {
            get { return (string)GetValue(LabelTextProperty); }
            set { SetValue(LabelTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly BindableProperty LabelTextProperty =
            BindableProperty.Create("LabelText", typeof(string), typeof(LabledEntry), "");

        public string Placeholder
        {
            get { return (string)GetValue(PlaceholderProperty); }
            set { SetValue(PlaceholderProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly BindableProperty PlaceholderProperty =
            BindableProperty.Create("Placeholder", typeof(string), typeof(LabledEntry), "");

        public string EntryText
        {
            get { return (string)GetValue(EntryTextProperty); }
            set { SetValue(EntryTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly BindableProperty EntryTextProperty =
            BindableProperty.Create("EntryText", typeof(string), typeof(LabledEntry), "");



    }
}