using System;
using System.Collections.Generic;
using LiteDB;
using Xamarin.Forms;

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
        public string TaskCategoryColourCode { get { return ListEntry.getCodefromEntry(TaskCategoryColour); } }
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
           
            string taskcomplex = TaskComplexity.Code;
            TimeSpan daysleft = (DueDate.Date - DateTime.Now.Date);
            int p = daysleft.Days;
            DateTime date = DateTime.Now.Date;

            //A LA FIN INSERTSCHOOLTASK D'un ou plusieurs (pas sur a la fin surement au fur et à mesure mais bon bref

            //SCHOOL
            //__________________________________Exercice_________________________
            if (TaskCategory.Code == "SCHOOL" && TaskSubType.Code=="EXERCICE")
            {
                //dans tous les cas l'exos doit etre traité le soir meme
                if(p>=1)
                {
                        InsertSchoolTask(TaskUser, TaskCategory,
                         IntelligentColor(TaskCategoryColour),
                         TaskComplexity,
                         TaskSubType,
                         Description,
                        "Start working on this today: "+ '\n' + SubDesc,
                         IsComplete,
                         date.AddDays(1));
                }

                if (taskcomplex == "MEDIUM" || taskcomplex == "HIGH" || taskcomplex == "VERY_HIGH")
                {
                    if (p > 3)
                    {
                        InsertSchoolTask(TaskUser, TaskCategory,
                         IntelligentColor(TaskCategoryColour),
                         TaskComplexity,
                         TaskSubType,
                         Description,
                        "Start working on this today: " + '\n' + SubDesc,
                         IsComplete,
                         date.AddDays(p / 4 + 1));
                    }
                    else
                    {
                        InsertSchoolTask(TaskUser, TaskCategory,
                         IntelligentColor(TaskCategoryColour),
                         TaskComplexity,
                         TaskSubType,
                         Description,
                        "Start working on this today: " + '\n' + SubDesc,
                         IsComplete,
                         date.AddDays(2));
                    }
                }
                if (taskcomplex == "HIGH" || taskcomplex == "VERY_HIGH")
                {
                    if (p > 4)
                    {
                        InsertSchoolTask(TaskUser, TaskCategory,
                         IntelligentColor(TaskCategoryColour),
                         TaskComplexity,
                         TaskSubType,
                         Description,
                        "Continue working on this today: " + '\n' + SubDesc,
                         IsComplete,
                         date.AddDays(p/3+1));
                    }
                }

                if (taskcomplex == "VERYHIGH")
                { 
                if (p > 5)
                    {
                        InsertSchoolTask(TaskUser, TaskCategory,
                         IntelligentColor(TaskCategoryColour),
                         TaskComplexity,
                         TaskSubType,
                         Description,
                        "Continue working on this today (you can be proud of yourself for all your hard work): " + '\n' + SubDesc,
                         IsComplete,
                         date.AddDays(p/2));
                    }

                }
            }

            //__________________________________Par coeur_________________________
            if (TaskCategory.Code == "SCHOOL" && TaskSubType.Code == "BY_HEART")
            {

               if (p >= 1 && taskcomplex == "LOW")
                    {
                        InsertSchoolTask(TaskUser, TaskCategory,
                         IntelligentColor(TaskCategoryColour),
                         TaskComplexity,
                         TaskSubType,
                         Description,
                        "Start learning: " + '\n' + SubDesc,
                         IsComplete,
                         date.AddDays(1+p/2));

                    }
               if (p >= 1 && taskcomplex == "MEDIUM")
                    {
                        if(p==1)
                        {
                         InsertSchoolTask(TaskUser, TaskCategory,
                         IntelligentColor(TaskCategoryColour),
                         TaskComplexity,
                         TaskSubType,
                         Description,
                        "Start learning: " + '\n' + SubDesc,
                         IsComplete,
                         date.AddDays(1));
                        }

                        if(p==3)
                        {
                            InsertSchoolTask(TaskUser, TaskCategory,
                         IntelligentColor(TaskCategoryColour),
                         TaskComplexity,
                         TaskSubType,
                         Description,
                        "Start learning: " + '\n' + SubDesc,
                         IsComplete,
                         date.AddDays(2));
                        }

                        if (p >= 3)
                        {
                         InsertSchoolTask(TaskUser, TaskCategory,
                         IntelligentColor(TaskCategoryColour),
                         TaskComplexity,
                         TaskSubType,
                         Description,
                        "Start learning: " + '\n' + SubDesc,
                         IsComplete,
                         date.AddDays(p));

                         InsertSchoolTask(TaskUser, TaskCategory,
                         IntelligentColor(TaskCategoryColour),
                         TaskComplexity,
                         TaskSubType,
                         Description,
                        "Continue learning: " + '\n' + SubDesc,
                         IsComplete,
                         date.AddDays(p*2));

                            
                        }

                    
                }
                if (taskcomplex == "HIGH" || taskcomplex == "VERY_HIGH")
                {
                    if (p >= 1)
                    {
                        
                        InsertSchoolTask(TaskUser, TaskCategory,
                         IntelligentColor(TaskCategoryColour),
                         TaskComplexity,
                         TaskSubType,
                         Description,
                        "Start making notes and doing exercices for: " + '\n' + SubDesc,
                         IsComplete,
                         date.AddDays(1));

                    }

                    for (int i=2; i < p; i+=2)
                    {
                        InsertSchoolTask(TaskUser, TaskCategory,
                         IntelligentColor(TaskCategoryColour),
                         TaskComplexity,
                         TaskSubType,
                         Description,
                        "Continue learning and don't forget, consistency is the key to sucess! : " + '\n' + SubDesc,
                         IsComplete,
                         date.AddDays(i));
                    }
                }
            }

            //__________________________________Projet_________________________
            // POUR TOUT LES WEEKEND JUSQU'A DUE DATE ON MET UN RAPPEL DE CONTINUER LE PROJET AVEC LE TEMPS LIBRE SI TRES COMPLIQUE
            // RAPEL QUE LE DIMANCHE SI COMPLIQUE
            // RAPPEL UN DIMANCHE SUR DEUX SI PEU COMPLIQUE

            string restday = MyUser.me.RestDay;
            var ecartrest = (date.DayOfWeek);
            daysleft = (DueDate.Date - date.Date);
            if (TaskCategory.Code == "SCHOOL" && TaskSubType.Code == "PROJECT")
            {
                if ( taskcomplex == "VERY_HIGH")
                {

                    for (int i = 1; i < p; i += 1)
                    {
                        DateTime thisday = date.Date.AddDays(i);
                        if(thisday.DayOfWeek== DayOfWeek.Saturday || thisday.DayOfWeek == DayOfWeek.Sunday)
                        {
                            InsertSchoolTask(TaskUser, TaskCategory,
                        IntelligentColor(TaskCategoryColour),
                        TaskComplexity,
                        TaskSubType,
                        Description,
                        "RestDay means more time to work on this projet: " + '\n' + SubDesc,
                        IsComplete,
                        date.AddDays(i));
                        }
                    }
                }

                if (taskcomplex == "HIGH")
                {

                    for (int i = 1; i < p; i += 1)
                    {
                        DateTime thisday = DateTime.Now.Date.AddDays(i);
                        if (thisday.DayOfWeek == DayOfWeek.Sunday)
                        {
                            InsertSchoolTask(TaskUser, TaskCategory,
                        IntelligentColor(TaskCategoryColour),
                        TaskComplexity,
                        TaskSubType,
                        Description,
                        "Weekend means more time to work on this projet: " + '\n' + SubDesc,
                        IsComplete,
                        date.AddDays(i));
                        }
                    }
                }

                if (taskcomplex == "LOW" || taskcomplex == "MEDIUM")
                {
                    int lastweek = 0;
                    for (int i = 1; i < p; i += 1)
                    {
                        DateTime thisday = DateTime.Now.Date.AddDays(i);
                        if (thisday.DayOfWeek == DayOfWeek.Sunday)
                        {
                            if (lastweek==0)
                            {
                                InsertSchoolTask(TaskUser, TaskCategory,
                                IntelligentColor(TaskCategoryColour),
                                TaskComplexity,
                                TaskSubType,
                                Description,
                                "Weekend means more time to work on this projet, work today and have more free time next weekend: " + '\n' + SubDesc,
                                IsComplete,
                                date.AddDays(i));

                                lastweek = 1;
                             }
                            else
                            {
                                lastweek = 0;
                            }
                        }
                    }
                }
            }


        }

        public static ListEntry IntelligentColor(ListEntry TaskCategoryColour)
        {
            
            ListEntry newColor = TaskCategoryColour;
            
            switch (TaskCategoryColour.Code)
            {
                case "BLUE":
                    newColor = ListEntry.getEntryfromTypeAndCode("SUBCOLOURS", "LIGHTBLUE");
                    break;
                case "GREEN":
                    newColor = ListEntry.getEntryfromTypeAndCode("SUBCOLOURS", "LIGHTGREEN");
                    break;
                case "RED":
                    newColor = ListEntry.getEntryfromTypeAndCode("SUBCOLOURS", "MEDIUMVIOLETRED");
                    break;
                case "PURPLE":
                    newColor = ListEntry.getEntryfromTypeAndCode("SUBCOLOURS", "BLUEVIOLET");
                    break;
                case "BEIGE":
                    newColor = ListEntry.getEntryfromTypeAndCode("SUBCOLOURS", "BISQUE");
                    break;
                case "BLUEVIOLET":
                    newColor = ListEntry.getEntryfromTypeAndCode("SUBCOLOURS", "CADETBLUE");
                    break;
                case "BROWN":
                    newColor = ListEntry.getEntryfromTypeAndCode("SUBCOLOURS", "SANDYBROWN");
                    break;
                case "CORAL":
                    newColor = ListEntry.getEntryfromTypeAndCode("SUBCOLOURS", "LIGHTSALMON");
                    break;
                case "DARKBLUE":
                    newColor = ListEntry.getEntryfromTypeAndCode("SUBCOLOURS", "MIDNIGHTBLUE");
                    break;
                case "DARKMAGERNTA":
                    newColor = ListEntry.getEntryfromTypeAndCode("SUBCOLOURS", "MAGENTA");
                    break;
                case "FORESTGREEN":
                    newColor = ListEntry.getEntryfromTypeAndCode("SUBCOLOURS", "LAWNGREEN");
                    break;
                case "FUCHSIA":
                    newColor = ListEntry.getEntryfromTypeAndCode("SUBCOLOURS", "LIGHTPRINK");
                    break;
                case "GOLD":
                    newColor = ListEntry.getEntryfromTypeAndCode("SUBCOLOURS", "PALEGOLDENROD");
                    break;
                case "GRAY":
                    newColor = ListEntry.getEntryfromTypeAndCode("SUBCOLOURS", "LIGHTGRAY");
                    break;
            }


            return newColor;
        }
        public SchoolTask()
        {
        }
    }
}
