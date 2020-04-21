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
        bool toggled = false;
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

        void OnToggled(object sender, ToggledEventArgs e)
        {
            toggled = !toggled;
        }

        public void OnButtonClicked(object sender, EventArgs args)

        {

            MyFoodWeek.UpdateFood(prot1.ListEntryList[Prot_1.SelectedIndex], prot2.ListEntryList[Prot_2.SelectedIndex],
                 prot3.ListEntryList[Prot_3.SelectedIndex], carb1.ListEntryList[Carb_1.SelectedIndex], carb2.ListEntryList[Carb_2.SelectedIndex],
                 carb3.ListEntryList[Carb_3.SelectedIndex], veggies1.ListEntryList[Veggies_1.SelectedIndex], veggies2.ListEntryList[Veggies_2.SelectedIndex],
                 veggies3.ListEntryList[Veggies_3.SelectedIndex]);

            if (toggled)
            {
                GetShoppinForWeek();
            }

        }

        async void Add(object sender, EventArgs args)

        {
           
            await Navigation.PushAsync(new AddOneFood());
        }

        public static async void GetShoppinForWeek()
        {
            var col = Database.db.GetCollection<FoodItem>("FoodForShoppingList");
            //INSERT FOOD ITEM FOR EACH FOOD OF THIS WEEK
            // for the dueDate the idea is that for the next Sunday the food must be eaten (new food plan after that) 
            //-> we need to add the possibility to change all due Dates
            DateTime res = GetNextSunday();

            string typeForCarb1 = MyFoodWeek.thisweek.FoodCategoryTypeCarb1;
            string codeForCarb1 = MyFoodWeek.thisweek.FoodCategoryCodeCarb1;
            string descForCarb1 = MyFoodWeek.thisweek.FoodCategoryDescCarb1;
            FoodItem.InsertFoodItem(typeForCarb1, codeForCarb1, descForCarb1, res);
            col.Insert(FoodItem.getEntryfromTypeAndCode(typeForCarb1, codeForCarb1));

            string typeForCarb2 = MyFoodWeek.thisweek.FoodCategoryTypeCarb2;
            string codeForCarb2 = MyFoodWeek.thisweek.FoodCategoryCodeCarb2;
            string descForCarb2 = MyFoodWeek.thisweek.FoodCategoryDescCarb2;
            FoodItem.InsertFoodItem(typeForCarb2, codeForCarb2, descForCarb2, res);
            col.Insert(FoodItem.getEntryfromTypeAndCode(typeForCarb2, codeForCarb2));


            string typeForCarb3 = MyFoodWeek.thisweek.FoodCategoryTypeCarb3;
            string codeForCarb3 = MyFoodWeek.thisweek.FoodCategoryCodeCarb3;
            string descForCarb3 = MyFoodWeek.thisweek.FoodCategoryDescCarb2;
            FoodItem.InsertFoodItem(typeForCarb3, codeForCarb3, descForCarb3, res);
            col.Insert(FoodItem.getEntryfromTypeAndCode(typeForCarb3, codeForCarb3));

            string typeForProt1 = MyFoodWeek.thisweek.FoodCategoryTypeProt1;
            string codeForProt1 = MyFoodWeek.thisweek.FoodCategoryCodeProt1;
            string descForProt1 = MyFoodWeek.thisweek.FoodCategoryDescProt1;
            FoodItem.InsertFoodItem(typeForProt1, codeForProt1, descForProt1, res);
            col.Insert(FoodItem.getEntryfromTypeAndCode(typeForProt1, codeForProt1));

            string typeForProt2 = MyFoodWeek.thisweek.FoodCategoryTypeProt2;
            string codeForProt2 = MyFoodWeek.thisweek.FoodCategoryCodeProt2;
            string descForProt2 = MyFoodWeek.thisweek.FoodCategoryDescProt2;
           FoodItem.InsertFoodItem(typeForProt2, codeForProt2, descForProt2, res);
            col.Insert(FoodItem.getEntryfromTypeAndCode(typeForProt2, codeForProt2));

            string typeForProt3 = MyFoodWeek.thisweek.FoodCategoryTypeProt3;
            string codeForProt3 = MyFoodWeek.thisweek.FoodCategoryCodeProt3;
            string descForProt3 = MyFoodWeek.thisweek.FoodCategoryDescProt3;
            FoodItem.InsertFoodItem(typeForProt3, codeForProt3, descForProt3, res);
            col.Insert(FoodItem.getEntryfromTypeAndCode(typeForProt3, codeForProt3));

            string typeForVeggie1 = MyFoodWeek.thisweek.FoodCategoryTypeVeggies1;
            string codeForVeggie1 = MyFoodWeek.thisweek.FoodCategoryCodeVeggies1;
            string descForVeggie1 = MyFoodWeek.thisweek.FoodCategoryDescVeggies1;
            FoodItem.InsertFoodItem(typeForVeggie1, codeForVeggie1, descForVeggie1, res);
            col.Insert(FoodItem.getEntryfromTypeAndCode(typeForVeggie1, codeForVeggie1));

            string typeForVeggie2 = MyFoodWeek.thisweek.FoodCategoryTypeVeggies2;
            string codeForVeggie2 = MyFoodWeek.thisweek.FoodCategoryCodeVeggies2;
            string descForVeggie2 = MyFoodWeek.thisweek.FoodCategoryDescVeggies2;
            FoodItem.InsertFoodItem(typeForVeggie2, codeForVeggie2, descForVeggie2, res);
            col.Insert(FoodItem.getEntryfromTypeAndCode(typeForVeggie2, codeForVeggie2));

            string typeForVeggie3 = MyFoodWeek.thisweek.FoodCategoryTypeVeggies3;
            string codeForVeggie3 = MyFoodWeek.thisweek.FoodCategoryCodeVeggies3;
            string descForVeggie3 = MyFoodWeek.thisweek.FoodCategoryDescVeggies3;
            FoodItem.InsertFoodItem(typeForVeggie3, codeForVeggie3, descForVeggie3, res);
            col.Insert(FoodItem.getEntryfromTypeAndCode(typeForVeggie3, codeForVeggie3));


        }

        public static DateTime GetNextSunday()
        {
            DateTime res = DateTime.Now;
            if (res.DayOfWeek != DayOfWeek.Sunday)
            {

                if (res.DayOfWeek == DayOfWeek.Monday)
                {
                    res = res.AddDays(6);
                }
                if (res.DayOfWeek == DayOfWeek.Tuesday)
                {
                    res = res.AddDays(5);
                }
                if (res.DayOfWeek == DayOfWeek.Wednesday)
                {
                    res = res.AddDays(4);
                }
                if (res.DayOfWeek == DayOfWeek.Thursday)
                {
                    res = res.AddDays(3);
                }
                if (res.DayOfWeek == DayOfWeek.Friday)
                {
                    res = res.AddDays(2);
                }
                if (res.DayOfWeek == DayOfWeek.Saturday)
                {
                    res = res.AddDays(1);
                }
            }
            return res;
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
