using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;
using System.ComponentModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UplanTest
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FoodW : ContentPage
    {
        ListHelper prot1;
        ListHelper prot2;
        ListHelper prot3;
        ListHelper carb1;
        ListHelper carb2;
        ListHelper carb3;
        ListHelper veggies1;
        ListHelper veggies2;
        ListHelper veggies3;
        public FoodW()
        {
            InitializeComponent();

            prot1 = new ListHelper("PROTEIN", -1, "");
            Prot_1.FontSize = 10;
            Prot_1.ItemsSource = prot1.DisplayList;
            Prot_1.SelectedIndex = prot1.CurrentIndex;

            prot2 = new ListHelper("PROTEIN", -1, "");
            Prot_2.FontSize = 10;
            Prot_2.ItemsSource = prot2.DisplayList;
            Prot_2.SelectedIndex = prot2.CurrentIndex;

            prot3 = new ListHelper("PROTEIN", -1, "");
            Prot_3.FontSize = 10;
            Prot_3.ItemsSource = prot3.DisplayList;
            Prot_3.SelectedIndex = prot3.CurrentIndex;

            carb1 = new ListHelper("CARB", -1, "");
            Carb_1.FontSize = 10;
            Carb_1.ItemsSource = carb1.DisplayList;
            Carb_1.SelectedIndex = carb1.CurrentIndex;

            carb2 = new ListHelper("CARB", -1, "");
            Carb_2.FontSize = 10;
            Carb_2.ItemsSource = carb2.DisplayList;
            Carb_2.SelectedIndex = carb2.CurrentIndex;

            carb3 = new ListHelper("CARB", -1, "");
            Carb_3.FontSize = 10;
            Carb_3.ItemsSource = carb3.DisplayList;
            Carb_3.SelectedIndex = carb3.CurrentIndex;

            veggies1 = new ListHelper("VEGGIES", -1, "");
            Veggies_1.FontSize = 10;
            Veggies_1.ItemsSource = veggies1.DisplayList;
            Veggies_1.SelectedIndex = veggies1.CurrentIndex;

            veggies2 = new ListHelper("VEGGIES", -1, "");
            Veggies_2.FontSize = 10;
            Veggies_2.ItemsSource = veggies2.DisplayList;
            Veggies_2.SelectedIndex = veggies2.CurrentIndex;

            veggies3 = new ListHelper("VEGGIES", -1, "");
            Veggies_3.FontSize = 10;
            Veggies_3.ItemsSource = veggies3.DisplayList;
            Veggies_3.SelectedIndex = veggies3.CurrentIndex;


        }
        async void OnButtonClicked(object sender, EventArgs args)

        {

            MyFoodWeek.UpdateFood(prot1.ListEntryList[Prot_1.SelectedIndex], prot2.ListEntryList[Prot_2.SelectedIndex],
                 prot3.ListEntryList[Prot_3.SelectedIndex], carb1.ListEntryList[Carb_1.SelectedIndex], carb2.ListEntryList[Carb_2.SelectedIndex],
                 carb3.ListEntryList[Carb_3.SelectedIndex], veggies1.ListEntryList[Veggies_1.SelectedIndex], veggies2.ListEntryList[Veggies_2.SelectedIndex],
                 veggies3.ListEntryList[Veggies_3.SelectedIndex]);

        }

        /*public static void Update(
           string uName, string uEmailAddress, ListEntry uAccomodationType,
           string uShoppingDay, string uCleaningDay)

        {
            me.UpdateUser(uName, uEmailAddress, uAccomodationType, uShoppingDay, uCleaningDay);

            // Keep MyUser static variables up to date after this database update
            Initiate();
        } */
    }
}
