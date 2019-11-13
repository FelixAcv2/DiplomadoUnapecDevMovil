using DiplomadoShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DiplomadoShop.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustormeDetailView : ContentPage
    {

        public Customer CurrentCustomer { get; set; }
        public CustormeDetailView()
        {
            InitializeComponent();
            
        }

        public CustormeDetailView(Customer customer):this()
        {
             CurrentCustomer = customer;

             this.lbName.Text = CurrentCustomer.Name;
             this.lbNumberPhone.Text = CurrentCustomer.Number_Phone;
             this.lbEmail.Text = CurrentCustomer.Email;
             this.lbAddress.Text = CurrentCustomer.Address;
             this.spCity.Text = CurrentCustomer.City;
             this.spState.Text = CurrentCustomer.State;
            this.spZipCode.Text = CurrentCustomer.ZipCode;

        }

        private async void Email_Click(object sender, EventArgs e)
        {

            await Email.ComposeAsync(string.Empty, string.Empty, CurrentCustomer.Email);
        }

        private async void SMS_CLick(object sender, EventArgs e)
        {
            await Sms.ComposeAsync(new SmsMessage(string.Empty,CurrentCustomer.Number_Phone));
        }

        private  void NumberPhone_Click(object sender, EventArgs e)
        {
            PhoneDialer.Open(CurrentCustomer.Number_Phone);
        }

        private async void NavigateAddress_Click(object sender, EventArgs e)
        {
            await Map.OpenAsync(new Placemark
            {
                Thoroughfare = CurrentCustomer.Address,
                Locality = CurrentCustomer.City,
                AdminArea = CurrentCustomer.State,
                PostalCode = CurrentCustomer.ZipCode
            });
        }
    }
}