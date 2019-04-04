using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MittwochEinstieg
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DynamicPage : ContentPage
	{
		public DynamicPage ()
		{
			InitializeComponent ();
		}

        private void ListViewDaten_Refreshing(object sender, EventArgs e)
        {
            listViewDaten.ItemsSource = new List<DynamicItem>
            {
                new DynamicItem("Item 1","Ich habe fertig"),
                new DynamicItem("Item 2","lalalalala"),
                new DynamicItem("Ein Item 3","demo"),
                new DynamicItem("Testitem 4","es gab einen fehler :( ")
            };

            listViewDaten.EndRefresh();
        }
    }
}