using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Navigation_Demo.MD
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetail_RootMaster : ContentPage
    {
        public ListView ListView;

        public MasterDetail_RootMaster()
        {
            InitializeComponent();

            BindingContext = new MasterDetail_RootMasterViewModel();
            ListView = MenuItemsListView;
        }

        class MasterDetail_RootMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MasterDetail_RootMenuItem> MenuItems { get; set; }
            
            public MasterDetail_RootMasterViewModel()
            {
                MenuItems = new ObservableCollection<MasterDetail_RootMenuItem>(new[]
                {
                    new MasterDetail_RootMenuItem(typeof(MasterDetail_RootDetail)) { Id = 0, Title = "Page 1" },
                    new MasterDetail_RootMenuItem(typeof(MasterDetail_RootDetail)) { Id = 1, Title = "Page 2" },
                    new MasterDetail_RootMenuItem(typeof(MasterDetail_RootDetail)) { Id = 2, Title = "Page 3" },
                    new MasterDetail_RootMenuItem(typeof(MainPage)) { Id = 3, Title = "MainPage" },
                    new MasterDetail_RootMenuItem(typeof(TabbedPage_Demo)) { Id = 4, Title = "TabPage" },
                });
            }
            
            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}