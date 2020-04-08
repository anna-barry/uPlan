using System;
using System.Collections.Generic;
using LiteDB;

namespace UplanTest
{
    public class SchoolTask
    {
        // ----------------------------------------------------
        // Collection document fields:
        public int Id { get; set; }

        [BsonRef("Users")] // "Users" is the collection to be referenced
        public User TaskUser { get; set; }

        [BsonRef("ListEntries")] // "ListEntries" is the collection to be referenced
        public ListEntry TaskCategory { get; set; }
        [BsonRef("ListEntries")] // "ListEntries" is the collection to be referenced
        public ListEntry TaskCategoryColour { get; set; }
        [BsonRef("ListEntries")] // "ListEntries" is the collection to be referenced
        public ListEntry TaskComplexity { get; set; }

        public ListEntry TaskSubType { get; set; }

        public string Description { get; set; }
        public string SubDesc { get; set; }
        public Boolean IsComplete { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime CompletionDate { get; set; }

        // ----------------------------------------------------
        // "Calculated" property methods:

        public string TaskCategoryDesc { get { return ListEntry.getDescfromEntry(TaskCategory); } }
        public string TaskCategoryColourDesc { get { return ListEntry.getDescfromEntry(TaskCategoryColour); } }
        public string TaskComplexityDesc { get { return ListEntry.getDescfromEntry(TaskComplexity); } }

        public string infoSubtype;
        public string TaskSubCategoryDesc
        {
           get { return infoSubtype; }
            set { if (TaskCategoryDesc== "PERSONAL")
                   { infoSubtype = ListEntry.getDescfromType("TASK_SUBTYPE_PERS"); }
                  else
                { infoSubtype = ListEntry.getDescfromType("TASK_SUBTYPE_SC"); }
            }
            }


        // ----------------------------------------------------

        public static void Initiate()
        {
            // Get a collection (or create, if doesn't exist)
            var col = Database.db.GetCollection<SchoolTask>("SchoolTasks");

            // Index document using these properties
            col.EnsureIndex(x => x.TaskUser);
            col.EnsureIndex(x => x.TaskCategory);
            col.EnsureIndex(x => x.IsComplete);
            col.EnsureIndex(x => x.DueDate);
            col.EnsureIndex(x => x.TaskSubType);
            //col.EnsureIndex(x => x.SubDesc);

            // Create initial data
            col.Insert(
                new SchoolTask
                    { TaskUser = MyUser.me,
                    TaskCategory = ListEntry.getEntryfromTypeAndCode("TASK_CATEGORIES", "PERSONAL"),
                    TaskCategoryColour = ListEntry.getEntryfromTypeAndCode("COLOURS", "BLUE"),
                    TaskComplexity = ListEntry.getEntryfromTypeAndCode("TASK_COMPLEXITIES", "LOW"),
                    TaskSubType = ListEntry.getEntryfromTypeAndCode("TASK_SUBTYPE_SC", "BY_HEART"),
                    Description = "Utiliser uPlan!",
                    SubDesc="j'aime les frites",
                    IsComplete = false,
                    DueDate = DateTime.Now.AddDays(30)
                }
            );
        }

        public static List<SchoolTask> GetAllTasks()
        {
            List<SchoolTask> res=new List<SchoolTask> ();
            var col = Database.db.GetCollection<SchoolTask>("SchoolTask");
            var result = col.Find(Query.All());

            foreach (var test in result)
            {
                res.Add(test);
            }
            return res;

        } 


        // ----------------------------------------------------

        public static void InsertSchoolTask(User TaskUser ,
                    ListEntry TaskCategory,
                    ListEntry TaskCategoryColour,
                    ListEntry TaskComplexity,
                    ListEntry TaskSubType,
                    string Description,
                    string SubDesc,
                    bool IsComplete,
                    DateTime DueDate)
        {
            // Get a collection (or create, if doesn't exist)
            var col = Database.db.GetCollection<SchoolTask>("SchoolTasks");

            // Index document using these properties
            col.EnsureIndex(x => x.TaskUser);
            col.EnsureIndex(x => x.TaskCategory);
            col.EnsureIndex(x => x.IsComplete);
            col.EnsureIndex(x => x.DueDate);
            col.EnsureIndex(x => x.TaskSubType);

            // Create initial data
            col.Insert(
                 new SchoolTask
                 {
                     TaskUser = MyUser.me,
                     TaskCategory=TaskCategory,
                     TaskCategoryColour=TaskCategoryColour,
                     TaskComplexity=TaskComplexity,
                     TaskSubType=TaskSubType,
                     Description=Description,
                     SubDesc= SubDesc,
                     IsComplete =IsComplete,
                     DueDate=DueDate
                 }
                 );

        }

        public static void Intelligent(User TaskUser,
                    ListEntry TaskCategory,
                    ListEntry TaskCategoryColour,
                    ListEntry TaskComplexity,
                    ListEntry TaskSubType,
                    string Description,
                    string SubDesc,
                    bool IsComplete,
                    DateTime DueDate)
        {
            //debut de la nouvelle classe (pas sur qu'on initialse tout ici car pas sur qu'il y ai qu'une sous tache en plus

            ListEntry tcat = new ListEntry(); //ca pas de nouvelles non plus ? a moins qu'on en fasse un sous task mais bon chaud
            ListEntry tcol = new ListEntry(); //couleur plus clair que l'autre
            ListEntry tomp = new ListEntry(); //pas sur qu'il faille modifier ( reprendre celle de base surement)
            ListEntry tsub = new ListEntry(); // la pareil pas de modif en fait
            string desc;
            string subdesc;
            DateTime workdate;

            //EN GROS JSP SI FAUT TOUT MODIFIER FAUT JUSTE QU'ON PARLE DE MANI7RE TECHNIQUE L'AJOUT DES TACHES ET QU4ON
            //VOIT EN DETAILS

            //faire definition d'une couleur plus light que l'autre choisie pour chauqe couleur avec un switch

            //si school sous task
            //if (TaskCategory.Code == "SCHOOL")
            //{
            //en fonction de la complexité faire + ou moins de sous taches

            //}
            /*à voir si sous tasks pour personal? du genre sport créer un rappel semainier ou jsp
            else
            {

            }*/


            //A LA FIN INSERTSCHOOLTASK D'un ou plusieurs (pas sur a la fin surement au fur et à mesure mais bon bref
        }

        public SchoolTask()
        {
        }
    }
}
