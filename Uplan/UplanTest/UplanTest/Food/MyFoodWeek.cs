using System;
using System.Collections.Generic;
using System.Text;
using LiteDB;

namespace UplanTest
{
    
    public static class MyFoodWeek
    {
        public static Food thisweek;
        public static bool isDefault;
        public static void Initiate()
        {
            var col = Database.db.GetCollection<Food>("EntriesforFood");
            // Use FindOne and not Find as we should have only one
            thisweek = col.FindOne(Query.All());
            //thisweek=col.FindAll

            //string liltest = thisweek.FoodCategoryDescCarb1;
        }
        
        public static void UpdateFood(
            ListEntry FoodforCategoryProtchoix1,
            ListEntry FoodforCategoryProtchoix2,
            ListEntry FoodforCategoryProtchoix3,
            ListEntry FoodCategoryCarbchoix1,
            ListEntry FoodCategoryCarbchoix2,
            ListEntry FoodCategoryCarbchoix3,
            ListEntry FoodCategoryVeggieschoix1,
            ListEntry FoodCategoryVeggieschoix2,
            ListEntry FoodCategoryVeggieschoix3)
        {
            
            thisweek.InsertFood(FoodforCategoryProtchoix1, FoodforCategoryProtchoix2, FoodforCategoryProtchoix3,
             FoodCategoryCarbchoix1, FoodCategoryCarbchoix2, FoodCategoryCarbchoix3, FoodCategoryVeggieschoix1,
             FoodCategoryVeggieschoix2, FoodCategoryVeggieschoix3);

            Initiate();


        }

 

    }
}
