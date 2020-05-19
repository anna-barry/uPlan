using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UplanTest
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainFridge : ContentPage
    {
        public MainFridge()
        {
            InitializeComponent();
        }

        private async void OnCloseClicked2(object sender, EventArgs args)
        {
            await Navigation.PopAsync();

        }

        private async void FridgeLink(object sender, EventArgs args)
        {

            await Navigation.PushAsync(new FridgePage());

        }

        private async void ShoppingLink(object sender, EventArgs args)
        {

            await Navigation.PushAsync(new Shopping_List());

        }
    }
}