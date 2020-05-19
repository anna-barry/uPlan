using LiteDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace UplanTest.MyExpenses
{

    
    class Money
    {
        public int Id { get; set; }

        public string Type { get; set; }
        public int Amount { get; set; }
        public int Max { get; set; }

        public static void Initiate()
        {
            // Get a collection (or create, if doesn't exist)
            var col = Database.db.GetCollection<Money>("Money");

            // Index document using these properties
            col.EnsureIndex(x => x.Type);
            col.EnsureIndex(x => x.Amount);
            col.EnsureIndex(x => x.Max);


            col.Insert(
                new Money
                {
                    Type = "Food",
                    Amount=0,
                    Max=0,
                }
             );

            col.Insert(
                new Money
                {
                    Type = "Going Out",
                    Amount = 0,
                    Max = 0,
                }
             );
            col.Insert(
                new Money
                {
                    Type = "Clothes and accessories",
                    Amount = 0,
                    Max = 0,
                }
             );

            col.Insert(
                new Money
                {
                    Type = "Health",
                    Amount = 0,
                    Max = 0,
                }
             );
            col.Insert(
                new Money
                {
                    Type = "Hobbies",
                    Amount = 0,
                    Max = 0,
                }
             );
            col.Insert(
                new Money
                {
                    Type = "Other",
                    Amount = 0,
                    Max = 0,
                }
             );
        }

        public static void AddMoney(
                    int Amount,
                    int Max,
                    String Type)
        {
            // Get a collection (or create, if doesn't exist)
            var col = Database.db.GetCollection<Money>("Money");
            var res = col.FindOne(Query.EQ("Type", Type));
            res.Amount += Amount;
            res.Max = Max;
        }

        public static void ResestMoney()
        {
            var col = Database.db.GetCollection<Money>("Money");
            col.DeleteAll();
            Initiate();
        }


    }
}
