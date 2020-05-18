using System;
using System.Collections.Generic;
using System.Text;

namespace UplanTest.MyExpenses
{

    
    class MyExpenses
    {
        public int Id { get; set; }

        public string Type { get; set; }
        public int Amount { get; set; }

        public static void Initiate()
        {
            // Get a collection (or create, if doesn't exist)
            var col = Database.db.GetCollection<MyExpenses>("Money");

            // Index document using these properties
            col.EnsureIndex(x => x.Type);
            col.EnsureIndex(x => x.Amount);


            col.Insert(
                new MyExpenses
                {
                    Type = "Workout 1",
                    Amount=0,
                }
             ); 
        }

        public static void InsertMoney(
                    int Amount,
                    String Type)
        {
            // Get a collection (or create, if doesn't exist)
            var col = Database.db.GetCollection<MyExpenses>("Money");

            // Index document using these properties
            col.EnsureIndex(x => x.Amount);
            col.EnsureIndex(x => x.Type);

            // Create initial data
            col.Insert(
                 new MyExpenses
                 {
                     Amount =Amount,
                     Type = Type
                 }
                 );

        }

        public static void ClearMoney(
                    int Amount,
                    String Type)
        {
            // Get a collection (or create, if doesn't exist)
            var col = Database.db.GetCollection<MyExpenses>("Money");
            
        }


    }
}
