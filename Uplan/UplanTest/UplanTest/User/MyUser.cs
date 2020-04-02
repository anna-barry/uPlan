using System;
using System.Collections.Generic;
using System.Text;
using LiteDB;

namespace UplanTest
{
    // This call is static and is to make easy call for the current user.
    // For example, in rest of code can reference MyUser.me.Name, MyUser.me.EmailAddress, MyUser.me.ShoppingDayDesc etc...
    // The Initiate call is done in Database.Initiate and it will be called in User.UpdateMyUser.
    
    public static class MyUser
    {
        public static User me;
        public static bool isDefault; // set to true in Database.Initiate if creating new database and this is the default user (so needs to be updated by user)

        public static void Initiate()
        {
            var col = Database.db.GetCollection<User>("Users");
            // Use FindOne and not Find as we should have only one
            me = col.FindOne(Query.All());
        }

        public static void Update(
           string uName, string uEmailAddress, ListEntry uAccomodationType,
           string uShoppingDay, string uCleaningDay)

        {
            me.UpdateUser(uName, uEmailAddress, uAccomodationType, uShoppingDay, uCleaningDay);

            // Keep MyUser static variables up to date after this database update
            Initiate();
        }
    }
}
