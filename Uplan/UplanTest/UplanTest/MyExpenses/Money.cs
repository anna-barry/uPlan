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
        public int Max { get; set; }

        public static void Initiate()
        {
            // Get a collection (or create, if doesn't exist)
            var col = Database.db.GetCollection<MyExpenses>("Money");
       

            // Index document using these properties
            col.EnsureIndex(x => x.Type);
            col.EnsureIndex(x => x.Amount);
            col.EnsureIndex(x => x.Max);


            col.Insert(
                new MyExpenses
                {
                    Type = "",
                    Amount=0,
                    Max=0,
                }
             ); 
        }

        public static void InsertMoney(
                    int Amount,
                    int Max,
                    String Type)
        {
            // Get a collection (or create, if doesn't exist)
            var col = Database.db.GetCollection<MyExpenses>("Money");
             var get = 

            // Index document using these properties
            col.EnsureIndex(x => x.Amount);
            col.EnsureIndex(x => x.Type);
            col.EnsureIndex(x => x.Max);

            // Create initial data
            col.Insert(
                 new MyExpenses
                 {
                     Amount =Amount,
                     Type = Type,
                     Max=Max,
                 }
                 );

        }

        public static void ClearMoney(
                    int Amount,
                    int Max,
                    String Type)
        {
            var col = Database.db.GetCollection<MyExpenses>("Money");
            col.DeleteAll();
        }


    }
}
