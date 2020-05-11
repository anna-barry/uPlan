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
            Prot.BackgroundColor = Color.PaleVioletRed;

        }

        async void OnProtClicked(object sender, EventArgs args)

        {
            foodtype = "PROTEIN";
            Prot.BackgroundColor = Color.PaleVioletRed;
            Carb.BackgroundColor = Color.AliceBlue;
            Veg.BackgroundColor = Color.AliceBlue;

        }

        async void OnCarbClicked(object sender, EventArgs args)

        {
            foodtype = "CARB";
            Prot.BackgroundColor = Color.AliceBlue;
            Carb.BackgroundColor = Color.PaleVioletRed;
            Veg.BackgroundColor = Color.AliceBlue;

        }

        async void OnVegClicked(object sender, EventArgs args)

        {
            foodtype = "VEGGIES";
            Prot.BackgroundColor = Color.AliceBlue;
            Carb.BackgroundColor = Color.AliceBlue;
            Veg.BackgroundColor = Color.PaleVioletRed;
        }

        async void OnSaveClicked(object sender, EventArgs args)
        {
            foodname = desc.Text;
            ListEntryForFood.InsertNewFood(foodtype, foodname, foodname);
            await Navigation.PushAsync(new FoodW());

        }

        async void OnCloseClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new FoodW());
        }
    }
}