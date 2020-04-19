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
    public partial class AddOneFood : ContentPage
    {
        string foodtype = "PROTEIN";
        string foodname = "";

        public AddOneFood()
        {
            InitializeComponent();

        }

        async void OnProtClicked(object sender, EventArgs args)

        {
            foodtype = "PROTEIN";

        }

        async void OnCarbClicked(object sender, EventArgs args)

        {
            foodtype = "CARB";

        }

        async void OnVegClicked(object sender, EventArgs args)

        {
            foodtype = "VEGGIES";

        }

        async void OnSaveClicked(object sender, EventArgs args)
        {
            foodname = desc.Text;
            ListEntryForFood.InsertNewFood(foodtype, foodname, foodname);
            await Navigation.PushAsync(new FoodW());

        }

        /*async void OnCloseClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new FoodW());
        }*/
    }
}