using DiplomadoShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DiplomadoShop.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailPageView : MasterDetailPage
    {
        NavigationPage _navigationPage;
        public MasterDetailPageView()
        {
            InitializeComponent();
            
            //mainPageView.menuListview.ItemSelected += MenuListview_ItemSelected;

        }

        //private async void MenuListview_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        //{
        //    if (e.SelectedItem is NavigationMenuItems  item) {
              
        //        Detail = new NavigationPage((Page)Activator.CreateInstance(item.ViewType));
        //        mainPageView.menuListview.SelectedItem = null;
        //        IsPresented = false;

        //    }
        //}



        protected override void OnAppearing()
        {
            // base.OnAppearing();
            App.Master = this;
            App.Navigator = Navigator;
           
        }

    }
}