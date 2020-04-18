using System;
using System.Collections.Generic;
using System.Text;
using LiteDB;

namespace UplanTest
{
    public class FoodItem
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string NameCode { get; set; }
        public string NameDesc { get; set; }
        public DateTime DueDate { get; set; }

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

            /* Create initial data*/
            col.Insert(
                new FoodItem
                {
                    Type="CARB",
                    NameCode="POTATO",
                    NameDesc="Potato",
                    DueDate=DateTime.Now.AddDays(-1)

                }
             );
        }

        public static void InsertFoodItem(string type,string NameCode, string NameDesc, DateTime Duedate)
        {

            // Get a collection (or create, if doesn't exist)
            var col = Database.db.GetCollection<FoodItem>("FoodItems");

            // Index document using these properties
            col.EnsureIndex(x => x.Id);
            col.EnsureIndex(x => x.Type);
            col.EnsureIndex(x => x.NameCode);
            col.EnsureIndex(x => x.NameDesc);
            col.EnsureIndex(x => x.DueDate);

            col.Insert(
                new FoodItem
                {
                    Type = type,
                    NameCode = NameCode,
                    NameDesc = NameDesc,
                    DueDate = Duedate

                }
             );
        }

        public FoodItem()
        {
        }
    }
}
