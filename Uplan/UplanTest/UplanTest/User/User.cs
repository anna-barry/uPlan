using System;
using LiteDB;

namespace UplanTest
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [BsonRef("ListEntries")] // "ListEntries" is the collection to be referenced
        public ListEntry AccomodationType { get; set; }

        public string EmailAddress { get; set; }
        public string ShoppingDay { get; set; }
        public string CleaningDay { get; set; }

        // not in DB collection ("calculated" columns)
        public string ShoppingDayDesc {
            get { return getDescFromDay(ShoppingDay); }  //   set { ShoppingDayDesc = value; }
        }
        public string CleaningDayDesc
        {
            get { return getDescFromDay(CleaningDay); }  
        }
        public string AccomodationTypeDesc
        {
            get { return ListEntry.getDescfromEntry(AccomodationType); }  
        }

        private string getDescFromDay(string day)
        {
            string res;

            switch (day)
                {
                    case "MON":
                    res = "Monday";
                    break;
                   
                    case "TUE":
                    res = "Tuesday";
                    break;

                    case "WED":
                    res = "Wendesday";
                    break;

                    case "THU":
                    res = "Thursday";
                    break;

                    case "FRI": res= "Friday";
                    break;

                    case "SAT": res= "Saturday";
                    break;

                    case "SUN": res= "Sunday";
                    break;
                default:
                    return "invalid: " + ShoppingDay;
            }
            return res;
        }

        public static void Initiate()
        {
            // Get a collection (or create, if doesn't exist)
            var col = Database.db.GetCollection<User>("Users");

            // Index document using these properties
            //col.EnsureIndex(x => x.AccomodationType);

           /* Create initial data*/
            col.Insert(
                new User
                {
                    Name = "User Name",
                    AccomodationType = ListEntry.getEntryfromTypeAndCode("ACCOMODATION_TYPES", "ALONE"),
                    EmailAddress = "user.name@epita.fr",
                    ShoppingDay = "MON", // Lundi
                    CleaningDay = "SAT"
                }
             ); 
        }

        public static string GetLoginMessage()
        {
            var col = Database.db.GetCollection<User>("Users");
            // Use FindOne and not Find as we should have only one
            var result = col.FindOne(Query.All());

            if (result == null) { return "No User means no User information!";  }

            var openTasks = Database.db.GetCollection<SchoolTask>("SchoolTasks").Count();

            // à insérer: ce qu'il ya niveau dates de péremption

            return "Hello there " + result.Name + ", I now know that you go shopping on " + result.ShoppingDayDesc + "s"+
                " and that you clean where you live on " + result.CleaningDayDesc + "s and you live in an accomodation of type " + result.AccomodationTypeDesc +
                " and that you have " + (openTasks-1) + " open task(s)!";
        }


        public static string GetInfoForMe()
        {
            var col = Database.db.GetCollection<User>("Users");
           
            var result = col.FindOne(Query.All());
            if (result == null) { return "No User means no User information!"; }
            

            return "Name: " + result.Name +"\n" + "Shopping day: " + result.ShoppingDayDesc + "\n" +
              "Cleaning Day: " + result.CleaningDayDesc + "\n" + "Accomodation type: " + result.AccomodationTypeDesc;

        }

        public void UpdateUser(
            string uName, string uEmailAddress, ListEntry uAccomodationType, 
            string uShoppingDay, string uCleaningDay
            )
        {
            var col = Database.db.GetCollection<User>("Users");
            // Get collection for this user id.
            User user = col.FindById(Id);
            
            // Now update each column in collection
            user.Name = uName;
            user.EmailAddress = uEmailAddress;
            user.AccomodationType = uAccomodationType;
            user.ShoppingDay = uShoppingDay;
            user.CleaningDay = uCleaningDay;

            // And call collection update to commit changes
            col.Update(user);
        }
        public User()
        {
        }
    }
}
