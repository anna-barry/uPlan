using System;
using System.Collections.Generic;
using System.Text;
using LiteDB;

namespace UplanTest
{
    public class Food
    {
        // ----------------------------------------------------
        // Collection document fields:
       
        public int Id { get; set; }

        [BsonRef("Users")] // "Users" is the collection to be referenced
        public User FoodWeekForUser { get; set; }

        // ----------------------------------------------------
        // Protein:

        [BsonRef("ListEntries")] // "ListEntriesFood" is the collection to be referenced
        private ListEntry FoodforCategoryProtchoix1 { get; set; }

        [BsonRef("ListEntries")] // "ListEntriesFood" is the collection to be referenced
        private ListEntry FoodforCategoryProtchoix2 { get; set; }

        [BsonRef("ListEntries")] // "ListEntriesFood" is the collection to be referenced
        private ListEntry FoodforCategoryProtchoix3 { get; set; }

        // ----------------------------------------------------
        // Carb:

        [BsonRef("ListEntries")]
        private ListEntry FoodforCategoryCarbchoix1 { get; set; }

        [BsonRef("ListEntries")]
        private ListEntry FoodforCategoryCarbchoix2 { get; set; }

        [BsonRef("ListEntries")]
        private ListEntry FoodforCategoryCarbchoix3 { get; set; }

        // ----------------------------------------------------
        // Veggies:

        [BsonRef("ListEntries")]
        private ListEntry FoodforCategoryVeggieschoix1 { get; set; }

        [BsonRef("ListEntries")]
        private ListEntry FoodforCategoryVeggieschoix2 { get; set; }

        [BsonRef("ListEntries")]
        private ListEntry FoodforCategoryVeggieschoix3 { get; set; }

        //public string Description { get; set; }
        //public Boolean IsComplete { get; set; }
        //public DateTime DueDate { get; set; }
        public DateTime CompletionDate { get; set; }

        // ----------------------------------------------------
        // "Calculated" property methods:

        public string FoodCategoryDescProt1 { get { return ListEntry.getDescfromEntry(FoodforCategoryProtchoix1); } }
        public string FoodCategoryDescProt2 { get { return ListEntry.getDescfromEntry(FoodforCategoryProtchoix2); } }
        public string FoodCategoryDescProt3 { get { return ListEntry.getDescfromEntry(FoodforCategoryProtchoix3); } }
        public string FoodCategoryDescCarb1 { get { return ListEntry.getDescfromEntry(FoodforCategoryCarbchoix1); } }
        public string FoodCategoryDescCarb2 { get { return ListEntry.getDescfromEntry(FoodforCategoryCarbchoix2); } }
        public string FoodCategoryDescCarb3 { get { return ListEntry.getDescfromEntry(FoodforCategoryCarbchoix3); } }
        public string FoodCategoryDescVeggies1 { get { return ListEntry.getDescfromEntry(FoodforCategoryVeggieschoix1); } }
        public string FoodCategoryDescVeggies2 { get { return ListEntry.getDescfromEntry(FoodforCategoryVeggieschoix2); } }
        public string FoodCategoryDescVeggies3 { get { return ListEntry.getDescfromEntry(FoodforCategoryVeggieschoix3); } }

        // ----------------------------------------------------

        public static void Initiate()
        {
            var col = Database.db.GetCollection<Food>("EntriesforFood");
            
            col.EnsureIndex(x => x.FoodWeekForUser);
            col.EnsureIndex(x => x.FoodCategoryDescProt1);
            col.EnsureIndex(x => x.FoodCategoryDescProt2);
            col.EnsureIndex(x => x.FoodCategoryDescProt3);
            col.EnsureIndex(x => x.FoodCategoryDescCarb1);
            col.EnsureIndex(x => x.FoodCategoryDescCarb2);
            col.EnsureIndex(x => x.FoodCategoryDescCarb3);
            col.EnsureIndex(x => x.FoodCategoryDescVeggies1);
            col.EnsureIndex(x => x.FoodCategoryDescVeggies2);
            col.EnsureIndex(x => x.FoodCategoryDescVeggies3);
            //col.EnsureIndex(x => x.IsComplete);
            //col.EnsureIndex(x => x.DueDate);

            col.Insert(
                new Food
                {
                    FoodWeekForUser = MyUser.me,
                    FoodforCategoryProtchoix1 = ListEntry.getEntryfromTypeAndCode("PROTEIN", "LENTILS"),
                    FoodforCategoryProtchoix2 = ListEntry.getEntryfromTypeAndCode("PROTEIN", "GAMBAS"),
                    FoodforCategoryProtchoix3 = ListEntry.getEntryfromTypeAndCode("PROTEIN", "BEEF"),
                    FoodforCategoryCarbchoix1 = ListEntry.getEntryfromTypeAndCode("CARB", "PASTA"),
                    FoodforCategoryCarbchoix2 = ListEntry.getEntryfromTypeAndCode("CARB", "WHOLE_PASTA"),
                    FoodforCategoryCarbchoix3 = ListEntry.getEntryfromTypeAndCode("CARB", "SWEET_POTATO"),
                    FoodforCategoryVeggieschoix1 = ListEntry.getEntryfromTypeAndCode("VEGGIES", "BROCCOLI"),
                    FoodforCategoryVeggieschoix2 = ListEntry.getEntryfromTypeAndCode("VEGGIES", "BUTTERNUT"),
                    FoodforCategoryVeggieschoix3 = ListEntry.getEntryfromTypeAndCode("VEGGIES", "BEETROOT"),

                    
                }
                ) ;
        }
        
        /*public static List<Food> GetAllFood()
        {
            List<Food> res = new List<Food>();
            var col = Database.db.GetCollection<Food>("EntriesforFood");
            var result = col.Find(Query.All());

            foreach (var test in result)
            {
                res.Add(test);
            }
            return res;

        }*/

        public void InsertFood(
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
            // Get a collection (or create, if doesn't exist)
            var col = Database.db.GetCollection<Food>("EntriesforFood");
            Food foodthisweek = col.FindById(Id);

            col.EnsureIndex(x => x.FoodCategoryDescProt1);
            col.EnsureIndex(x => x.FoodCategoryDescProt2);
            col.EnsureIndex(x => x.FoodCategoryDescProt3);
            col.EnsureIndex(x => x.FoodCategoryDescCarb1);
            col.EnsureIndex(x => x.FoodCategoryDescCarb2);
            col.EnsureIndex(x => x.FoodCategoryDescCarb3);
            col.EnsureIndex(x => x.FoodCategoryDescVeggies1);
            col.EnsureIndex(x => x.FoodCategoryDescVeggies2);
            col.EnsureIndex(x => x.FoodCategoryDescVeggies3);
            //col.EnsureIndex(x => x.IsComplete);
            //col.EnsureIndex(x => x.DueDate);

            /*col.Insert(
                 new Food
                 {
                     
                     FoodforCategoryProtchoix1 = FoodforCategoryProtchoix1,
                     FoodforCategoryProtchoix2 = FoodforCategoryProtchoix2,
                     FoodforCategoryProtchoix3 = FoodforCategoryProtchoix3,
                     FoodforCategoryCarbchoix1 = FoodCategoryCarbchoix1,
                     FoodforCategoryCarbchoix2 = FoodCategoryCarbchoix2,
                     FoodforCategoryCarbchoix3 = FoodCategoryCarbchoix3,
                     FoodforCategoryVeggieschoix1 = FoodCategoryVeggieschoix1,
                     FoodforCategoryVeggieschoix2 = FoodCategoryVeggieschoix2,
                     FoodforCategoryVeggieschoix3 = FoodCategoryVeggieschoix3,

                     
                 }
                 );*/

            foodthisweek.FoodforCategoryProtchoix1 = FoodforCategoryProtchoix1;
            foodthisweek.FoodforCategoryProtchoix2 = FoodforCategoryProtchoix2;
            foodthisweek.FoodforCategoryProtchoix3 = FoodforCategoryProtchoix3;
            foodthisweek.FoodforCategoryCarbchoix1 = FoodCategoryCarbchoix1;
            foodthisweek.FoodforCategoryCarbchoix2 = FoodCategoryCarbchoix2;
            foodthisweek.FoodforCategoryCarbchoix3 = FoodCategoryCarbchoix3;
            foodthisweek.FoodforCategoryVeggieschoix1 = FoodCategoryVeggieschoix1;
            foodthisweek.FoodforCategoryVeggieschoix2 = FoodCategoryVeggieschoix2;
            foodthisweek.FoodforCategoryVeggieschoix3 = FoodCategoryVeggieschoix3;

            // And call collection update to commit changes
            col.Update(foodthisweek);
        }

        public Food()
        {
        }
    }
}
