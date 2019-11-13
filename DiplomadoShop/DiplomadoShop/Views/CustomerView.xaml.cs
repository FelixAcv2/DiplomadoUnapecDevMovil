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
    public partial class CustomerView : ContentPage
    {
        public CustomerView()
        {
            InitializeComponent();
           // customerListview.ItemSelected += CustomerListview_ItemSelected;
        }

        //private async void CustomerListview_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        //{
        //    if (e.SelectedItem is Customer customer)
        //    {

        //        await this.Navigation.PushAsync(new CustormeDetailView(customer));
        //        customerListview.SelectedItem = null;
        //    }
        //}
    }
}