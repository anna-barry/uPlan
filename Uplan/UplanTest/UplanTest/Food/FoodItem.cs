using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Xml;
using LiteDB;
using Xamarin.Forms;

namespace UplanTest
{
    public class FoodItem
    {
        //___________________ ATTRIBUTS DE LA CLASS _____________________
        //_______________________________________________________________

        public int Id { get; set; }
        public string Type { get; set; }
        public string NameCode { get; set; }
        public string NameDesc { get; set; }
        public DateTime DueDate { get; set; }
        public int Amount { get; set; }

        //________________________________________________________________
        //________________________________________________________________

        public static void Initiate()
        {
            // Get a collection (or create, if doesn't exist)
            var col = Database.db.GetCollection<FoodItem>("FoodItems");

            // Index document using these properties
            col.EnsureIndex(x => x.Id);
            col.EnsureIndex(x => x.Type);
            col.EnsureIndex(x => x.NameCode);
            col.EnsureIndex(x => x.NameDesc);
            col.EnsureIndex(x => x.DueDate);
            col.EnsureIndex(x => x.Amount);

            /* Create initial data*/
            col.Insert(
                new FoodItem
                {
                    Type = "CARB",
                    NameCode = "POTATO",
                    NameDesc = "Potato",
                    DueDate = DateTime.Now.AddDays(-1),
                    Amount = 1

                }
             ) ;
        }

        public static void InsertFoodItem(string type,string NameCode, string NameDesc, DateTime Duedate, int amount)
        {

            // Get a collection (or create, if doesn't exist)
            var col = Database.db.GetCollection<FoodItem>("FoodItems");

            // Index document using these properties
            col.EnsureIndex(x => x.Id);
            col.EnsureIndex(x => x.Type);
            col.EnsureIndex(x => x.NameCode);
            col.EnsureIndex(x => x.NameDesc);
            col.EnsureIndex(x => x.DueDate);
            col.EnsureIndex(x => x.Amount);

            col.Insert(
                new FoodItem
                {
                    Type = type,
                    NameCode = NameCode,
                    NameDesc = NameDesc,
                    DueDate = Duedate,
                    Amount=amount

                }
             );
        }
        public static FoodItem getEntryfromTypeAndCode(string Type, string Code)
        {
            var col = Database.db.GetCollection<FoodItem>("FoodItems"); 
            // Use FindOne and not Find as we should have only one
            var result = col.FindOne(Query.And(Query.EQ("NameCode", Code), Query.EQ("Type", Type)));

            return result;
        }

        public static string getDescfromTypeAndCode(string Type, string Code)
        {
            var col = Database.db.GetCollection<FoodItem>("FoodItems");
            // Use FindOne and not Find as we should have only one
            var result = col.FindOne(Query.And(Query.EQ("NameCode", Code), Query.EQ("Type", Type)));

            return result.NameDesc;
        }
        public static string getDescfromType(string Type)
        {
            var col = Database.db.GetCollection<FoodItem>("FoodItems");
            // Use FindOne and not Find as we should have only one
            var result = col.FindOne(Query.EQ("Type", Type));

            return result.NameDesc;
        }


        public static string getDescfromEntry(FoodItem entry)
        {
            var col = Database.db.GetCollection<FoodItem>("FoodItems");
            var result = col.FindById(entry.Id);

            return result.NameDesc;
        }

        public static string getCodefromEntry(FoodItem entry)
        {
            var col = Database.db.GetCollection<FoodItem>("FoodItems");
            var result = col.FindById(entry.Id);

            return result.NameCode;
        }
        public FoodItem()
        {
        }
        /*public static void test()
        {

            var col = Database.db.GetCollection<FoodItem>("FoodItems");
            foreach (var item in col.FindAll())
            {
                string nomboutton = Convert.ToString(item.Id);
                Button a = new Button();
            }
               
        }*/
    }
}
