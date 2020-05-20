using LiteDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace UplanTest
{

    
    class Money
    {
        public int Id { get; set; }

        public string Type { get; set; }
        public float Amount { get; set; }
        public string Description { get; set; }

        public static void Initiate()
        {
            // Get a collection (or create, if doesn't exist)
            var col = Database.db.GetCollection<Money>("Money");

            // Index document using these properties
            col.EnsureIndex(x => x.Type);
            col.EnsureIndex(x => x.Amount);
            col.EnsureIndex(x => x.Description);


            col.Insert(
                new Money
                {
                    Type = "Food",
                    Amount=0,
                    Description="",
                }
             );

            col.Insert(
                new Money
                {
                    Type = "Going Out",
                    Amount = 0,
                    Description = "",
                }
             );
            col.Insert(
                new Money
                {
                    Type = "Clothes and accessories",
                    Amount = 0,
                    Description = "",
                }
             );

            col.Insert(
                new Money
                {
                    Type = "Health",
                    Amount = 0,
                    Description = "",
                }
             );
            col.Insert(
                new Money
                {
                    Type = "Hobbies",
                    Amount = 0,
                    Description = "",
                }
             );
            col.Insert(
                new Money
                {
                    Type = "Other",
                    Amount = 0,
                    Description = "",
                }
             );
        }

        public static void AddMoney(
                    float Amount,
                    string Description,
                    String Type)
        {
            // Get a collection (or create, if doesn't exist)
            var col = Database.db.GetCollection<Money>("Money"); col.Insert(
                 new Money
                 {
                     Type = Type,
                     Amount = Amount,
                     Description = Description,
                 }
              );
        }

        public static void ResestMoney()
        {
            var col = Database.db.GetCollection<Money>("Money");
            col.DeleteAll();
            Initiate();
        }


    }
}
