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
    public partial class DiplomadoShopNavigationPage : NavigationPage
    {
        public DiplomadoShopNavigationPage()
        {
            InitializeComponent();
        }

        public DiplomadoShopNavigationPage(Page root) : base(root)
        {
            InitializeComponent();
        }
    }
}