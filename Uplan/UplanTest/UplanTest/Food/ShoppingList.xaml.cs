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
            var col = Database.db.GetCollection<FoodItem>("FoodItemsForList");
            //INSERT FOOD ITEM FOR EACH FOOD OF THIS WEEK
            // for the dueDate the idea is that for the next Sunday the food must be eaten (new food plan after that) 
            //-> we need to add the possibility to change all due Dates
            DateTime res = GetNextSunday();

            string typeForCarb1 = MyFoodWeek.thisweek.FoodforCategoryCarbchoix1.Type;
            string codeForCarb1 = MyFoodWeek.thisweek.FoodforCategoryCarbchoix1.Code;
            string descForCarb1 = MyFoodWeek.thisweek.FoodforCategoryCarbchoix1.Description;
            FoodItem.InsertFoodItem(typeForCarb1, codeForCarb1, descForCarb1, res);
            col.Insert(FoodItem.getEntryfromTypeAndCode(typeForCarb1, codeForCarb1));

            string typeForCarb2 = MyFoodWeek.thisweek.FoodforCategoryCarbchoix2.Type;
            string codeForCarb2 = MyFoodWeek.thisweek.FoodforCategoryCarbchoix2.Code;
            string descForCarb2 = MyFoodWeek.thisweek.FoodforCategoryCarbchoix2.Description;
            FoodItem.InsertFoodItem(typeForCarb2, codeForCarb2, descForCarb2, res);
            col.Insert(FoodItem.getEntryfromTypeAndCode(typeForCarb2, codeForCarb2));

            string typeForCarb3 = MyFoodWeek.thisweek.FoodforCategoryCarbchoix3.Type;
            string codeForCarb3 = MyFoodWeek.thisweek.FoodforCategoryCarbchoix3.Code;
            string descForCarb3 = MyFoodWeek.thisweek.FoodforCategoryCarbchoix3.Description;
            FoodItem.InsertFoodItem(typeForCarb3, codeForCarb3, descForCarb3, res);
            col.Insert(FoodItem.getEntryfromTypeAndCode(typeForCarb3, codeForCarb3));

            string typeForProt1 = MyFoodWeek.thisweek.FoodforCategoryProtchoix1.Type;
            string codeForProt1 = MyFoodWeek.thisweek.FoodforCategoryProtchoix1.Code;
            string descForProt1 = MyFoodWeek.thisweek.FoodforCategoryProtchoix1.Description;
            FoodItem.InsertFoodItem(typeForProt1, codeForProt1, descForProt1, res);
            col.Insert(FoodItem.getEntryfromTypeAndCode(typeForProt1, codeForProt1));

            string typeForProt2 = MyFoodWeek.thisweek.FoodforCategoryProtchoix2.Type;
            string codeForProt2 = MyFoodWeek.thisweek.FoodforCategoryProtchoix2.Code;
            string descForProt2 = MyFoodWeek.thisweek.FoodforCategoryProtchoix2.Description;
            FoodItem.InsertFoodItem(typeForProt2, codeForProt2, descForProt2, res);
            col.Insert(FoodItem.getEntryfromTypeAndCode(typeForProt2, codeForProt2));

            string typeForProt3 = MyFoodWeek.thisweek.FoodforCategoryProtchoix3.Type;
            string codeForProt3 = MyFoodWeek.thisweek.FoodforCategoryProtchoix3.Code;
            string descForProt3 = MyFoodWeek.thisweek.FoodforCategoryProtchoix3.Description;
            FoodItem.InsertFoodItem(typeForProt3, codeForProt3, descForProt3, res);
            col.Insert(FoodItem.getEntryfromTypeAndCode(typeForProt3, codeForProt3));

            string typeForVeggie1 = MyFoodWeek.thisweek.FoodforCategoryVeggieschoix1.Type;
            string codeForVeggie1 = MyFoodWeek.thisweek.FoodforCategoryVeggieschoix1.Code;
            string descForVeggie1 = MyFoodWeek.thisweek.FoodforCategoryVeggieschoix1.Description;
            FoodItem.InsertFoodItem(typeForVeggie1, codeForVeggie1, descForVeggie1, res);
            col.Insert(FoodItem.getEntryfromTypeAndCode(typeForVeggie1, codeForVeggie1));

            string typeForVeggie2 = MyFoodWeek.thisweek.FoodforCategoryVeggieschoix2.Type;
            string codeForVeggie2 = MyFoodWeek.thisweek.FoodforCategoryVeggieschoix2.Code;
            string descForVeggie2 = MyFoodWeek.thisweek.FoodforCategoryVeggieschoix2.Description;
            FoodItem.InsertFoodItem(typeForVeggie2, codeForVeggie2, descForVeggie2, res);
            col.Insert(FoodItem.getEntryfromTypeAndCode(typeForVeggie2, codeForVeggie2));

            string typeForVeggie3 = MyFoodWeek.thisweek.FoodforCategoryVeggieschoix3.Type;
            string codeForVeggie3 = MyFoodWeek.thisweek.FoodforCategoryVeggieschoix3.Code;
            string descForVeggie3 = MyFoodWeek.thisweek.FoodforCategoryVeggieschoix3.Description;
            FoodItem.InsertFoodItem(typeForVeggie3, codeForVeggie3, descForVeggie3, res);
            col.Insert(FoodItem.getEntryfromTypeAndCode(typeForVeggie3, codeForVeggie3));


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
            var col = Database.db.GetCollection<FoodItem>("FoodForShoppingList");
            col.DeleteAll();
        }
    }
}