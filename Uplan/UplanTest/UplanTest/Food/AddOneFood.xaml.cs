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
            Prot.BackgroundColor = Color.BlueViolet;
            if (Device.RuntimePlatform!="UWP")
            {

            }

        }

        async void OnProtClicked(object sender, EventArgs args)

        {
            foodtype = "PROTEIN";
            Prot.BackgroundColor = Color.BlueViolet;
            Carb.BackgroundColor = Color.AliceBlue;
            Veg.BackgroundColor = Color.AliceBlue;

        }

        async void OnCarbClicked(object sender, EventArgs args)

        {
            foodtype = "CARB";
            Prot.BackgroundColor = Color.AliceBlue;
            Carb.BackgroundColor = Color.BlueViolet;
            Veg.BackgroundColor = Color.AliceBlue;

        }

        async void OnVegClicked(object sender, EventArgs args)

        {
            foodtype = "VEGGIES";
            Prot.BackgroundColor = Color.AliceBlue;
            Carb.BackgroundColor = Color.AliceBlue;
            Veg.BackgroundColor = Color.BlueViolet;
        }

        async void OnSaveClicked(object sender, EventArgs args)
        {
            foodname = desc.Text;
            ListEntryForFood.InsertNewFood(foodtype, foodname, foodname);
            await Navigation.PopAsync();

        }

        async void OnCloseClicked(object sender, EventArgs args)
        {
            await Navigation.PopAsync();
        }
    }
}