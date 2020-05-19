using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UplanTest.MyExpenses
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddExpenses : ContentView
    {
        string type = "Food";
        string am;
        string max;

        public AddExpenses()
        {
            InitializeComponent();
            food.BackgroundColor = Color.PaleVioletRed;
        }            
         async void OnFoodClicked(object sender, EventArgs args)

        {
            type= "Food";
            food.BackgroundColor= Color.PaleVioletRed;
            GoOut.BackgroundColor = Color.AliceBlue;
            Clothing.BackgroundColor = Color.AliceBlue;
            Health.BackgroundColor = Color.AliceBlue;
            Hobbies.BackgroundColor = Color.AliceBlue;
            Other.BackgroundColor = Color.AliceBlue;


        }

            async void OnCarbClicked(object sender, EventArgs args)

            {
                type = "Going Out";
                food.BackgroundColor = Color.AliceBlue;
                GoOut.BackgroundColor = Color.PaleVioletRed;
                Clothing.BackgroundColor = Color.AliceBlue;
                Health.BackgroundColor = Color.AliceBlue;
                Hobbies.BackgroundColor = Color.AliceBlue;
                Other.BackgroundColor = Color.AliceBlue;
        }

       async void OnGoOutClicked(object sender, EventArgs args)

       {
            type = "Clothes and accesories";
            food.BackgroundColor = Color.AliceBlue;
            GoOut.BackgroundColor = Color.AliceBlue;
            Clothing.BackgroundColor = Color.PaleVioletRed;
            Health.BackgroundColor = Color.AliceBlue;
            Hobbies.BackgroundColor = Color.AliceBlue;
            Other.BackgroundColor = Color.AliceBlue;
        }
        async void OnClothingClicked(object sender, EventArgs args)

        {
            type = "Clothes and accesories";
            food.BackgroundColor = Color.AliceBlue;
            GoOut.BackgroundColor = Color.AliceBlue;
            Clothing.BackgroundColor = Color.PaleVioletRed;
            Health.BackgroundColor = Color.AliceBlue;
            Hobbies.BackgroundColor = Color.AliceBlue;
            Other.BackgroundColor = Color.AliceBlue;
        }

        async void OnHealthClicked(object sender, EventArgs args)

        {
            type = "Health";
            food.BackgroundColor = Color.AliceBlue;
            GoOut.BackgroundColor = Color.AliceBlue;
            Clothing.BackgroundColor = Color.AliceBlue;
            Health.BackgroundColor = Color.PaleVioletRed;
            Hobbies.BackgroundColor = Color.AliceBlue;
            Other.BackgroundColor = Color.AliceBlue;
        }

        async void OnHobbiesClicked(object sender, EventArgs args)

        {
            type = "Health";
            food.BackgroundColor = Color.AliceBlue;
            GoOut.BackgroundColor = Color.AliceBlue;
            Clothing.BackgroundColor = Color.AliceBlue;
            Health.BackgroundColor = Color.AliceBlue;
            Hobbies.BackgroundColor = Color.PaleVioletRed;
            Other.BackgroundColor = Color.AliceBlue;
        }

        async void OnOtherClicked(object sender, EventArgs args)

        {
            type = "Other";
            food.BackgroundColor = Color.AliceBlue;
            GoOut.BackgroundColor = Color.AliceBlue;
            Clothing.BackgroundColor = Color.AliceBlue;
            Health.BackgroundColor = Color.AliceBlue;
            Hobbies.BackgroundColor = Color.PaleVioletRed;
            Other.BackgroundColor = Color.PaleVioletRed;
        }


        async void OnSaveClicked(object sender, EventArgs args)
            {
            max = amount.Text;
            if (max=="")
            {
                //max = Money
            }
            am= amount.Text;
            //Money.AddMoney(am, max, type);
            await Navigation.PopAsync();
        }

            async void OnCloseClicked(object sender, EventArgs args)
            {
                await Navigation.PopAsync();
            }
        }
    }

