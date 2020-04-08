using System;
using System.IO;
using LiteDB;

namespace UplanTest
{
    public static class Database
    {
        public static LiteDatabase db;

        public static void Initiate()
        {
            //db = new LiteDatabase(@Constants.appDbFilename);
            db = new LiteDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), Constants.appDbFilename));

            // Si la base est vide il faut créer les collections et données de depart.
            // Vérifier lignes en users > 0 pour cela.

            var users = db.GetCollection<User>("Users");
            if (users.Count() == 0)
            {
                ListEntry.Initiate();
                User.Initiate();
                SchoolTask.Initiate();
                ListEntryForFood.Initiate();
                //Food.Initiate();
               // MyFoodWeek.Initiate();
                ListEntryYOGA.Initiate();

                MyUser.isDefault = true;
            }
            
           /* var col = db.GetCollection<RowClass>("Collection");
            var data_list = col.Find(Query.All(), 0, 20);

            foreach (var row in data_list) 
            {
                col.Delete(row.Id);
                data_return.Add(row);
            }*/
             
         
            var foodweek =db.GetCollection<Food>("EntriesforFood");
            /*var data_list = foodweek.Find(Query.All(), 0, 20);
            foreach (var row in data_list)
            {
                foodweek.Delete(row.Id);
                
            }
            */
            
            var col = Database.db.GetCollection<Food>("EntriesforFood");
            // Use FindOne and not Find as we should have only one
            //thisweek = col.FindOne(Query.All());
            
            
            
            // var liltest = testweek.FoodCategoryDescCarb1; 
            var sizetest = foodweek.Count();
            var testweek = foodweek.FindOne(Query.All());
            if (sizetest==0)
            {
                MyFoodWeek.isDefault = true;
                Food.Initiate();
            }

            MyUser.Initiate();
            MyFoodWeek.Initiate();
        }
    }
}
