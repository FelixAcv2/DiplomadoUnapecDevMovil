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
    public partial class ProductDetailView : ContentPage
    {
      /// public Product CurrentProduct { get; set; }
        public ProductDetailView()
        {
            InitializeComponent();
        }

        //public ProductDetailView(Product product):this()
        //{
        //    CurrentProduct = product !=null ? product:new Product();
        //    lbName.Text = CurrentProduct.Name;
        //    lbShortDescription.Text = CurrentProduct.ShortDescription;
        //    lbLongDescription.Text = CurrentProduct.LongDescription;
        //    lbPrice.Text = CurrentProduct.Price.ToString();
        //    productImageUrl.Source = CurrentProduct.ImageUrl;
            
        //    //this.BindingContext = CurrentProduct;
        //}

        //private void Button_Clicked(object sender, EventArgs e)
        //{
        //    App.Navigator.PushAsync(new SettingView());
        //}
    }
}