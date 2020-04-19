using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Threading.Tasks;



using LiteDB;

using Xamarin.Forms;



namespace UplanTest

{

    public class Calendar : ContentPage

    {

        private bool WorkView;

        private bool MeView;

        private string message = "no task";

        public List<Button> buttonsonMon = new List<Button>();
        public List<Button> buttonsonTue = new List<Button>();
        public List<Button> buttonsonWed = new List<Button>();
        public List<Button> buttonsonThu = new List<Button>();
        public List<Button> buttonsonFri = new List<Button>();
        public List<Button> buttonsonSat = new List<Button>();
        public List<Button> buttonsonSun = new List<Button>();

        IEnumerable<SchoolTask> tasksonMon = null;
        IEnumerable<SchoolTask> tasksonTue = null;
        IEnumerable<SchoolTask> tasksonWed = null;
        IEnumerable<SchoolTask> tasksonThu = null;
        IEnumerable<SchoolTask> tasksonFri = null;
        IEnumerable<SchoolTask> tasksonSat = null;
        IEnumerable<SchoolTask> tasksonSun = null;


        //Button mon1;

        public Calendar()



        {



            //InitializeComponent();

            //____________________________CREATION DU GRID_____________________________________

            //InitializeComponent();



            //____________________________CREATION DU GRID_____________________________________

            var grid = new Grid();

            for (int i = 0; i < 14; i++)

            {

                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });

            }



            for (int j = 0; j < 7; j++)

            {

                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            }

            grid.BackgroundColor = Color.AliceBlue; 



            var Myweek = new Label { Text = "My week", FontSize = 30 };



            grid.Children.Add(Myweek, 0, 0);

            Grid.SetColumnSpan(Myweek, 2);



            //____________________________________________________________________________

            //RECUPERE DATE ACTUELLE ET JOUR DE LA SEMAINE ACTUELLE

            DateTime localTime = DateTime.Now;

            var dayofweektoday = localTime.DayOfWeek;



            var date = new Label { Text = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm"), FontSize = 18 };

            grid.Children.Add(date, 5, 0);

            Grid.SetColumnSpan(date, 2);



            //DEFINIR LES AUTRES JOURS DE LA SEMAINE

            var Monday=localTime;

            var Tuesday = localTime;

            var Wednesday = localTime;

            var Thursday = localTime;

            var Friday = localTime;

            var Saturday = localTime;

            var Sunday = localTime;



            if (dayofweektoday == DayOfWeek.Monday)

            {

               // Monday = localTime.Day;

                Tuesday = localTime.AddDays(1);

                Wednesday = localTime.AddDays(2);

                Thursday = localTime.AddDays(3);

                Friday = localTime.AddDays(4);

                Saturday = localTime.AddDays(5);

                Sunday = localTime.AddDays(6);

            }

            if (dayofweektoday == DayOfWeek.Tuesday)

            {

                //Tuesday = localTime.Day;

                Monday = localTime.AddDays(-1);

                Wednesday = localTime.AddDays(1);

                Thursday = localTime.AddDays(2);

                Friday = localTime.AddDays(3);

                Saturday = localTime.AddDays(4);

                Sunday = localTime.AddDays(5);

            }

            if (dayofweektoday == DayOfWeek.Wednesday)

            {

               // Wednesday = localTime;

                Monday = localTime.AddDays(-2);

                Tuesday = localTime.AddDays(-1);

                Thursday = localTime.AddDays(1);

                Friday = localTime.AddDays(2);

                Saturday = localTime.AddDays(3);

                Sunday = localTime.AddDays(4);

            }

            if (dayofweektoday == DayOfWeek.Thursday)

            {

               // Thursday = localTime;

                Monday = localTime.AddDays(-3);

                Tuesday = localTime.AddDays(-2);

                Wednesday = localTime.AddDays(-1);

                Friday = localTime.AddDays(1);

                Saturday = localTime.AddDays(2);

                Sunday = localTime.AddDays(3);

            }

            if (dayofweektoday == DayOfWeek.Friday)

            {

                //Friday = localTime.Day;

                Monday = localTime.AddDays(-4);

                Tuesday = localTime.AddDays(-2);

                Wednesday = localTime.AddDays(-1);

                Thursday = localTime.AddDays(1);

                Saturday = localTime.AddDays(2);

                Sunday = localTime.AddDays(3);

            }

            if (dayofweektoday == DayOfWeek.Sunday)

            {

                Monday = localTime.AddDays(-6);

                Tuesday = localTime.AddDays(-5);

                Wednesday = localTime.AddDays(-4);

                Thursday = localTime.AddDays(-3);

                Friday = localTime.AddDays(-2);

                Saturday = localTime.AddDays(-1);

                //Sunday = localTime.Day;

            }



            if (dayofweektoday == DayOfWeek.Saturday)

            {

                Monday = localTime.AddDays(-5);

                Tuesday = localTime.AddDays(-4);

                Wednesday = localTime.AddDays(-3);

                Thursday = localTime.AddDays(-2);

                Friday = localTime.AddDays(-1);

                Saturday = localTime;

                Sunday = localTime.AddDays(1);

            }



            //RECUPERER PAR JOURS LES INFORMATIONS

            //enlever après

            //Database.Initiate();

            var col = Database.db.GetCollection<SchoolTask>("SchoolTasks");

            //Database.Initiate();

        

              tasksonMon = col.Find(Query.EQ("DueDate", Monday.Date));
            //var tasksonMon = col.Find(x => x.DueDate == Monday);

            //var tasksonMon = col.FindAll().Where(x => x.DueDate==Monday);
             tasksonTue = col.Find(Query.EQ("DueDate", Tuesday.Date));
            //var tasksonTue = col.Find(x => x.DueDate == Tuesday);

            tasksonWed = col.Find(Query.EQ("DueDate", Wednesday.Date));
           // var tasksonWed = col.Find(x => x.DueDate == Wednesday);

             tasksonThu = col.Find(Query.EQ("DueDate", Thursday.Date));
           // var tasksonThu = col.Find(x => x.DueDate == Thursday);

             tasksonFri = col.Find(Query.EQ("DueDate", Friday.Date));
            //var tasksonFri = col.FindAll().Where(x => x.DueDate == Friday);
          //  var tasksonFri = col.Find(x => x.DueDate == Friday);

             tasksonSat = col.Find(Query.EQ("DueDate", Saturday.Date));
           // var tasksonSat = col.Find(x => x.DueDate == Saturday);

             tasksonSun = col.Find(Query.EQ("DueDate", Sunday.Date));
            // var tasksonSun = col.Find(x => x.DueDate == Monday);



            //TRIER LES INFORMATIONS



            //CREATION DES BOUTONDS POUR LES MODES



            Switch swiSchool = new Switch

            {
                IsToggled= true,

                HorizontalOptions = LayoutOptions.Center,

                VerticalOptions = LayoutOptions.CenterAndExpand,

                OnColor = Color.BlueViolet

            };
            //swiSchool.IsEnabled = true;
            swiSchool.Toggled += Switch_OnToggled;

            grid.Children.Add(swiSchool, 4, 0);



            var Work = new Label { Text = "Work", FontSize = 10, HorizontalOptions = LayoutOptions.Center };

            grid.Children.Add(Work, 4, 0);





            Switch swiMe = new Switch

            {
                IsToggled=true,

                HorizontalOptions = LayoutOptions.Center,

                VerticalOptions = LayoutOptions.CenterAndExpand,

                OnColor = Color.BlueViolet
                

            };

            swiMe.Toggled += Switch2_OnToggled;
            swiMe.IsEnabled = true;
            grid.Children.Add(swiMe, 3, 0);



            var Me = new Label { Text = "Me", FontSize = 10, HorizontalOptions = LayoutOptions.Center };

            grid.Children.Add(Me, 3, 0);



            //Creation des jours de la semaine

            var Lun = new Label { Text = "Monday", FontSize = 20, HorizontalOptions = LayoutOptions.Center };
            if(dayofweektoday == DayOfWeek.Monday)
            {
                Lun.TextColor = Color.BlueViolet;
            }
            grid.Children.Add(Lun, 0, 1);



            var Mar = new Label { Text = "Tuesday", FontSize = 20, HorizontalOptions = LayoutOptions.Center };
            if (dayofweektoday == DayOfWeek.Tuesday)
            {
                Mar.TextColor = Color.BlueViolet;
            }
            grid.Children.Add(Mar, 1, 1);



            var Mer = new Label { Text = "Wednesday", FontSize = 20, HorizontalOptions = LayoutOptions.Center };
            if (dayofweektoday == DayOfWeek.Wednesday)
            {
                Mer.TextColor = Color.BlueViolet;
            }
            grid.Children.Add(Mer, 2, 1);



            var Jeu = new Label { Text = "Thursday", FontSize = 20, HorizontalOptions = LayoutOptions.Center };
            if (dayofweektoday == DayOfWeek.Thursday)
            {
                Jeu.TextColor = Color.BlueViolet;
            }
            grid.Children.Add(Jeu, 3, 1);



            var Fri = new Label { Text = "Friday", FontSize = 20, HorizontalOptions = LayoutOptions.Center };
            if (dayofweektoday == DayOfWeek.Friday)
            {
                Fri.TextColor = Color.BlueViolet;
            }
            grid.Children.Add(Fri, 4, 1);



            var Sam = new Label { Text = "Saturday", FontSize = 20, HorizontalOptions = LayoutOptions.Center };
            if (dayofweektoday == DayOfWeek.Saturday)
            {
                Sam.TextColor = Color.BlueViolet;
            }
            grid.Children.Add(Sam, 5, 1);



            var Dim = new Label { Text = "Sunday", FontSize = 20, HorizontalOptions = LayoutOptions.Center };
            if (dayofweektoday == DayOfWeek.Sunday)
            {
                
                Dim.TextColor = Color.BlueViolet;
            }
            grid.Children.Add(Dim, 6, 1);

            //CR2ATION DES 70 BOUTONS

          
                //_____________________________________________________________________

                //________________________Lundi___1____________________________________

                Button mon1 = new Button();

                bool conti1 = tasksonMon.Count<SchoolTask>() >= 1;
                bool continuee = false;
                if (conti1)
                {
                continuee = (tasksonMon.ElementAt<SchoolTask>(0) != null); /*&&
                                (tasksonMon.ElementAt<SchoolTask>(0).TaskCategoryDesc == "Personal" && MeView ||
                                tasksonMon.ElementAt<SchoolTask>(0).TaskCategoryDesc == "School" && WorkView);*/
                }



                SetButton(tasksonMon, 0, ref mon1, continuee);
                mon1.Clicked += (sender, e) => Alert_Clicked(InitiateButtonGetMsg(tasksonMon, 0));
                grid.Children.Add(mon1, 0, 2);
                buttonsonMon.Add(mon1);

                //_____________________________________________________________________

                //________________________Lundi_______2________________________________



                Button mon2 = new Button();
                bool contim = tasksonMon.Count<SchoolTask>() >= 2;
                bool continueem = false;
                if (contim)
                {
                    continueem = (tasksonMon.ElementAt<SchoolTask>(1) != null) /* || 
                            (tasksonMon.ElementAt<SchoolTask>(1).TaskCategoryDesc == "PERSONAL" && MeView || 
                            tasksonMon.ElementAt<SchoolTask>(1).TaskCategoryDesc == "SCHOOL" && WorkView)*/;
                }


                SetButton(tasksonMon, 1, ref mon2, continueem);
                mon2.Clicked += (sender, e) => Alert_Clicked(InitiateButtonGetMsg(tasksonMon, 1));
                grid.Children.Add(mon2, 0, 3);
                 buttonsonMon.Add(mon2);

            //_____________________________________________________________________

            //________________________Lundi_____3__________________________________

                Button mon3 = new Button();
                bool conti13 = tasksonMon.Count<SchoolTask>() >= 3;
                bool continuee3 = false;
                if (conti13)
                {
                    continuee3 = (tasksonMon.ElementAt<SchoolTask>(2) != null) /* || 
                            (tasksonMon.ElementAt<SchoolTask>(2).TaskCategoryDesc == "PERSONAL" && MeView || 
                            tasksonMon.ElementAt<SchoolTask>(2).TaskCategoryDesc == "SCHOOL" && WorkView)*/;
                }


                SetButton(tasksonMon, 2, ref mon3, continuee3);
                mon3.Clicked += (sender, e) => Alert_Clicked(InitiateButtonGetMsg(tasksonMon, 2));
                grid.Children.Add(mon3, 0, 4);
                buttonsonMon.Add(mon3);

            //_____________________________________________________________________

            //________________________Lundi_____4__________________________________

                Button mon4 = new Button();
                bool conti14 = tasksonMon.Count<SchoolTask>() >= 4;
                bool continuee4 = false;
                if (conti14)
                {
                    continuee4 = (tasksonMon.ElementAt<SchoolTask>(3) != null) /* || 
                            (tasksonMon.ElementAt<SchoolTask>(3).TaskCategoryDesc == "PERSONAL" && MeView || 
                            tasksonMon.ElementAt<SchoolTask>(3).TaskCategoryDesc == "SCHOOL" && WorkView)*/;
                }


                SetButton(tasksonMon, 3, ref mon4, continuee);
                mon4.Clicked += (sender, e) => Alert_Clicked(InitiateButtonGetMsg(tasksonMon, 3));
                grid.Children.Add(mon4, 0, 5);
                buttonsonMon.Add(mon4);

            //_____________________________________________________________________

            //________________________Lundi_____5__________________________________

                Button mon5 = new Button();
                bool conti15 = tasksonMon.Count<SchoolTask>() >= 5;
                bool continuee5 = false;
                if (conti15)
                {
                    continuee5 = (tasksonMon.ElementAt<SchoolTask>(4) != null) /* || 
                            (tasksonMon.ElementAt<SchoolTask>(4).TaskCategoryDesc == "PERSONAL" && MeView || 
                            tasksonMon.ElementAt<SchoolTask>(4).TaskCategoryDesc == "SCHOOL" && WorkView)*/;
                }


                SetButton(tasksonMon, 4, ref mon5, continuee5);
                mon5.Clicked += (sender, e) => Alert_Clicked(InitiateButtonGetMsg(tasksonMon, 4));
                grid.Children.Add(mon5, 0, 6);
                buttonsonMon.Add(mon5);

            //_____________________________________________________________________

            //________________________Lundi_____6__________________________________

            Button mon6 = new Button();
                bool m66 = tasksonMon.Count<SchoolTask>() >= 6;
                bool m6 = false;
                if (m66)
                {
                    m6 = (tasksonMon.ElementAt<SchoolTask>(5) != null) /* || 
                            (tasksonMon.ElementAt<SchoolTask>(5).TaskCategoryDesc == "PERSONAL" && MeView || 
                            tasksonMon.ElementAt<SchoolTask>(5).TaskCategoryDesc == "SCHOOL" && WorkView)*/;
                }


                SetButton(tasksonMon, 5, ref mon6, m6);
                mon6.Clicked += (sender, e) => Alert_Clicked(InitiateButtonGetMsg(tasksonMon, 5));
                grid.Children.Add(mon6, 0, 7);
                buttonsonMon.Add(mon6);


            //_____________________________________________________________________

            //________________________Lundi_____7__________________________________

            Button mon7 = new Button();
                bool ma7 = tasksonMon.Count<SchoolTask>() >= 7;
                bool m7 = false;
                if (ma7)
                {
                    m7 = (tasksonMon.ElementAt<SchoolTask>(6) != null) /* || 
                            (tasksonMon.ElementAt<SchoolTask>(6).TaskCategoryDesc == "PERSONAL" && MeView || 
                            tasksonMon.ElementAt<SchoolTask>(6).TaskCategoryDesc == "SCHOOL" && WorkView)*/;
                }


                SetButton(tasksonMon, 6, ref mon7, m7);
                mon7.Clicked += (sender, e) => Alert_Clicked(InitiateButtonGetMsg(tasksonMon, 6));
                grid.Children.Add(mon7, 0, 8);
                buttonsonMon.Add(mon7);

            //_____________________________________________________________________

            //________________________Lundi_____8__________________________________

                Button mon8 = new Button();
                bool m68 = tasksonMon.Count<SchoolTask>() >= 8;
                bool m8 = false;
                if (m68)
                {
                    m8 = (tasksonMon.ElementAt<SchoolTask>(7) != null) /* || 
                            (tasksonMon.ElementAt<SchoolTask>(7).TaskCategoryDesc == "PERSONAL" && MeView || 
                            tasksonMon.ElementAt<SchoolTask>(7).TaskCategoryDesc == "SCHOOL" && WorkView)*/;
                }


                SetButton(tasksonMon, 7, ref mon8, m8);
                mon8.Clicked += (sender, e) => Alert_Clicked(InitiateButtonGetMsg(tasksonMon, 7));
                grid.Children.Add(mon8, 0, 2 + 7);
                buttonsonMon.Add(mon8);

            //_____________________________________________________________________

            //________________________Lundi_____9__________________________________

                Button mon9 = new Button();
                bool m69 = tasksonMon.Count<SchoolTask>() >= 9;
                bool m9 = false;
                if (m69)
                {
                    m9 = (tasksonMon.ElementAt<SchoolTask>(8) != null) /* || 
                            (tasksonMon.ElementAt<SchoolTask>(8).TaskCategoryDesc == "PERSONAL" && MeView || 
                            tasksonMon.ElementAt<SchoolTask>(8).TaskCategoryDesc == "SCHOOL" && WorkView)*/;
                }


                SetButton(tasksonMon, 8, ref mon9, m9);
                mon9.Clicked += (sender, e) => Alert_Clicked(InitiateButtonGetMsg(tasksonMon, 8));
                grid.Children.Add(mon9, 0, 2 + 8);
                buttonsonMon.Add(mon9);

            //_____________________________________________________________________

            //________________________Lundi_____10__________________________________

                Button mon10 = new Button();
                bool m10 = tasksonMon.Count<SchoolTask>() >= 10;
                bool m610 = false;
                if (m10)
                {
                    m610 = (tasksonMon.ElementAt<SchoolTask>(9) != null) /* || 
                            (tasksonMon.ElementAt<SchoolTask>(9).TaskCategoryDesc == "PERSONAL" && MeView || 
                            tasksonMon.ElementAt<SchoolTask>(9).TaskCategoryDesc == "SCHOOL" && WorkView)*/;
                }


                SetButton(tasksonMon, 9, ref mon10, m610);
                mon10.Clicked += (sender, e) => Alert_Clicked(InitiateButtonGetMsg(tasksonMon, 9));
                grid.Children.Add(mon10, 0, 2 + 9);
                buttonsonMon.Add(mon10);

            //_____________________________________________________________________

            //________________________Mardi___1____________________________________

                Button tue1 = new Button();


                bool tuee1 = tasksonTue.Count<SchoolTask>() >= 1;
                bool btue1 = false;
                if (tuee1)
                {
                    btue1 = (tasksonTue.ElementAt<SchoolTask>(0) != null) /* || 
                            (tasksonTue.ElementAt<SchoolTask>(0).TaskCategoryDesc == "PERSONAL" && MeView || 
                            tasksonTue.ElementAt<SchoolTask>(0).TaskCategoryDesc == "SCHOOL" && WorkView)*/;
                }


                SetButton(tasksonTue, 0, ref tue1, btue1);
                tue1.Clicked += (sender, e) => Alert_Clicked(InitiateButtonGetMsg(tasksonTue, 0));
                grid.Children.Add(tue1, 1, 2);
                buttonsonTue.Add(tue1);


                //_____________________________________________________________________

                //________________________Mardi_______2________________________________



                Button tue2 = new Button();
                bool tuee2 = tasksonTue.Count<SchoolTask>() >= 2;
                bool btue2 = false;
                if (tuee2)
                {
                    btue2 = (tasksonTue.ElementAt<SchoolTask>(1) != null) /* || 
                            (tasksonTue.ElementAt<SchoolTask>(1).TaskCategoryDesc == "PERSONAL" && MeView || 
                            tasksonTue.ElementAt<SchoolTask>(1).TaskCategoryDesc == "SCHOOL" && WorkView)*/;
                }


                SetButton(tasksonTue, 1, ref tue2, btue2);
                tue2.Clicked += (sender, e) => Alert_Clicked(InitiateButtonGetMsg(tasksonTue, 1));
                grid.Children.Add(tue2, 1, 3);
                buttonsonTue.Add(tue2);

            //_____________________________________________________________________

            //________________________Mardi_____3__________________________________

            Button tue3 = new Button();
                bool tuee3 = tasksonTue.Count<SchoolTask>() >= 3;
                bool btue3 = false;
                if (tuee3)
                {
                    btue3 = (tasksonTue.ElementAt<SchoolTask>(2) != null) /* || 
                            (tasksonTue.ElementAt<SchoolTask>(2).TaskCategoryDesc == "PERSONAL" && MeView || 
                            tasksonTue.ElementAt<SchoolTask>(2).TaskCategoryDesc == "SCHOOL" && WorkView)*/;
                }


                SetButton(tasksonTue, 2, ref tue3, btue3);
                tue3.Clicked += (sender, e) => Alert_Clicked(InitiateButtonGetMsg(tasksonTue, 2));
                grid.Children.Add(tue3, 1, 4);
                buttonsonTue.Add(tue3);

            //_____________________________________________________________________

            //________________________Mardi_____4__________________________________

                Button tue4 = new Button();
                bool tuee4 = tasksonTue.Count<SchoolTask>() >= 4;
                bool btue4 = false;
                if (tuee4)
                {
                    btue4 = (tasksonTue.ElementAt<SchoolTask>(3) != null) /* || 
                            (tasksonTue.ElementAt<SchoolTask>(3).TaskCategoryDesc == "PERSONAL" && MeView || 
                            tasksonTue.ElementAt<SchoolTask>(3).TaskCategoryDesc == "SCHOOL" && WorkView)*/;
                }


                SetButton(tasksonTue, 3, ref tue4, btue4);
                tue4.Clicked += (sender, e) => Alert_Clicked(InitiateButtonGetMsg(tasksonTue, 3));
                grid.Children.Add(tue4, 1, 5);
                buttonsonTue.Add(tue4);

            //_____________________________________________________________________

            //________________________Mardi_____5__________________________________

                Button tue5 = new Button();
                bool tuee5 = tasksonTue.Count<SchoolTask>() >= 5;
                bool btue5 = false;
                if (tuee5)
                {
                    btue5 = (tasksonTue.ElementAt<SchoolTask>(4) != null) /* || 
                            (tasksonTue.ElementAt<SchoolTask>(4).TaskCategoryDesc == "PERSONAL" && MeView || 
                            tasksonTue.ElementAt<SchoolTask>(4).TaskCategoryDesc == "SCHOOL" && WorkView)*/;
                }


                SetButton(tasksonTue, 4, ref tue5, btue5);
                tue5.Clicked += (sender, e) => Alert_Clicked(InitiateButtonGetMsg(tasksonTue, 4));
                grid.Children.Add(tue5, 1, 6);
                buttonsonTue.Add(tue5);

            //_____________________________________________________________________

            //________________________Mardi_____6__________________________________

                Button tue6 = new Button();
                bool tuee6 = tasksonTue.Count<SchoolTask>() >= 6;
                bool btue6 = false;
                if (tuee6)
                {
                    btue6 = (tasksonTue.ElementAt<SchoolTask>(5) != null) /* || 
                            (tasksonTue.ElementAt<SchoolTask>(5).TaskCategoryDesc == "PERSONAL" && MeView || 
                            tasksonTue.ElementAt<SchoolTask>(5).TaskCategoryDesc == "SCHOOL" && WorkView)*/;
                }


                SetButton(tasksonTue, 5, ref tue6, btue6);
                tue6.Clicked += (sender, e) => Alert_Clicked(InitiateButtonGetMsg(tasksonTue, 5));
                grid.Children.Add(tue6, 1, 7);
                buttonsonTue.Add(tue6);


            //_____________________________________________________________________

            //________________________Mardi_____7__________________________________

                Button tue7 = new Button();
                bool tuee7 = tasksonTue.Count<SchoolTask>() >= 7;
                bool btue7 = false;
                if (tuee7)
                {
                    btue7 = (tasksonTue.ElementAt<SchoolTask>(6) != null) /* || 
                            (tasksonTue.ElementAt<SchoolTask>(6).TaskCategoryDesc == "PERSONAL" && MeView || 
                            tasksonTue.ElementAt<SchoolTask>(6).TaskCategoryDesc == "SCHOOL" && WorkView)*/;
                }


                SetButton(tasksonTue, 6, ref tue7, btue7);
                tue7.Clicked += (sender, e) => Alert_Clicked(InitiateButtonGetMsg(tasksonTue, 6));
                grid.Children.Add(tue7, 1, 8);
                buttonsonTue.Add(tue7);

            //_____________________________________________________________________

            //________________________Mardi_____8__________________________________

                Button tue8 = new Button();
                bool tuee8 = tasksonTue.Count<SchoolTask>() >= 8;
                bool btue8 = false;
                if (tuee8)
                {
                    btue8 = (tasksonTue.ElementAt<SchoolTask>(7) != null) /* || 
                            (tasksonTue.ElementAt<SchoolTask>(7).TaskCategoryDesc == "PERSONAL" && MeView || 
                            tasksonTue.ElementAt<SchoolTask>(7).TaskCategoryDesc == "SCHOOL" && WorkView)*/;
                }


                SetButton(tasksonTue, 7, ref tue8, btue8);
                tue8.Clicked += (sender, e) => Alert_Clicked(InitiateButtonGetMsg(tasksonTue, 7));
                grid.Children.Add(tue8, 1, 2 + 7);
                buttonsonTue.Add(tue8);

            //_____________________________________________________________________

            //________________________Mardi_____9__________________________________

                Button tue9 = new Button();
                bool tuee9 = tasksonTue.Count<SchoolTask>() >= 9;
                bool btue9 = false;
                if (tuee9)
                {
                    btue9 = (tasksonTue.ElementAt<SchoolTask>(8) != null) /* || 
                            (tasksonTue.ElementAt<SchoolTask>(8).TaskCategoryDesc == "PERSONAL" && MeView || 
                            tasksonTue.ElementAt<SchoolTask>(8).TaskCategoryDesc == "SCHOOL" && WorkView)*/;
                }


                SetButton(tasksonTue, 8, ref tue9, btue9);
                tue9.Clicked += (sender, e) => Alert_Clicked(InitiateButtonGetMsg(tasksonTue, 8));
                grid.Children.Add(tue9, 1, 2 + 8);
                buttonsonTue.Add(tue9);
                 //_____________________________________________________________________

                 //________________________Mardi_____10__________________________________

                Button tue10 = new Button();
                bool tuee10 = tasksonTue.Count<SchoolTask>() >= 10;
                bool btue10 = false;
                if (tuee10)
                {
                    btue10 = (tasksonTue.ElementAt<SchoolTask>(9) != null) /* || 
                            (tasksonTue.ElementAt<SchoolTask>(9).TaskCategoryDesc == "PERSONAL" && MeView || 
                            tasksonTue.ElementAt<SchoolTask>(9).TaskCategoryDesc == "SCHOOL" && WorkView)*/;
                }


                SetButton(tasksonTue, 9, ref tue10, btue10);
                tue10.Clicked += (sender, e) => Alert_Clicked(InitiateButtonGetMsg(tasksonTue, 9));
                grid.Children.Add(tue10, 1, 2 + 9);
                buttonsonTue.Add(tue10);

                 //_____________________________________________________________________

                //________________________Mercredi___1____________________________________

                Button wed1 = new Button();

                bool wedd1 = tasksonWed.Count<SchoolTask>() >= 1;
                bool bwed1 = false;
                if (wedd1)
                {
                    bwed1 = (tasksonWed.ElementAt<SchoolTask>(0) != null) /* || 
                            (tasksonWed.ElementAt<SchoolTask>(0).TaskCategoryDesc == "PERSONAL" && MeView || 
                            tasksonWed.ElementAt<SchoolTask>(0).TaskCategoryDesc == "SCHOOL" && WorkView)*/;
                }


                SetButton(tasksonWed, 0, ref wed1, bwed1);
                wed1.Clicked += (sender, e) => Alert_Clicked(InitiateButtonGetMsg(tasksonWed, 0));
                grid.Children.Add(wed1, 2, 2);
                buttonsonWed.Add(wed1);

                //_____________________________________________________________________

                //________________________Mercredi_______2________________________________



                Button wed2 = new Button();
                bool wedd2 = tasksonWed.Count<SchoolTask>() >= 2;
                bool bwed2 = false;
                if (wedd2)
                {
                    bwed2 = (tasksonWed.ElementAt<SchoolTask>(1) != null) /* || 
                            (tasksonWed.ElementAt<SchoolTask>(1).TaskCategoryDesc == "PERSONAL" && MeView || 
                            tasksonWed.ElementAt<SchoolTask>(1).TaskCategoryDesc == "SCHOOL" && WorkView)*/;
                }


                SetButton(tasksonWed, 1, ref wed2, bwed2);
                wed2.Clicked += (sender, e) => Alert_Clicked(InitiateButtonGetMsg(tasksonWed, 1));
                grid.Children.Add(wed2, 2, 3);
                buttonsonWed.Add(wed2);
                 //_____________________________________________________________________

                //________________________Mercredi_____3__________________________________

                Button wed3 = new Button();
                bool wedd3 = tasksonWed.Count<SchoolTask>() >= 3;
                bool bwed3 = false;
                if (wedd3)
                {
                    bwed3 = (tasksonWed.ElementAt<SchoolTask>(2) != null) /* || 
                            (tasksonWed.ElementAt<SchoolTask>(2).TaskCategoryDesc == "PERSONAL" && MeView || 
                            tasksonWed.ElementAt<SchoolTask>(2).TaskCategoryDesc == "SCHOOL" && WorkView)*/;
                }


                SetButton(tasksonWed, 2, ref wed3, bwed3);
                wed3.Clicked += (sender, e) => Alert_Clicked(InitiateButtonGetMsg(tasksonWed, 2));
                grid.Children.Add(wed3, 2, 4);
                buttonsonWed.Add(wed3);

                 //_____________________________________________________________________

                 //________________________Mercredi_____4__________________________________

                Button wed4 = new Button();
                bool wedd4 = tasksonWed.Count<SchoolTask>() >= 4;
                bool bwed4 = false;
                if (wedd4)
                {
                    bwed4 = (tasksonWed.ElementAt<SchoolTask>(3) != null) /* || 
                            (tasksonWed.ElementAt<SchoolTask>(3).TaskCategoryDesc == "PERSONAL" && MeView || 
                            tasksonWed.ElementAt<SchoolTask>(3).TaskCategoryDesc == "SCHOOL" && WorkView)*/;
                }


                SetButton(tasksonWed, 3, ref wed4, bwed4);
                wed4.Clicked += (sender, e) => Alert_Clicked(InitiateButtonGetMsg(tasksonWed, 3));
                grid.Children.Add(wed4, 2, 5);
                buttonsonWed.Add(wed4);

            //_____________________________________________________________________

            //________________________Mercredi_____5__________________________________

                Button wed5 = new Button();
                bool wedd5 = tasksonWed.Count<SchoolTask>() >= 5;
                bool bwed5 = false;
                if (wedd5)
                {
                    bwed5 = (tasksonWed.ElementAt<SchoolTask>(4) != null) /* || 
                            (tasksonWed.ElementAt<SchoolTask>(4).TaskCategoryDesc == "PERSONAL" && MeView || 
                            tasksonWed.ElementAt<SchoolTask>(4).TaskCategoryDesc == "SCHOOL" && WorkView)*/;
                }


                SetButton(tasksonWed, 4, ref wed5, bwed5);
                wed5.Clicked += (sender, e) => Alert_Clicked(InitiateButtonGetMsg(tasksonWed, 4));
                grid.Children.Add(wed5, 2, 6);
                buttonsonWed.Add(wed5);

               //_____________________________________________________________________

               //________________________Mercredi_____6__________________________________

                Button wed6 = new Button();
                bool wedd6 = tasksonWed.Count<SchoolTask>() >= 6;
                bool bwed6 = false;
                if (wedd6)
                {
                    bwed6 = (tasksonWed.ElementAt<SchoolTask>(5) != null) /* || 
                            (tasksonWed.ElementAt<SchoolTask>(5).TaskCategoryDesc == "PERSONAL" && MeView || 
                            tasksonWed.ElementAt<SchoolTask>(5).TaskCategoryDesc == "SCHOOL" && WorkView)*/;
                }


                SetButton(tasksonWed, 5, ref wed6, bwed6);
                wed6.Clicked += (sender, e) => Alert_Clicked(InitiateButtonGetMsg(tasksonWed, 5));
                grid.Children.Add(wed6, 2, 7);
                buttonsonWed.Add(wed6);


                //_____________________________________________________________________

               //________________________Mercredi_____7__________________________________

                Button wed7 = new Button();
                bool wedd7 = tasksonWed.Count<SchoolTask>() >= 7;
                bool bwed7 = false;
                if (wedd7)
                {
                    bwed7 = (tasksonWed.ElementAt<SchoolTask>(6) != null) /* || 
                            (tasksonWed.ElementAt<SchoolTask>(6).TaskCategoryDesc == "PERSONAL" && MeView || 
                            tasksonWed.ElementAt<SchoolTask>(6).TaskCategoryDesc == "SCHOOL" && WorkView)*/;
                }


                SetButton(tasksonWed, 6, ref wed7, bwed7);
                wed7.Clicked += (sender, e) => Alert_Clicked(InitiateButtonGetMsg(tasksonWed, 6));
                grid.Children.Add(wed7, 2, 8);
                buttonsonWed.Add(wed7);
                 //_____________________________________________________________________

                //________________________Mercredi_____8__________________________________

                Button wed8 = new Button();
                bool wedd8 = tasksonWed.Count<SchoolTask>() >= 8;
                bool bwed8 = false;
                if (wedd8)
                {
                    bwed8 = (tasksonWed.ElementAt<SchoolTask>(7) != null) /* || 
                            (tasksonWed.ElementAt<SchoolTask>(7).TaskCategoryDesc == "PERSONAL" && MeView || 
                            tasksonWed.ElementAt<SchoolTask>(7).TaskCategoryDesc == "SCHOOL" && WorkView)*/;
                }


                SetButton(tasksonWed, 7, ref wed8, bwed8);
                wed8.Clicked += (sender, e) => Alert_Clicked(InitiateButtonGetMsg(tasksonWed, 7));
                grid.Children.Add(wed8, 2, 2 + 7);
                buttonsonWed.Add(wed8);

                //_____________________________________________________________________

                //________________________Mercredi_____9__________________________________

                Button wed9 = new Button();
                bool wedd9 = tasksonWed.Count<SchoolTask>() >= 9;
                bool bwed9 = false;
                if (wedd9)
                {
                    bwed9 = (tasksonWed.ElementAt<SchoolTask>(8) != null) /* || 
                            (tasksonWed.ElementAt<SchoolTask>(8).TaskCategoryDesc == "PERSONAL" && MeView || 
                            tasksonWed.ElementAt<SchoolTask>(8).TaskCategoryDesc == "SCHOOL" && WorkView)*/;
                }


                SetButton(tasksonWed, 8, ref wed9, bwed9);
                wed9.Clicked += (sender, e) => Alert_Clicked(InitiateButtonGetMsg(tasksonWed, 8));
                grid.Children.Add(wed9, 2, 2 + 8);
                buttonsonWed.Add(wed9);

                 //_____________________________________________________________________

                //________________________Mercredi_____10__________________________________

                Button wed10 = new Button();
                bool wedd10 = tasksonWed.Count<SchoolTask>() >= 10;
                bool bwed10 = false;
                if (wedd10)
                {
                    bwed10 = (tasksonWed.ElementAt<SchoolTask>(9) != null) /* || 
                            (tasksonWed.ElementAt<SchoolTask>(9).TaskCategoryDesc == "PERSONAL" && MeView || 
                            tasksonWed.ElementAt<SchoolTask>(9).TaskCategoryDesc == "SCHOOL" && WorkView)*/;
                }


                SetButton(tasksonWed, 9, ref wed10, bwed10);
                wed10.Clicked += (sender, e) => Alert_Clicked(InitiateButtonGetMsg(tasksonWed, 9));
                grid.Children.Add(wed10, 2, 2 + 9);
                buttonsonWed.Add(wed10);

                //_____________________________________________________________________

                //________________________Jeudi___1____________________________________

                Button thu1 = new Button();


                bool thud1 = tasksonThu.Count<SchoolTask>() >= 1;
                bool bthu1 = false;
                if (thud1)
                {
                    bthu1 = (tasksonThu.ElementAt<SchoolTask>(0) != null) /* || 
                            (tasksonThu.ElementAt<SchoolTask>(0).TaskCategoryDesc == "PERSONAL" && MeView || 
                            tasksonThu.ElementAt<SchoolTask>(0).TaskCategoryDesc == "SCHOOL" && WorkView)*/;
                }


                SetButton(tasksonThu, 0, ref thu1, bthu1);
                thu1.Clicked += (sender, e) => Alert_Clicked(InitiateButtonGetMsg(tasksonThu, 0));
                grid.Children.Add(thu1, 3, 2);


                //_____________________________________________________________________

                //________________________Jeudi_______2________________________________



                Button thu2 = new Button();
                bool thud2 = tasksonThu.Count<SchoolTask>() >= 2;
                bool bthu2 = false;
                if (thud2)
                {
                    bthu2 = (tasksonThu.ElementAt<SchoolTask>(1) != null) /* || 
                            (tasksonThu.ElementAt<SchoolTask>(1).TaskCategoryDesc == "PERSONAL" && MeView || 
                            tasksonThu.ElementAt<SchoolTask>(1).TaskCategoryDesc == "SCHOOL" && WorkView)*/;
                }


                SetButton(tasksonThu, 1, ref thu2, bthu2);
                thu2.Clicked += (sender, e) => Alert_Clicked(InitiateButtonGetMsg(tasksonThu, 1));
                grid.Children.Add(thu2, 3, 3);

                //_____________________________________________________________________

                //________________________Jeudi_____3__________________________________

                Button thu3 = new Button();
                bool thud3 = tasksonThu.Count<SchoolTask>() >= 3;
                bool bthu3 = false;
                if (thud3)
                {
                    bthu3 = (tasksonThu.ElementAt<SchoolTask>(2) != null) /* || 
                            (tasksonThu.ElementAt<SchoolTask>(2).TaskCategoryDesc == "PERSONAL" && MeView || 
                            tasksonThu.ElementAt<SchoolTask>(2).TaskCategoryDesc == "SCHOOL" && WorkView)*/;
                }


                SetButton(tasksonThu, 2, ref thu3, bthu3);
                thu3.Clicked += (sender, e) => Alert_Clicked(InitiateButtonGetMsg(tasksonThu, 2));
                grid.Children.Add(thu3, 3, 4);

                //_____________________________________________________________________

                //________________________Jeudi_____4__________________________________

                Button thu4 = new Button();
                bool thud4 = tasksonThu.Count<SchoolTask>() >= 4;
                bool bthu4 = false;
                if (thud4)
                {
                    bthu4 = (tasksonThu.ElementAt<SchoolTask>(3) != null) /* || 
                            (tasksonThu.ElementAt<SchoolTask>(3).TaskCategoryDesc == "PERSONAL" && MeView || 
                            tasksonThu.ElementAt<SchoolTask>(3).TaskCategoryDesc == "SCHOOL" && WorkView)*/;
                }


                SetButton(tasksonThu, 3, ref thu4, bthu4);
                thu4.Clicked += (sender, e) => Alert_Clicked(InitiateButtonGetMsg(tasksonThu, 3));
                grid.Children.Add(thu4, 3, 5);

                //_____________________________________________________________________

                //________________________Jeudi_____5__________________________________

                Button thu5 = new Button();
                bool thud5 = tasksonThu.Count<SchoolTask>() >= 5;
                bool bthu5 = false;
                if (thud5)
                {
                    bthu5 = (tasksonThu.ElementAt<SchoolTask>(4) != null) /* || 
                            (tasksonThu.ElementAt<SchoolTask>(4).TaskCategoryDesc == "PERSONAL" && MeView || 
                            tasksonThu.ElementAt<SchoolTask>(4).TaskCategoryDesc == "SCHOOL" && WorkView)*/;
                }


                SetButton(tasksonThu, 4, ref thu5, bthu5);
                thu5.Clicked += (sender, e) => Alert_Clicked(InitiateButtonGetMsg(tasksonThu, 4));
                grid.Children.Add(thu5, 3, 6);

                //_____________________________________________________________________

                //________________________Jeudi_____6__________________________________

                Button thu6 = new Button();
                bool thud6 = tasksonThu.Count<SchoolTask>() >= 6;
                bool bthu6 = false;
                if (thud6)
                {
                    bthu6 = (tasksonThu.ElementAt<SchoolTask>(5) != null) /* || 
                            (tasksonThu.ElementAt<SchoolTask>(5).TaskCategoryDesc == "PERSONAL" && MeView || 
                            tasksonThu.ElementAt<SchoolTask>(5).TaskCategoryDesc == "SCHOOL" && WorkView)*/;
                }


                SetButton(tasksonThu, 5, ref thu6, bthu6);
                thu6.Clicked += (sender, e) => Alert_Clicked(InitiateButtonGetMsg(tasksonThu, 5));
                grid.Children.Add(thu6, 3, 7);


                //_____________________________________________________________________

                //________________________Jeudi_____7__________________________________

                Button thu7 = new Button();
                bool thud7 = tasksonThu.Count<SchoolTask>() >= 7;
                bool bthu7 = false;
                if (thud7)
                {
                    bthu7 = (tasksonThu.ElementAt<SchoolTask>(6) != null) /* || 
                            (tasksonThu.ElementAt<SchoolTask>(6).TaskCategoryDesc == "PERSONAL" && MeView || 
                            tasksonThu.ElementAt<SchoolTask>(6).TaskCategoryDesc == "SCHOOL" && WorkView)*/;
                }


                SetButton(tasksonThu, 6, ref thu7, bthu7);
                thu7.Clicked += (sender, e) => Alert_Clicked(InitiateButtonGetMsg(tasksonThu, 6));
                grid.Children.Add(thu7, 3, 8);

                //_____________________________________________________________________

                //________________________Jeudi_____8__________________________________

                Button thu8 = new Button();
                bool thud8 = tasksonThu.Count<SchoolTask>() >= 8;
                bool bthu8 = false;
                if (thud8)
                {
                    bthu8 = (tasksonThu.ElementAt<SchoolTask>(7) != null) /* || 
                            (tasksonThu.ElementAt<SchoolTask>(7).TaskCategoryDesc == "PERSONAL" && MeView || 
                            tasksonThu.ElementAt<SchoolTask>(7).TaskCategoryDesc == "SCHOOL" && WorkView)*/;
                }


                SetButton(tasksonThu, 7, ref thu8, bthu8);
                thu8.Clicked += (sender, e) => Alert_Clicked(InitiateButtonGetMsg(tasksonThu, 7));
                grid.Children.Add(thu8, 3, 2 + 7);

                //_____________________________________________________________________

                //________________________Jeudi_____9__________________________________

                Button thu9 = new Button();
                bool thud9 = tasksonThu.Count<SchoolTask>() >= 9;
                bool bthu9 = false;
                if (thud9)
                {
                    bthu9 = (tasksonThu.ElementAt<SchoolTask>(8) != null) /* || 
                            (tasksonThu.ElementAt<SchoolTask>(8).TaskCategoryDesc == "PERSONAL" && MeView || 
                            tasksonThu.ElementAt<SchoolTask>(8).TaskCategoryDesc == "SCHOOL" && WorkView)*/;
                }


                SetButton(tasksonThu, 8, ref thu9, bthu9);
                thu9.Clicked += (sender, e) => Alert_Clicked(InitiateButtonGetMsg(tasksonThu, 8));
                grid.Children.Add(thu9, 3, 2 + 8);

                //_____________________________________________________________________

                //________________________Jeudi_____10__________________________________

                Button thu10 = new Button();
                bool thud10 = tasksonThu.Count<SchoolTask>() >= 10;
                bool bthu10 = false;
                if (thud10)
                {
                    bthu10 = (tasksonThu.ElementAt<SchoolTask>(9) != null) /* || 
                            (tasksonThu.ElementAt<SchoolTask>(9).TaskCategoryDesc == "PERSONAL" && MeView || 
                            tasksonThu.ElementAt<SchoolTask>(9).TaskCategoryDesc == "SCHOOL" && WorkView)*/;
                }


                SetButton(tasksonThu, 9, ref thu10, bthu10);
                thu10.Clicked += (sender, e) => Alert_Clicked(InitiateButtonGetMsg(tasksonThu, 9));
                grid.Children.Add(thu10, 3, 2 + 9);

                //__________________Add All Thursday buttons__________________________
                buttonsonThu.Add(thu1);
                buttonsonThu.Add(thu2);
                buttonsonThu.Add(thu3);
                buttonsonThu.Add(thu4);
                buttonsonThu.Add(thu5);
                buttonsonThu.Add(thu6);
                buttonsonThu.Add(thu7);
                buttonsonThu.Add(thu8);
                buttonsonThu.Add(thu9);
                buttonsonThu.Add(thu10);
                //_____________________________________________________________________

                //________________________Vendredi___1____________________________________

                Button fri1 = new Button();


                bool frid1 = tasksonFri.Count<SchoolTask>() >= 1;
                bool bfri1 = false;
                if (frid1)
                {
                    bfri1 = (tasksonFri.ElementAt<SchoolTask>(0) != null) /* || 
                            (tasksonFri.ElementAt<SchoolTask>(0).TaskCategoryDesc == "PERSONAL" && MeView || 
                            tasksonFri.ElementAt<SchoolTask>(0).TaskCategoryDesc == "SCHOOL" && WorkView)*/;
                }


                SetButton(tasksonFri, 0, ref fri1, bfri1);
                fri1.Clicked += (sender, e) => Alert_Clicked(InitiateButtonGetMsg(tasksonFri, 0));
                grid.Children.Add(fri1, 4, 2);


                //_____________________________________________________________________

                //________________________Vendredi_______2________________________________



                Button fri2 = new Button();
                bool frid2 = tasksonFri.Count<SchoolTask>() >= 2;
                bool bfri2 = false;
                if (frid2)
                {
                    bfri2 = (tasksonFri.ElementAt<SchoolTask>(1) != null) /* || 
                            (tasksonFri.ElementAt<SchoolTask>(1).TaskCategoryDesc == "PERSONAL" && MeView || 
                            tasksonFri.ElementAt<SchoolTask>(1).TaskCategoryDesc == "SCHOOL" && WorkView)*/;
                }


                SetButton(tasksonFri, 1, ref fri2, bfri2);
                fri2.Clicked += (sender, e) => Alert_Clicked(InitiateButtonGetMsg(tasksonFri, 1));
                grid.Children.Add(fri2, 4, 3);

                //_____________________________________________________________________

                //________________________Vendredi_____3__________________________________

                Button fri3 = new Button();
                bool frid3 = tasksonFri.Count<SchoolTask>() >= 3;
                bool bfri3 = false;
                if (frid3)
                {
                    bfri3 = (tasksonFri.ElementAt<SchoolTask>(2) != null) /* || 
                            (tasksonFri.ElementAt<SchoolTask>(2).TaskCategoryDesc == "PERSONAL" && MeView || 
                            tasksonFri.ElementAt<SchoolTask>(2).TaskCategoryDesc == "SCHOOL" && WorkView)*/;
                }


                SetButton(tasksonFri, 2, ref fri3, bfri3);
                fri3.Clicked += (sender, e) => Alert_Clicked(InitiateButtonGetMsg(tasksonFri, 2));
                grid.Children.Add(fri3, 4, 4);

                //_____________________________________________________________________

                //________________________Vendredi_____4__________________________________

                Button fri4 = new Button();
                bool frid4 = tasksonFri.Count<SchoolTask>() >= 4;
                bool bfri4 = false;
                if (frid4)
                {
                    bfri4 = (tasksonFri.ElementAt<SchoolTask>(3) != null) /* || 
                            (tasksonFri.ElementAt<SchoolTask>(3).TaskCategoryDesc == "PERSONAL" && MeView || 
                            tasksonFri.ElementAt<SchoolTask>(3).TaskCategoryDesc == "SCHOOL" && WorkView)*/;
                }


                SetButton(tasksonFri, 3, ref fri4, bfri4);
                fri4.Clicked += (sender, e) => Alert_Clicked(InitiateButtonGetMsg(tasksonFri, 3));
                grid.Children.Add(fri4, 4, 5);

                //_____________________________________________________________________

                //________________________Vendredi_____5__________________________________

                Button fri5 = new Button();
                bool frid5 = tasksonFri.Count<SchoolTask>() >= 5;
                bool bfri5 = false;
                if (frid5)
                {
                    bfri5 = (tasksonFri.ElementAt<SchoolTask>(4) != null) /* || 
                            (tasksonFri.ElementAt<SchoolTask>(4).TaskCategoryDesc == "PERSONAL" && MeView || 
                            tasksonFri.ElementAt<SchoolTask>(4).TaskCategoryDesc == "SCHOOL" && WorkView)*/;
                }


                SetButton(tasksonFri, 4, ref fri5, bfri5);
                fri5.Clicked += (sender, e) => Alert_Clicked(InitiateButtonGetMsg(tasksonFri, 4));
                grid.Children.Add(fri5, 4, 6);

                //_____________________________________________________________________

                //________________________Vendredi_____6__________________________________

                Button fri6 = new Button();
                bool frid6 = tasksonFri.Count<SchoolTask>() >= 6;
                bool bfri6 = false;
                if (frid6)
                {
                    bfri6 = (tasksonFri.ElementAt<SchoolTask>(5) != null) /* || 
                            (tasksonFri.ElementAt<SchoolTask>(5).TaskCategoryDesc == "PERSONAL" && MeView || 
                            tasksonFri.ElementAt<SchoolTask>(5).TaskCategoryDesc == "SCHOOL" && WorkView)*/;
                }


                SetButton(tasksonFri, 5, ref fri6, bfri6);
                fri6.Clicked += (sender, e) => Alert_Clicked(InitiateButtonGetMsg(tasksonFri, 5));
                grid.Children.Add(fri6, 4, 7);


                //_____________________________________________________________________

                //________________________Vendredi_____7__________________________________

                Button fri7 = new Button();
                bool frid7 = tasksonFri.Count<SchoolTask>() >= 7;
                bool bfri7 = false;
                if (frid7)
                {
                    bfri7 = (tasksonFri.ElementAt<SchoolTask>(6) != null) /* || 
                            (tasksonFri.ElementAt<SchoolTask>(6).TaskCategoryDesc == "PERSONAL" && MeView || 
                            tasksonFri.ElementAt<SchoolTask>(6).TaskCategoryDesc == "SCHOOL" && WorkView)*/;
                }


                SetButton(tasksonFri, 6, ref fri7, bfri7);
                fri7.Clicked += (sender, e) => Alert_Clicked(InitiateButtonGetMsg(tasksonFri, 6));
                grid.Children.Add(fri7, 4, 8);

                //_____________________________________________________________________

                //________________________Vendredi_____8__________________________________

                Button fri8 = new Button();
                bool frid8 = tasksonFri.Count<SchoolTask>() >= 8;
                bool bfri8 = false;
                if (frid8)
                {
                    bfri8 = (tasksonFri.ElementAt<SchoolTask>(7) != null) /* || 
                            (tasksonFri.ElementAt<SchoolTask>(7).TaskCategoryDesc == "PERSONAL" && MeView || 
                            tasksonFri.ElementAt<SchoolTask>(7).TaskCategoryDesc == "SCHOOL" && WorkView)*/;
                }


                SetButton(tasksonFri, 7, ref fri8, bfri8);
                fri8.Clicked += (sender, e) => Alert_Clicked(InitiateButtonGetMsg(tasksonFri, 7));
                grid.Children.Add(fri8, 4, 2 + 7);

                //_____________________________________________________________________

                //________________________Vendredi_____9__________________________________

                Button fri9 = new Button();
                bool frid9 = tasksonFri.Count<SchoolTask>() >= 9;
                bool bfri9 = false;
                if (frid9)
                {
                    bfri9 = (tasksonFri.ElementAt<SchoolTask>(8) != null) /* || 
                            (tasksonFri.ElementAt<SchoolTask>(8).TaskCategoryDesc == "PERSONAL" && MeView || 
                            tasksonFri.ElementAt<SchoolTask>(8).TaskCategoryDesc == "SCHOOL" && WorkView)*/;
                }


                SetButton(tasksonFri, 8, ref fri9, bfri9);
                fri9.Clicked += (sender, e) => Alert_Clicked(InitiateButtonGetMsg(tasksonFri, 8));
                grid.Children.Add(fri9, 4, 2 + 8);

                //_____________________________________________________________________

                //________________________Vendredi_____10__________________________________

                Button fri10 = new Button();
                bool frid10 = tasksonFri.Count<SchoolTask>() >= 10;
                bool bfri10 = false;
                if (frid10)
                {
                    bfri10 = (tasksonFri.ElementAt<SchoolTask>(9) != null) /* || 
                            (tasksonFri.ElementAt<SchoolTask>(9).TaskCategoryDesc == "PERSONAL" && MeView || 
                            tasksonFri.ElementAt<SchoolTask>(9).TaskCategoryDesc == "SCHOOL" && WorkView)*/;
                }


                SetButton(tasksonFri, 9, ref fri10, bfri10);
                fri10.Clicked += (sender, e) => Alert_Clicked(InitiateButtonGetMsg(tasksonFri, 9));
                grid.Children.Add(fri10, 4, 2 + 9);

                //__________________Add All Friday buttons__________________________
                buttonsonFri.Add(fri1);
                buttonsonFri.Add(fri2);
                buttonsonFri.Add(fri3);
                buttonsonFri.Add(fri4);
                buttonsonFri.Add(fri5);
                buttonsonFri.Add(fri6);
                buttonsonFri.Add(fri7);
                buttonsonFri.Add(fri8);
                buttonsonFri.Add(fri9);
                buttonsonFri.Add(fri10);
                //_____________________________________________________________________

                //________________________Samedi___1____________________________________

                Button sat1 = new Button();


                bool satd1 = tasksonSat.Count<SchoolTask>() >= 1;
                bool bsat1 = false;
                if (satd1)
                {
                    bsat1 = (tasksonSat.ElementAt<SchoolTask>(0) != null) /* || 
                            (tasksonSat.ElementAt<SchoolTask>(0).TaskCategoryDesc == "PERSONAL" && MeView || 
                            tasksonSat.ElementAt<SchoolTask>(0).TaskCategoryDesc == "SCHOOL" && WorkView)*/;
                }


                SetButton(tasksonSat, 0, ref sat1, bsat1);
                sat1.Clicked += (sender, e) => Alert_Clicked(InitiateButtonGetMsg(tasksonSat, 0));
                grid.Children.Add(sat1, 5, 2);


                //_____________________________________________________________________

                //________________________Samedi_______2________________________________



                Button sat2 = new Button();
                bool satd2 = tasksonSat.Count<SchoolTask>() >= 2;
                bool bsat2 = false;
                if (satd2)
                {
                    bsat2 = (tasksonSat.ElementAt<SchoolTask>(1) != null) /* || 
                            (tasksonSat.ElementAt<SchoolTask>(1).TaskCategoryDesc == "PERSONAL" && MeView || 
                            tasksonSat.ElementAt<SchoolTask>(1).TaskCategoryDesc == "SCHOOL" && WorkView)*/;
                }


                SetButton(tasksonSat, 1, ref sat2, bsat2);
                sat2.Clicked += (sender, e) => Alert_Clicked(InitiateButtonGetMsg(tasksonSat, 1));
                grid.Children.Add(sat2, 5, 3);

                //_____________________________________________________________________

                //________________________Samedi_____3__________________________________

                Button sat3 = new Button();
                bool satd3 = tasksonSat.Count<SchoolTask>() >= 3;
                bool bsat3 = false;
                if (satd3)
                {
                    bsat3 = (tasksonSat.ElementAt<SchoolTask>(2) != null) /* || 
                            (tasksonSat.ElementAt<SchoolTask>(2).TaskCategoryDesc == "PERSONAL" && MeView || 
                            tasksonSat.ElementAt<SchoolTask>(2).TaskCategoryDesc == "SCHOOL" && WorkView)*/;
                }


                SetButton(tasksonSat, 2, ref sat3, bsat3);
                sat3.Clicked += (sender, e) => Alert_Clicked(InitiateButtonGetMsg(tasksonSat, 2));
                grid.Children.Add(sat3, 5, 4);

                //_____________________________________________________________________

                //________________________Samedi_____4__________________________________

                Button sat4 = new Button();
                bool satd4 = tasksonSat.Count<SchoolTask>() >= 4;
                bool bsat4 = false;
                if (satd4)
                {
                    bsat4 = (tasksonSat.ElementAt<SchoolTask>(3) != null) /* || 
                            (tasksonSat.ElementAt<SchoolTask>(3).TaskCategoryDesc == "PERSONAL" && MeView || 
                            tasksonSat.ElementAt<SchoolTask>(3).TaskCategoryDesc == "SCHOOL" && WorkView)*/;
                }


                SetButton(tasksonSat, 3, ref sat4, bsat4);
                sat4.Clicked += (sender, e) => Alert_Clicked(InitiateButtonGetMsg(tasksonSat, 3));
                grid.Children.Add(sat4, 5, 5);

                //_____________________________________________________________________

                //________________________Samedi_____5__________________________________

                Button sat5 = new Button();
                bool satd5 = tasksonSat.Count<SchoolTask>() >= 5;
                bool bsat5 = false;
                if (satd5)
                {
                    bsat5 = (tasksonSat.ElementAt<SchoolTask>(4) != null) /* || 
                            (tasksonSat.ElementAt<SchoolTask>(4).TaskCategoryDesc == "PERSONAL" && MeView || 
                            tasksonSat.ElementAt<SchoolTask>(4).TaskCategoryDesc == "SCHOOL" && WorkView)*/;
                }


                SetButton(tasksonSat, 4, ref sat5, bsat5);
                sat5.Clicked += (sender, e) => Alert_Clicked(InitiateButtonGetMsg(tasksonSat, 4));
                grid.Children.Add(sat5, 5, 6);

                //_____________________________________________________________________

                //________________________Samedi_____6__________________________________

                Button sat6 = new Button();
                bool satd6 = tasksonSat.Count<SchoolTask>() >= 6;
                bool bsat6 = false;
                if (satd6)
                {
                    bsat6 = (tasksonSat.ElementAt<SchoolTask>(5) != null) /* || 
                            (tasksonSat.ElementAt<SchoolTask>(5).TaskCategoryDesc == "PERSONAL" && MeView || 
                            tasksonSat.ElementAt<SchoolTask>(5).TaskCategoryDesc == "SCHOOL" && WorkView)*/;
                }


                SetButton(tasksonSat, 5, ref sat6, bsat6);
                sat6.Clicked += (sender, e) => Alert_Clicked(InitiateButtonGetMsg(tasksonSat, 5));
                grid.Children.Add(sat6, 5, 7);


                //_____________________________________________________________________

                //________________________Samedi_____7__________________________________

                Button sat7 = new Button();
                bool satd7 = tasksonSat.Count<SchoolTask>() >= 7;
                bool bsat7 = false;
                if (satd7)
                {
                    bsat7 = (tasksonSat.ElementAt<SchoolTask>(6) != null) /* || 
                            (tasksonSat.ElementAt<SchoolTask>(6).TaskCategoryDesc == "PERSONAL" && MeView || 
                            tasksonSat.ElementAt<SchoolTask>(6).TaskCategoryDesc == "SCHOOL" && WorkView)*/;
                }


                SetButton(tasksonSat, 6, ref sat7, bsat7);
                sat7.Clicked += (sender, e) => Alert_Clicked(InitiateButtonGetMsg(tasksonSat, 6));
                grid.Children.Add(sat7, 5, 8);

                //_____________________________________________________________________

                //________________________Samedi_____8__________________________________

                Button sat8 = new Button();
                bool satd8 = tasksonSat.Count<SchoolTask>() >= 8;
                bool bsat8 = false;
                if (satd8)
                {
                    bsat8 = (tasksonSat.ElementAt<SchoolTask>(7) != null) /* || 
                            (tasksonSat.ElementAt<SchoolTask>(7).TaskCategoryDesc == "PERSONAL" && MeView || 
                            tasksonSat.ElementAt<SchoolTask>(7).TaskCategoryDesc == "SCHOOL" && WorkView)*/;
                }


                SetButton(tasksonSat, 7, ref sat8, bsat8);
                sat8.Clicked += (sender, e) => Alert_Clicked(InitiateButtonGetMsg(tasksonSat, 7));
                grid.Children.Add(sat8, 5, 2 + 7);

                //_____________________________________________________________________

                //________________________Samedi_____9__________________________________

                Button sat9 = new Button();
                bool satd9 = tasksonSat.Count<SchoolTask>() >= 9;
                bool bsat9 = false;
                if (satd9)
                {
                    bsat9 = (tasksonSat.ElementAt<SchoolTask>(8) != null) /* || 
                            (tasksonSat.ElementAt<SchoolTask>(8).TaskCategoryDesc == "PERSONAL" && MeView || 
                            tasksonSat.ElementAt<SchoolTask>(8).TaskCategoryDesc == "SCHOOL" && WorkView)*/;
                }


                SetButton(tasksonSat, 8, ref sat9, bsat9);
                sat9.Clicked += (sender, e) => Alert_Clicked(InitiateButtonGetMsg(tasksonSat, 8));
                grid.Children.Add(sat9, 5, 2 + 8);

                //_____________________________________________________________________

                //________________________Samedi_____10__________________________________

                Button sat10 = new Button();
                bool satd10 = tasksonSat.Count<SchoolTask>() >= 10;
                bool bsat10 = false;
                if (satd10)
                {
                    bsat10 = (tasksonSat.ElementAt<SchoolTask>(9) != null) /* || 
                            (tasksonSat.ElementAt<SchoolTask>(9).TaskCategoryDesc == "PERSONAL" && MeView || 
                            tasksonSat.ElementAt<SchoolTask>(9).TaskCategoryDesc == "SCHOOL" && WorkView)*/;
                }


                SetButton(tasksonSat, 9, ref sat10, bsat10);
                sat10.Clicked += (sender, e) => Alert_Clicked(InitiateButtonGetMsg(tasksonSat, 9));
                grid.Children.Add(sat10, 5, 2 + 9);

              //__________________Add All Saturday buttons__________________________
                buttonsonSat.Add(sat1);
                buttonsonSat.Add(sat2);
                buttonsonSat.Add(sat3);
                buttonsonSat.Add(sat4);
                buttonsonSat.Add(sat5);
                buttonsonSat.Add(sat6);
                buttonsonSat.Add(sat8);
                buttonsonSat.Add(sat9);
                buttonsonSat.Add(sat7);
                buttonsonSat.Add(sat10);

                //_____________________________________________________________________

                 //________________________Dimanche___1____________________________________

                Button sun1 = new Button();


                bool sund1 = tasksonSun.Count<SchoolTask>() >= 1;
                bool bsun1 = false;
                if (sund1)
                {
                    bsun1 = (tasksonSun.ElementAt<SchoolTask>(0) != null) /* || 
                            (tasksonSun.ElementAt<SchoolTask>(0).TaskCategoryDesc == "PERSONAL" && MeView || 
                            tasksonSun.ElementAt<SchoolTask>(0).TaskCategoryDesc == "SCHOOL" && WorkView)*/;
                }


                SetButton(tasksonSun, 0, ref sun1, bsun1);
                sun1.Clicked += (sender, e) => Alert_Clicked(InitiateButtonGetMsg(tasksonSun, 0));
                grid.Children.Add(sun1, 6, 2);


                //_____________________________________________________________________

                //________________________Dimanche_______2________________________________



                Button sun2 = new Button();
                bool sund2 = tasksonSun.Count<SchoolTask>() >= 2;
                bool bsun2 = false;
                if (sund2)
                {
                    bsun2 = (tasksonSun.ElementAt<SchoolTask>(1) != null) /* || 
                            (tasksonSun.ElementAt<SchoolTask>(1).TaskCategoryDesc == "PERSONAL" && MeView || 
                            tasksonSun.ElementAt<SchoolTask>(1).TaskCategoryDesc == "SCHOOL" && WorkView)*/;
                }


                SetButton(tasksonSun, 1, ref sun2, bsun2);
                sun2.Clicked += (sender, e) => Alert_Clicked(InitiateButtonGetMsg(tasksonSun, 1));
                grid.Children.Add(sun2, 6, 3);

                //_____________________________________________________________________

                //________________________Dimanche_____3__________________________________

                Button sun3 = new Button();
                bool sund3 = tasksonSun.Count<SchoolTask>() >= 3;
                bool bsun3 = false;
                if (sund3)
                {
                    bsun3 = (tasksonSun.ElementAt<SchoolTask>(2) != null) /* || 
                            (tasksonSun.ElementAt<SchoolTask>(2).TaskCategoryDesc == "PERSONAL" && MeView || 
                            tasksonSun.ElementAt<SchoolTask>(2).TaskCategoryDesc == "SCHOOL" && WorkView)*/;
                }


                SetButton(tasksonSun, 2, ref sun3, bsun3);
                sun3.Clicked += (sender, e) => Alert_Clicked(InitiateButtonGetMsg(tasksonSun, 2));
                grid.Children.Add(sun3, 6, 4);

                //_____________________________________________________________________

                //________________________Dimanche_____4__________________________________

                Button sun4 = new Button();
                bool sund4 = tasksonSun.Count<SchoolTask>() >= 4;
                bool bsun4 = false;
                if (sund4)
                {
                    bsun4 = (tasksonSun.ElementAt<SchoolTask>(3) != null) /* || 
                            (tasksonSun.ElementAt<SchoolTask>(3).TaskCategoryDesc == "PERSONAL" && MeView || 
                            tasksonSun.ElementAt<SchoolTask>(3).TaskCategoryDesc == "SCHOOL" && WorkView)*/;
                }


                SetButton(tasksonSun, 3, ref sun4, bsun4);
                sun4.Clicked += (sender, e) => Alert_Clicked(InitiateButtonGetMsg(tasksonSun, 3));
                grid.Children.Add(sun4, 6, 5);

                //_____________________________________________________________________

                //________________________Dimanche_____5__________________________________

                Button sun5 = new Button();
                bool sund5 = tasksonSun.Count<SchoolTask>() >= 5;
                bool bsun5 = false;
                if (sund5)
                {
                    bsun5 = (tasksonSun.ElementAt<SchoolTask>(4) != null) /* || 
                            (tasksonSun.ElementAt<SchoolTask>(4).TaskCategoryDesc == "PERSONAL" && MeView || 
                            tasksonSun.ElementAt<SchoolTask>(4).TaskCategoryDesc == "SCHOOL" && WorkView)*/;
                }


                SetButton(tasksonSun, 4, ref sun5, bsun5);
                sun5.Clicked += (sender, e) => Alert_Clicked(InitiateButtonGetMsg(tasksonSun, 4));
                grid.Children.Add(sun5, 6, 6);

                //_____________________________________________________________________

                //________________________Dimanche_____6__________________________________

                Button sun6 = new Button();
                bool sund6 = tasksonSun.Count<SchoolTask>() >= 6;
                bool bsun6 = false;
                if (sund6)
                {
                    bsun6 = (tasksonSun.ElementAt<SchoolTask>(5) != null) /* || 
                            (tasksonSun.ElementAt<SchoolTask>(5).TaskCategoryDesc == "PERSONAL" && MeView || 
                            tasksonSun.ElementAt<SchoolTask>(5).TaskCategoryDesc == "SCHOOL" && WorkView)*/;
                }


                SetButton(tasksonSun, 5, ref sun6, bsun6);
                sun6.Clicked += (sender, e) => Alert_Clicked(InitiateButtonGetMsg(tasksonSun, 5));
                grid.Children.Add(sun6, 6, 7);


                //_____________________________________________________________________

                //________________________Dimanche_____7__________________________________

                Button sun7 = new Button();
                bool sund7 = tasksonSun.Count<SchoolTask>() >= 7;
                bool bsun7 = false;
                if (sund7)
                {
                    bsun7 = (tasksonSun.ElementAt<SchoolTask>(6) != null) /* || 
                            (tasksonSun.ElementAt<SchoolTask>(6).TaskCategoryDesc == "PERSONAL" && MeView || 
                            tasksonSun.ElementAt<SchoolTask>(6).TaskCategoryDesc == "SCHOOL" && WorkView)*/;
                }


                SetButton(tasksonSun, 6, ref sun7, bsun7);
                sun7.Clicked += (sender, e) => Alert_Clicked(InitiateButtonGetMsg(tasksonSun, 6));
                grid.Children.Add(sun7, 6, 8);

                //_____________________________________________________________________

                //________________________Dimanche_____8__________________________________

                Button sun8 = new Button();
                bool sund8 = tasksonSun.Count<SchoolTask>() >= 8;
                bool bsun8 = false;
                if (sund8)
                {
                    bsun8 = (tasksonSun.ElementAt<SchoolTask>(7) != null) /* || 
                            (tasksonSun.ElementAt<SchoolTask>(7).TaskCategoryDesc == "PERSONAL" && MeView || 
                            tasksonSun.ElementAt<SchoolTask>(7).TaskCategoryDesc == "SCHOOL" && WorkView)*/;
                }


                SetButton(tasksonSun, 7, ref sun8, bsun8);
                sun8.Clicked += (sender, e) => Alert_Clicked(InitiateButtonGetMsg(tasksonSun, 7));
                grid.Children.Add(sun8, 6, 2 + 7);

                //_____________________________________________________________________

                //________________________Dimanche_____9__________________________________

                Button sun9 = new Button();
                bool sund9 = tasksonSun.Count<SchoolTask>() >= 9;
                bool bsun9 = false;
                if (sund9)
                {
                    bsun9 = (tasksonSun.ElementAt<SchoolTask>(8) != null) /* || 
                            (tasksonSun.ElementAt<SchoolTask>(8).TaskCategoryDesc == "PERSONAL" && MeView || 
                            tasksonSun.ElementAt<SchoolTask>(8).TaskCategoryDesc == "SCHOOL" && WorkView)*/;
                }


                SetButton(tasksonSun, 8, ref sun9, bsun9);
                sun9.Clicked += (sender, e) => Alert_Clicked(InitiateButtonGetMsg(tasksonSun, 8));
                grid.Children.Add(sun9, 6, 2 + 8);

                //_____________________________________________________________________

                //________________________Dimanche_____10__________________________________

                Button sun10 = new Button();
                bool sund10 = tasksonSun.Count<SchoolTask>() >= 10;
                bool bsun10 = false;
                if (sund10)
                {
                    bsun10 = (tasksonSun.ElementAt<SchoolTask>(9) != null) /* || 
                            (tasksonSun.ElementAt<SchoolTask>(9).TaskCategoryDesc == "PERSONAL" && MeView || 
                            tasksonSun.ElementAt<SchoolTask>(9).TaskCategoryDesc == "SCHOOL" && WorkView)*/;
                }


                SetButton(tasksonSun, 9, ref sun10, bsun10);
                sun10.Clicked += (sender, e) => Alert_Clicked(InitiateButtonGetMsg(tasksonSun, 9));
                grid.Children.Add(sun10, 6, 2 + 9);

             //__________________Add All Sunday buttons__________________________
            buttonsonSun.Add(sun1);
            buttonsonSun.Add(sun2);
            buttonsonSun.Add(sun3);
            buttonsonSun.Add(sun4);
            buttonsonSun.Add(sun5);
            buttonsonSun.Add(sun6);
            buttonsonSun.Add(sun8);
            buttonsonSun.Add(sun9);
            buttonsonSun.Add(sun7);
            buttonsonSun.Add(sun10);

            // NOTIFICATION CENTER 

            string res_for_notification = "Today's notifications: ";



if (dayofweektoday == DayOfWeek.Sunday)

{

    res_for_notification = res_for_notification + "\n" + "- Go to page Food choices this week to get a brand new meal plan for the week to come!";

}

if (MyUser.me.CleaningDayDesc == "Monday" && dayofweektoday == DayOfWeek.Monday ||

    MyUser.me.CleaningDayDesc == "Tuesday" && dayofweektoday == DayOfWeek.Tuesday ||

    MyUser.me.CleaningDayDesc == "Wednesday" && dayofweektoday == DayOfWeek.Wednesday ||

    MyUser.me.CleaningDayDesc == "Thursday" && dayofweektoday == DayOfWeek.Thursday ||

    MyUser.me.CleaningDayDesc == "Friday" && dayofweektoday == DayOfWeek.Friday ||

    MyUser.me.CleaningDayDesc == "Saturday" && dayofweektoday == DayOfWeek.Saturday ||

    MyUser.me.CleaningDayDesc == "Sunday" && dayofweektoday == DayOfWeek.Sunday

    )

{

    res_for_notification = res_for_notification + "\n" + "- Today is Cleaning Day, put your favorite playlist on and get ready to tidy your home!";

}



if (MyUser.me.ShoppingDayDesc == "Monday" && dayofweektoday == DayOfWeek.Monday ||

    MyUser.me.ShoppingDayDesc == "Tuesday" && dayofweektoday == DayOfWeek.Tuesday ||

    MyUser.me.ShoppingDayDesc == "Wednesday" && dayofweektoday == DayOfWeek.Wednesday ||

    MyUser.me.ShoppingDayDesc == "Thursday" && dayofweektoday == DayOfWeek.Thursday ||

    MyUser.me.ShoppingDayDesc == "Friday" && dayofweektoday == DayOfWeek.Friday ||

    MyUser.me.ShoppingDayDesc == "Saturday" && dayofweektoday == DayOfWeek.Saturday ||

    MyUser.me.ShoppingDayDesc == "Sunday" && dayofweektoday == DayOfWeek.Sunday

    )

{

    res_for_notification = res_for_notification + "\n" + "- Today is Shopping Day, don't forget your shopping bags and have a look at the Shopping List page if you want to follow your meal plan!";

}







var tasktoday = col.Find(Query.EQ("DueDate", localTime.Date
    ));

var nbtask = tasktoday.Count();



var NotificationCenter = new Label { Text = res_for_notification + "\n" + "You have " + nbtask + " task(s) today", FontSize = 16, TextColor = Color.BlueViolet };

grid.Children.Add(NotificationCenter, 0, 12);

Grid.SetColumnSpan(NotificationCenter, 7);

Grid.SetRowSpan(NotificationCenter, 3);







//Affichage de la grid

Content = grid;









}



private Task Alert_Clicked(string message)

{

return DisplayAlert("Description", message, "ok");

}



private void Switch_OnToggled(object sender, ToggledEventArgs e)

{

            WorkView = !WorkView; //e.Value;
            RefreshAll();

}



private void Switch2_OnToggled(object sender, ToggledEventArgs e)

{

            MeView = !MeView; //e.Value;
            RefreshAll();


}
//tasks.ElementAt<SchoolTask>(rang).TaskCategoryCode
private void SetButton(IEnumerable<SchoolTask> tasks, int rang, ref Button tasksButton, bool continuee)
        {
            if (tasks.Count<SchoolTask>() >= rang + 1)
            {
                if (continuee)
                {
                    
                    tasksButton.Text = tasks.ElementAt<SchoolTask>(rang).Description;
                    var colour = tasks.ElementAt<SchoolTask>(rang).TaskCategoryColourCode;
                    tasksButton.BackgroundColor = getColor(colour);
                    tasksButton.TextColor = getColorForText(colour);
                }
                else
                {
                    tasksButton.Text = "";
                    tasksButton.BackgroundColor = Color.Gray;
                }
            }
            else
            {
                tasksButton.Text = "";
                tasksButton.BackgroundColor = Color.Gray;
            }
        }
       
private string InitiateButtonGetMsg(IEnumerable<SchoolTask> tasks, int rang)
{ //string message = "pas de task";
string thismessage = message;
if (tasks.Count<SchoolTask>() >= rang + 1)
{
    if (tasks.ElementAt<SchoolTask>(rang) != null)
    {
        thismessage = tasks.ElementAt<SchoolTask>(rang).SubDesc;
    }
}
return thismessage;
}
        private void RefreshAll()
        {
            bool continuee1 = true;
            bool continuee2 = true;
            //Monday___________________________________________
            for (int i=0; i<buttonsonMon.Count; i++)
            {
                continuee1 = tasksonMon.Count<SchoolTask>() >= i+1;
                continuee2 = false;
                Button thisbutton = buttonsonMon[i];
                if (continuee1)
                {
                    continuee2 = (tasksonMon.ElementAt<SchoolTask>(i) != null)&& (tasksonMon.ElementAt<SchoolTask>(i).TaskCategoryDesc == "Personal" && !MeView ||
                                tasksonMon.ElementAt<SchoolTask>(i).TaskCategoryDesc == "School" && !WorkView);
                }
                SetButton(tasksonMon, i, ref thisbutton, continuee2);

            }

            //Tuesday______________________________________________
            for (int i = 0; i < buttonsonTue.Count; i++)
            {
                continuee1 = tasksonTue.Count<SchoolTask>() >= i + 1;
                continuee2 = false;
                Button thisbutton = buttonsonTue[i];
                if (continuee1)
                {
                    continuee2 = (tasksonTue.ElementAt<SchoolTask>(i) != null) && (tasksonTue.ElementAt<SchoolTask>(i).TaskCategoryDesc == "Personal" && !MeView ||
                                tasksonTue.ElementAt<SchoolTask>(i).TaskCategoryDesc == "School" && !WorkView);
                }
                SetButton(tasksonTue, i, ref thisbutton, continuee2);

            }
            //Wednesday__________________________________________
            for (int i = 0; i < buttonsonWed.Count; i++)
            {
                continuee1 = tasksonWed.Count<SchoolTask>() >= i + 1;
                continuee2 = false;
                Button thisbutton = buttonsonWed[i];
                if (continuee1)
                {
                    continuee2 = (tasksonWed.ElementAt<SchoolTask>(i) != null) && (tasksonWed.ElementAt<SchoolTask>(i).TaskCategoryDesc == "Personal" && !MeView ||
                                tasksonWed.ElementAt<SchoolTask>(i).TaskCategoryDesc == "School" && !WorkView);
                }
                SetButton(tasksonWed, i, ref thisbutton, continuee2);

            }
            //Thursday____________________________________________________
            for (int i = 0; i < buttonsonThu.Count; i++)
            {
                continuee1 = tasksonThu.Count<SchoolTask>() >= i + 1;
                continuee2 = false;
                Button thisbutton = buttonsonThu[i];
                if (continuee1)
                {
                    continuee2 = (tasksonThu.ElementAt<SchoolTask>(i) != null) && (tasksonThu.ElementAt<SchoolTask>(i).TaskCategoryDesc == "Personal" && !MeView ||
                                tasksonThu.ElementAt<SchoolTask>(i).TaskCategoryDesc == "School" && !WorkView);
                }
                SetButton(tasksonThu, i, ref thisbutton, continuee2);

            }
            //Friday______________________________________________________
            for (int i = 0; i < buttonsonFri.Count; i++)
            {
                continuee1 = tasksonFri.Count<SchoolTask>() >= i + 1;
                continuee2 = false;
                Button thisbutton = buttonsonFri[i];
                if (continuee1)
                {
                    continuee2 = (tasksonFri.ElementAt<SchoolTask>(i) != null) && (tasksonFri.ElementAt<SchoolTask>(i).TaskCategoryDesc == "Personal" && !MeView ||
                                tasksonFri.ElementAt<SchoolTask>(i).TaskCategoryDesc == "School" && !WorkView);
                }
                SetButton(tasksonFri, i, ref thisbutton, continuee2);

            }
            //Saturday________________________________________________
            for (int i = 0; i < buttonsonSat.Count; i++)
            {
                continuee1 = tasksonSat.Count<SchoolTask>() >= i + 1;
                continuee2 = false;
                Button thisbutton = buttonsonSat[i];
                if (continuee1)
                {
                    continuee2 = (tasksonSat.ElementAt<SchoolTask>(i) != null) && (tasksonSat.ElementAt<SchoolTask>(i).TaskCategoryDesc == "Personal" && !MeView ||
                                tasksonSat.ElementAt<SchoolTask>(i).TaskCategoryDesc == "School" && !WorkView);
                }
                SetButton(tasksonSat, i, ref thisbutton, continuee2);

            }
            //Sunday________________________________________________
            for (int i = 0; i < buttonsonSun.Count; i++)
            {
                continuee1 = tasksonSun.Count<SchoolTask>() >= i + 1;
                continuee2 = false;
                Button thisbutton = buttonsonSun[i];
                if (continuee1)
                {
                    continuee2 = (tasksonSun.ElementAt<SchoolTask>(i) != null) && (tasksonSun.ElementAt<SchoolTask>(i).TaskCategoryDesc == "Personal" && !MeView ||
                                tasksonSun.ElementAt<SchoolTask>(i).TaskCategoryDesc == "School" && !WorkView);
                }
                SetButton(tasksonSun, i, ref thisbutton, continuee2);

            }
        }


        public static Color getColor(string col)
        {
            Color res = Color.White;
            switch (col)
            {
                case "BLUE":
                    res = Color.Blue;
                    break;
                case "GREEN":
                    res = Color.Green;
                    break;
                case "RED":
                    res = Color.Red;
                    break;
                case "PURPLE":
                    res = Color.Purple;
                    break;
                case "BEIGE":
                    res = Color.Beige;
                    break;
                case "BLUEVIOLET":
                    res = Color.BlueViolet;
                    break;
                case "BROWN":
                    res = Color.Brown;
                    break;
                case "CORAL":
                    res = Color.Coral;
                    break;
                case "DARKBLUE":
                    res = Color.DarkBlue;
                    break;
                case "DARKMAGERNTA":
                    res = Color.DarkMagenta;
                    break;
                case "FORESTGREEN":
                    res = Color.ForestGreen;
                    break;
                case "FUCHSIA":
                    res = Color.Fuchsia;
                    break;
                case "GOLD":
                    res = Color.Gold;
                    break;
                case "GRAY":
                    res = Color.Gray;
                    break;
                case "LIGHTBLUE":
                    res = Color.LightBlue;
                    break;
                case "LIGHTGREEN":
                    res = Color.LightGreen;
                    break;
                case "MEDIUMVIOLETRED":
                    res = Color.MediumVioletRed;
                    break;
                case "BISQUE":
                    res = Color.Bisque;
                    break;
                case "CADETBLUE":
                    res = Color.CadetBlue;
                    break;
                case "SANDYBROWN":
                    res = Color.SandyBrown;
                    break;
                case "LIGHTSALMON":
                    res = Color.LightSalmon;
                    break;
                case "MIDNIGHTBLUE":
                    res = Color.MidnightBlue;
                    break;
                case "MAGENTA":
                    res = Color.Magenta;
                    break;
                case "LAWNGREEN":
                    res = Color.LawnGreen;
                    break;
                case "LIGHTPRINK":
                    res = Color.LightPink;
                    break;
                case "PALEGOLDENROD":
                    res = Color.PaleGoldenrod;
                    break;
                case "LIGHTGRAY":
                    res = Color.LightGray;
                    break;

            }


            return res;
        }

        public static Color getColorForText(string col)
        {
            Color res = Color.Black;
            switch (col)
            {
                case "BLUE":
                    res = Color.White;
                    break;
                case "GREEN":
                    res = Color.White;
                    break;
                case "RED":
                    res = Color.White;
                    break;
                case "PURPLE":
                    res = Color.White;
                    break;
                case "BEIGE":
                    res = Color.Black;
                    break;
                case "BLUEVIOLET":
                    res = Color.White;
                    break;
                case "BROWN":
                    res = Color.White;
                    break;
                case "CORAL":
                    res = Color.Black;
                    break;
                case "DARKBLUE":
                    res = Color.White;
                    break;
                case "DARKMAGERNTA":
                    res = Color.White;
                    break;
                case "FORESTGREEN":
                    res = Color.White;
                    break;
                case "FUCHSIA":
                    res = Color.Black;
                    break;
                case "GOLD":
                    res = Color.Black;
                    break;
                case "GRAY":
                    res = Color.Black;
                    break;
                case "LIGHTBLUE":
                    res = Color.Black;
                    break;
                case "LIGHTGREEN":
                    res = Color.Black;
                    break;
                case "MEDIUMVIOLETRED":
                    res = Color.Black;
                    break;
                case "BISQUE":
                    res = Color.Black;
                    break;
                case "CADETBLUE":
                    res = Color.Black;
                    break;
                case "SANDYBROWN":
                    res = Color.Black;
                    break;
                case "LIGHTSALMON":
                    res = Color.Black;
                    break;
                case "MIDNIGHTBLUE":
                    res = Color.Black;
                    break;
                case "MAGENTA":
                    res = Color.White;
                    break;
                case "LAWNGREEN":
                    res = Color.Black;
                    break;
                case "LIGHTPRINK":
                    res = Color.Black;
                    break;
                case "PALEGOLDENROD":
                    res = Color.Black;
                    break;
                case "LIGHTGRAY":
                    res = Color.Black;
                    break;

            }


            return res;
        }
    }

}
 