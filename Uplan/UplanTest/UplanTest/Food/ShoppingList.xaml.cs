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
        public static void GetShoppinForWeek()
        {
            var col = Database.db.GetCollection<FoodItem>("FoodItems");
            //INSERT FOOD ITEM FOR EACH FOOD OF THIS WEEK
            // for the dueDate the idea is that for the next Sunday the food must be eaten (new food plan after that) 
            //-> we need to add the possibility to change all due Dates

            string typeForCarb1 = MyFoodWeek.thisweek.FoodforCategoryCarbchoix1.Type;
            string codeForCarb1 = MyFoodWeek.thisweek.FoodforCategoryCarbchoix1.Code;
            string descForCarb1 = MyFoodWeek.thisweek.FoodforCategoryCarbchoix1.Description;
            DateTime resCarb1 = GetNextSunday();
            FoodItem.InsertFoodItem(typeForCarb1, codeForCarb1, descForCarb1, resCarb1);
            
        }

        public static DateTime GetNextSunday()
        {
            DateTime res = DateTime.Now;
            if(res.DayOfWeek!=DayOfWeek.Sunday)
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
        public static void RefreshFoodItems()
        {
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