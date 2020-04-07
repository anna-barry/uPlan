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
                Food.Initiate();
                MyFoodWeek.Initiate();
                ListEntryYOGA.Initiate();

                MyUser.isDefault = true;
            }

            MyUser.Initiate();
        }
    }
}
