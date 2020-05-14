using LiteDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace UplanTest
{
    class Workout
    {
        //___________________ ATTRIBUTS DE LA CLASS _____________________
        //_______________________________________________________________

        public int Id { get; set; }

        public ListEntry Exercice1 { get; set; }
        public ListEntry Exercice2 { get; set; }
        public ListEntry Exercice3 { get; set; }
        public ListEntry Exercice4 { get; set; }
        public ListEntry Exercice5 { get; set; }
        public ListEntry Exercice6 { get; set; }
        public ListEntry Exercice7 { get; set; }
        public ListEntry Exercice8 { get; set; }
        public ListEntry Exercice9 { get; set; }
        public ListEntry Exercice10 { get; set; }

        public DateTime DueDate { get; set; }

        //________________________________________________________________
        //________________________________________________________________

        /*public static void Initiate()
        {
            // Get a collection (or create, if doesn't exist)
            var col = Database.db.GetCollection<Workout>("AllWorkouts");

            // Index document using these properties
            col.EnsureIndex(x => x.Exercice1);
            col.EnsureIndex(x => x.Exercice2);
            col.EnsureIndex(x => x.Exercice3);
            col.EnsureIndex(x => x.Exercice4);
            col.EnsureIndex(x => x.Exercice5);
            col.EnsureIndex(x => x.Exercice6);
            col.EnsureIndex(x => x.Exercice7);
            col.EnsureIndex(x => x.Exercice8);
            col.EnsureIndex(x => x.Exercice9);
            col.EnsureIndex(x => x.Exercice10);
            col.EnsureIndex(x => x.DueDate);
            ListEntry.getEntryfromTypeAndCode()
            /* Create initial data
            col.Insert(
                new Workout
                {
                   
                    Type = "CARB",
                    NameCode = "POTATO",
                    NameDesc = "Potato",
                    DueDate = DateTime.Now.AddDays(-1),
                    Amount = 1

                }
             );
        }*/


        public static IEnumerable<Workout> getEntriesfromDay(DateTime day)
        {
            var col = Database.db.GetCollection<Workout>("AllWorkouts");
            // Use FindOne and not Find as we should have only one
            var result = col.Find(Query.EQ("DueDate", day));

            return result;
        }
        public Workout()
        {
        }
    }
}
