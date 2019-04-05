using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MessagingCenter_Demo
{
    public class SpezialEntry : Entry
    {
        // CustomRenderer:
        /*
         * 1) Eigene Klasse oder ein Steuerelement, das man verändern möchte
         * 2) Im nativen Projekt eine Renderer-Klasse erstellen
         * 3) Renderer-Klasse erbt von "EntryRenderer"
         * 4) override OnElementChanged  -> Generieren lassen
         * 5) Mit einem Attribut sagen, dass ab sofort dieser Renderer für den Datentyp "SpezialEntry" genutzt werden soll
         */
    }
}
