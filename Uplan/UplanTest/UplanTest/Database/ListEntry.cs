using System;
using LiteDB;

namespace UplanTest
{
    public class ListEntry
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
       

        public static void Initiate()
        {
            // Get a collection (or create, if doesn't exist)
            var col = Database.db.GetCollection<ListEntry>("ListEntries");

            // Index document using these properties
            col.EnsureIndex(x => x.Type);
            col.EnsureIndex(x => x.Code);

            // Create initial data

            col.Insert(new ListEntry { Type = "COLOURS", Code = "WHITE", Description = "White" });
            col.Insert(new ListEntry { Type = "COLOURS", Code = "BLUE", Description = "Blue" });
            col.Insert(new ListEntry { Type = "COLOURS", Code = "GREEN", Description = "Green" });
            col.Insert(new ListEntry { Type = "COLOURS", Code = "RED", Description = "Red" });
            col.Insert(new ListEntry { Type = "COLOURS", Code = "PURPLE", Description = "Purple" });
            col.Insert(new ListEntry { Type = "COLOURS", Code = "BEIGE", Description = "Beige" });
            col.Insert(new ListEntry { Type = "COLOURS", Code = "BLUEVIOLET", Description = "Blue Violet" });
            col.Insert(new ListEntry { Type = "COLOURS", Code = "BROWN", Description = "Brown" });
            col.Insert(new ListEntry { Type = "COLOURS", Code = "CORAL", Description = "Coral" });
            col.Insert(new ListEntry { Type = "COLOURS", Code = "DARKBLUE", Description = "Dark blue" });
            col.Insert(new ListEntry { Type = "COLOURS", Code = "DARKMAGERNTA", Description = "Dark Magenta" });
            col.Insert(new ListEntry { Type = "COLOURS", Code = "FORESTGREEN", Description = "Forest Green" });
            col.Insert(new ListEntry { Type = "COLOURS", Code = "FUCHSIA", Description = "Fuchsia" });
            col.Insert(new ListEntry { Type = "COLOURS", Code = "GOLD", Description = "Gold" });
            col.Insert(new ListEntry { Type = "COLOURS", Code = "GRAY", Description = "Gray" });
            col.Insert(new ListEntry { Type = "COLOURS", Code = "GREEN", Description = "Green" });

            col.Insert(new ListEntry { Type = "ACCOMODATION_TYPES", Code = "ALONE", Description = "Alone in flat" });
            col.Insert(new ListEntry { Type = "ACCOMODATION_TYPES", Code = "SHARING", Description = "With roomate" });
            col.Insert(new ListEntry { Type = "ACCOMODATION_TYPES", Code = "PARENTS", Description = "With your parents" });

            col.Insert(new ListEntry { Type = "TASK_CATEGORIES", Code = "PERSONAL", Description = "Personal" });
           //col.Insert(new ListEntry { Type = "TASK_CATEGORIES", Code = "WELL_BEING", Description = "Bien-être" });
            col.Insert(new ListEntry { Type = "TASK_CATEGORIES", Code = "SCHOOL", Description = "School" });

            col.Insert(new ListEntry { Type = "TASK_COMPLEXITIES", Code = "LOW", Description = "1-Low" });
            col.Insert(new ListEntry { Type = "TASK_COMPLEXITIES", Code = "MEDIUM", Description = "2-Average" });
            col.Insert(new ListEntry { Type = "TASK_COMPLEXITIES", Code = "HIGH", Description = "3-High" });
            col.Insert(new ListEntry { Type = "TASK_COMPLEXITIES", Code = "VERY_HIGH", Description = "4-Very High" });

            //TYPE OF TASK WHEN SCHOOL
            col.Insert(new ListEntry { Type = "TASK_SUBTYPE_SC", Code = "BY_HEART", Description = "By heart" });
            col.Insert(new ListEntry { Type = "TASK_SUBTYPE_SC", Code = "EXERCICE", Description = "Small exercise" });
            col.Insert(new ListEntry { Type = "TASK_SUBTYPE_SC", Code = "PROJECT", Description = "Big project" });

            //TYPE OF TASK WHEN PERSONAL
            col.Insert(new ListEntry { Type = "TASK_SUBTYPE_PERS", Code = "HEALTH", Description = "Health appointment" });
            col.Insert(new ListEntry { Type = "TASK_SUBTYPE_PERS", Code = "SPORT", Description = "Sport" });
            col.Insert(new ListEntry { Type = "TASK_SUBTYPE_PERS", Code = "SOCIAL_LIFE", Description = "Social life" });
            col.Insert(new ListEntry { Type = "TASK_SUBTYPE_PERS", Code = "HOBIES", Description = "Hobies" });


            /* Well-being
            col.Insert(new ListEntry { Type = "MEDICAL", Code = "BY_HEART", Description = "By heart" }); */

        }

        public static ListEntry getEntryfromTypeAndCode(string Type, string Code)
        {
            var col = Database.db.GetCollection<ListEntry>("ListEntries");
            // Use FindOne and not Find as we should have only one
            var result = col.FindOne(Query.And(Query.EQ("Code", Code), Query.EQ("Type", Type)));

            return result;
        }

        public static string getDescfromTypeAndCode(string Type, string Code)
        {
            var col = Database.db.GetCollection<ListEntry>("ListEntries");
            // Use FindOne and not Find as we should have only one
            var result = col.FindOne(Query.And(Query.EQ("Code", Code), Query.EQ("Type", Type)));

            return result.Description;
        }
        public static string getDescfromType(string Type)
        {
            var col = Database.db.GetCollection<ListEntry>("ListEntries");
            // Use FindOne and not Find as we should have only one
            var result = col.FindOne(Query.EQ("Type", Type));

            return result.Description;
        }


        public static string getDescfromEntry(ListEntry entry)
        {
            var col = Database.db.GetCollection<ListEntry>("ListEntries");
            var result = col.FindById(entry.Id);

            return result.Description;
        }

        public ListEntry()
        {
        }
    }
}
