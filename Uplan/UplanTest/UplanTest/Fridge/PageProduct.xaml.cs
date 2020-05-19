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
    public partial class PageProduct : ContentPage
    {
        public PageProduct(FrigoBaseDeDonnée produit)
        {
            
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" },
                    new Label { Text = produit.Name},
                }

            };
        }


    }
}