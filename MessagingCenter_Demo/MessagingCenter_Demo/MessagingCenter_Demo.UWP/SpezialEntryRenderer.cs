using MessagingCenter_Demo;
using MessagingCenter_Demo.UWP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;


[assembly: ExportRenderer(typeof(SpezialEntry),typeof(SpezialEntryRenderer))]
namespace MessagingCenter_Demo.UWP
{
    class SpezialEntryRenderer : EntryRenderer
    {
        // CustomRenderer:
        /*
         * 1) Eigene Klasse oder ein Steuerelement, das man verändern möchte
         * 2) Im nativen Projekt eine Renderer-Klasse erstellen
         * 3) Renderer-Klasse erbt von "EntryRenderer"
         * 4) override OnElementChanged  -> Generieren lassen
         * 5) Mit einem Attribut sagen, dass ab sofort dieser Renderer für den Datentyp "SpezialEntry" genutzt werden soll
         */

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            // Das zu rendernde Entry verändern
            Control.Background = new LinearGradientBrush
            {
                GradientStops = new GradientStopCollection
                {
                    new GradientStop{Offset=0,Color= Windows.UI.Colors.LemonChiffon},
                    new GradientStop{Offset=0.5,Color= Windows.UI.Colors.PapayaWhip},
                    new GradientStop{Offset=1,Color= Windows.UI.Colors.YellowGreen},
                }
            };
        }
    }
}
