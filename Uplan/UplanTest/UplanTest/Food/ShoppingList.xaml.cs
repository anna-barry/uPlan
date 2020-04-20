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
    public partial class ShoppingList : ContentPage
    {
        public ShoppingList()
        {
            InitializeComponent();
        }

        /* DEBUT RECHERCHES 
         * private void checkbox_CheckChanged(object sender, EventArgs e)

        {

            var checkbox = (CheckBox)sender;

            var ob = checkbox.BindingContext as <>;

            if (ob != null)

            {

                AddOrUpdatetheResult(ob, checkbox);

            }

        }

        private void AddOrUpdatetheResult(<your model name> ob, CheckBox checkbox)

        {

            // Check if a particular checkbox is checked or not with below if

            if (checkbox.IsChecked)
            {

                // create your logic further as per the flow of your app and the data of the particular item in Listview can be fetched from the     //‘ob’

            }

        }-*/
    }
}