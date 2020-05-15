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

        public string Type { get; set; }
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

        public static void Initiate()
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
            col.EnsureIndex(x => x.Type);


            col.Insert(
                new Workout
                {

                    Exercice1 = ListEntry.getEntryfromTypeAndCode("Abs1", "JumpSquat"),
                    Exercice2 = ListEntry.getEntryfromTypeAndCode("Abs1", "PushUps"),
                    Exercice3 = ListEntry.getEntryfromTypeAndCode("Abs1", "JumpingLunges"),
                    Exercice4 = ListEntry.getEntryfromTypeAndCode("Abs1", "Punches"),
                    Exercice5 = ListEntry.getEntryfromTypeAndCode("Abs1", "Plank"),
                    Exercice6 = ListEntry.getEntryfromTypeAndCode("Abs1", "Lunge"),
                    Exercice7 = ListEntry.getEntryfromTypeAndCode("Abs1", "SideLunge"),
                    Exercice8 = ListEntry.getEntryfromTypeAndCode("Abs1", "Squat"),
                    Exercice9 = ListEntry.getEntryfromTypeAndCode("Abs1", "JumpSquat"),
                    Exercice10 = ListEntry.getEntryfromTypeAndCode("Abs1", "PushUps"),
                    Type = "Workout 1",
                    DueDate = DateTime.Now.AddDays(-1),


                }
             ); 
        }


        public static IEnumerable<Workout> getEntriesfromDay(DateTime day)
        {
            var col = Database.db.GetCollection<Workout>("AllWorkouts");
            // Use FindOne and not Find as we should have only one
            var result = col.Find(Query.EQ("DueDate", day));

            return result;
        }

        public static void InsertWorkout(
                    ListEntry ex1,
                    ListEntry ex2,
                    ListEntry ex3,
                    ListEntry ex4,
                    ListEntry ex5,
                    ListEntry ex6,
                    ListEntry ex7,
                    ListEntry ex8,
                    ListEntry ex9,
                    ListEntry ex10,
                    DateTime DueDate,
                    String Type)
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
            col.EnsureIndex(x => x.Type);

            // Create initial data
            col.Insert(
                 new Workout
                 {
                     Exercice1=ex1,
                     Exercice2=ex2,
                     Exercice3=ex3,
                     Exercice4=ex4,
                     Exercice5=ex5,
                     Exercice6=ex6,
                     Exercice7=ex7,
                     Exercice8=ex8,
                     Exercice9=ex9,
                     Exercice10=ex10,
                     DueDate = DueDate,
                     Type=Type
                 }
                 );

        }

        public Workout()
        {
        }
    }
}
