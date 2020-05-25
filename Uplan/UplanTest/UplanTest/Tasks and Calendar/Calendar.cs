using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;

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

        public Calendar()



        {


            //____________________________CREATION DU GRID_____________________________________
            ScrollView scroll = new ScrollView { Orientation = ScrollOrientation.Horizontal };
            var grid = new Grid();
            if (Device.RuntimePlatform == "UWP")
            {

                for (int i = 0; i < 15; i++)

                {

                    grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });

                }



                for (int j = 0; j < 7; j++)

                {

                    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

                }

            }
            else
            {

                
                scroll.Content = grid;
                for (int i = 0; i < 15; i++)

                {

                    grid.RowDefinitions.Add(new RowDefinition { Height = 50 });

                }



                for (int j = 0; j < 7; j++)

                {

                    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = 100});

                }


            }



            //grid.BackgroundColor = Color.AliceBlue;



            var Myweek = new Label { Text = "My week", FontSize = 30, FontAttributes= FontAttributes.Bold, TextColor=Color.BlueViolet };



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
                Tuesday = localTime.AddDays(1);

                Wednesday = localTime.AddDays(2);

                Thursday = localTime.AddDays(3);

                Friday = localTime.AddDays(4);

                Saturday = localTime.AddDays(5);

                Sunday = localTime.AddDays(6);

            }

            if (dayofweektoday == DayOfWeek.Tuesday)

            {
                Monday = localTime.AddDays(-1);

                Wednesday = localTime.AddDays(1);

                Thursday = localTime.AddDays(2);

                Friday = localTime.AddDays(3);

                Saturday = localTime.AddDays(4);

                Sunday = localTime.AddDays(5);

            }

            if (dayofweektoday == DayOfWeek.Wednesday)

            {
                Monday = localTime.AddDays(-2);

                Tuesday = localTime.AddDays(-1);

                Thursday = localTime.AddDays(1);

                Friday = localTime.AddDays(2);

                Saturday = localTime.AddDays(3);

                Sunday = localTime.AddDays(4);

            }

            if (dayofweektoday == DayOfWeek.Thursday)

            {
                Monday = localTime.AddDays(-3);

                Tuesday = localTime.AddDays(-2);

                Wednesday = localTime.AddDays(-1);

                Friday = localTime.AddDays(1);

                Saturday = localTime.AddDays(2);

                Sunday = localTime.AddDays(3);

            }

            if (dayofweektoday == DayOfWeek.Friday)

            {
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

            if (localTime == Monday)
            {
                CleanDataBase(Monday);
            }

            //RECUPERER PAR JOURS LES INFORMATIONS

            //enlever après
            var col = Database.db.GetCollection<SchoolTask>("SchoolTasks");

        

             tasksonMon = col.Find(Query.EQ("DueDate", Monday.Date));
             tasksonTue = col.Find(Query.EQ("DueDate", Tuesday.Date));
             tasksonWed = col.Find(Query.EQ("DueDate", Wednesday.Date));
             tasksonThu = col.Find(Query.EQ("DueDate", Thursday.Date));
             tasksonFri = col.Find(Query.EQ("DueDate", Friday.Date));
             tasksonSat = col.Find(Query.EQ("DueDate", Saturday.Date));
             tasksonSun = col.Find(Query.EQ("DueDate", Sunday.Date));


            //TRIER LES INFORMATIONS



            //CREATION DES BOUTONDS POUR LES MODES



            Switch swiSchool = new Switch

            {
                IsToggled= true,

                HorizontalOptions = LayoutOptions.Center,

                VerticalOptions = LayoutOptions.CenterAndExpand,

                OnColor = Color.BlueViolet

            };
            swiSchool.Toggled += Switch_OnToggled;

           



            var Work = new Label { Text = "Work", FontSize = 10, HorizontalOptions = LayoutOptions.Center };
            if (Device.RuntimePlatform=="UWP")
            {
                grid.Children.Add(swiSchool, 4, 0);
                grid.Children.Add(Work, 4, 0);
            }

            else
            {
                grid.Children.Add(swiSchool, 2, 0);
                grid.Children.Add(Work, 2, 0);
            }


            //_____________________ Bouton Add
            ImageButton addEvent = new ImageButton();
            addEvent.Source = "Assets/add_round.png";
            addEvent.Clicked += (sender, e) => GotoNewEvent();
            if (Device.RuntimePlatform == "UWP")
            {
                grid.Children.Add(addEvent, 0, 12);
            }
            else
            {
                grid.Children.Add(addEvent, 0, 8);
            }
            
            //______________________ Bouton View
            ImageButton ViewsEvents = new ImageButton();
            ViewsEvents.Source = "Assets/eye2.png";
            ViewsEvents.WidthRequest = 40;
            ViewsEvents.HeightRequest = 40;
            ViewsEvents.Clicked += (sender, e) => GotoViewEvents();
            if (Device.RuntimePlatform == "UWP")
            {
                grid.Children.Add(ViewsEvents, 0, 13);
            }
            else
            {
                grid.Children.Add(ViewsEvents, 0, 9);
            }

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
                (string resmsg1, SchoolTask restask1) = InitiateButtonGetMsg(tasksonMon, 0);
                mon1.Clicked += async (sender, e) => await Alert_Clicked(resmsg1,restask1);
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
                (string resmsg2, SchoolTask restask2) = InitiateButtonGetMsg(tasksonMon, 1);
                mon2.Clicked += async (sender, e) => await Alert_Clicked(resmsg2, restask2);
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
                (string resmsg3, SchoolTask restask3) = InitiateButtonGetMsg(tasksonMon, 2);
                mon3.Clicked += async (sender, e) => await Alert_Clicked(resmsg3, restask3);
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
                (string resmsg4, SchoolTask restask4) = InitiateButtonGetMsg(tasksonMon, 3);
                mon4.Clicked += async (sender, e) => await Alert_Clicked(resmsg4, restask4);
                //mon4.Clicked += (sender, e) => Alert_Clicked(InitiateButtonGetMsg(tasksonMon, 3));
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
                (string resmsg5, SchoolTask restask5) = InitiateButtonGetMsg(tasksonMon, 4);
                mon5.Clicked += async (sender, e) => await Alert_Clicked(resmsg5, restask5);
                
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
                (string resmsg6, SchoolTask restask6) = InitiateButtonGetMsg(tasksonMon, 5);
                mon6.Clicked += async (sender, e) => await Alert_Clicked(resmsg3, restask3);
                //mon6.Clicked += (sender, e) => Alert_Clicked(InitiateButtonGetMsg(tasksonMon, 5));
                grid.Children.Add(mon6, 0, 7);
                buttonsonMon.Add(mon6);

            if (Device.RuntimePlatform == "UWP")
            {


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
                (string resmsg7, SchoolTask restask7) = InitiateButtonGetMsg(tasksonMon, 6);
                mon7.Clicked += async (sender, e) => await Alert_Clicked(resmsg7, restask7);
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
                (string resmsg8, SchoolTask restask8) = InitiateButtonGetMsg(tasksonMon, 7);
                mon8.Clicked += async (sender, e) => await Alert_Clicked(resmsg8, restask8);
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
                (string resmsg9, SchoolTask restask9) = InitiateButtonGetMsg(tasksonMon, 8);
                mon9.Clicked += async (sender, e) => await Alert_Clicked(resmsg9, restask9);
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
                (string resmsg10, SchoolTask restask10) = InitiateButtonGetMsg(tasksonMon, 9);
                mon10.Clicked += async (sender, e) => await Alert_Clicked(resmsg10, restask10);
                grid.Children.Add(mon10, 0, 2 + 9);
                buttonsonMon.Add(mon10);
            }

            

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
                (string resmsgM1, SchoolTask restaskM1) = InitiateButtonGetMsg(tasksonTue, 0);
                tue1.Clicked += async (sender, e) => await Alert_Clicked(resmsgM1, restaskM1);
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
                (string resmsgM2, SchoolTask restaskM2) = InitiateButtonGetMsg(tasksonTue, 1);
                tue2.Clicked += async (sender, e) => await Alert_Clicked(resmsgM2, restaskM2);
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
                (string resmsgM3, SchoolTask restaskM3) = InitiateButtonGetMsg(tasksonTue, 2);
                tue3.Clicked += async (sender, e) => await Alert_Clicked(resmsgM3, restaskM3);
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
                (string resmsgM4, SchoolTask restaskM4) = InitiateButtonGetMsg(tasksonTue, 3);
                tue4.Clicked += async (sender, e) => await Alert_Clicked(resmsgM4, restaskM4);
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
                (string resmsgM5, SchoolTask restaskM5) = InitiateButtonGetMsg(tasksonTue, 4);
                tue5.Clicked += async (sender, e) => await Alert_Clicked(resmsgM5, restaskM5);
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
                (string resmsgM6, SchoolTask restaskM6) = InitiateButtonGetMsg(tasksonTue, 5);
                tue6.Clicked += async (sender, e) => await Alert_Clicked(resmsgM1, restaskM1);
                grid.Children.Add(tue6, 1, 7);
                buttonsonTue.Add(tue6);

            if (Device.RuntimePlatform == "UWP")
            {

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
                (string resmsgM7, SchoolTask restaskM7) = InitiateButtonGetMsg(tasksonTue, 6);
                tue7.Clicked += async (sender, e) => await Alert_Clicked(resmsgM7, restaskM7);
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
                (string resmsgM8, SchoolTask restaskM8) = InitiateButtonGetMsg(tasksonTue, 7);
                tue8.Clicked += async (sender, e) => await Alert_Clicked(resmsgM8, restaskM8);
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
                (string resmsgM9, SchoolTask restaskM9) = InitiateButtonGetMsg(tasksonTue, 8);
                tue9.Clicked += async (sender, e) => await Alert_Clicked(resmsgM9, restaskM9);
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
                (string resmsgM10, SchoolTask restaskM10) = InitiateButtonGetMsg(tasksonTue, 0);
                tue10.Clicked += async (sender, e) => await Alert_Clicked(resmsgM10, restaskM10);
                grid.Children.Add(tue10, 1, 2 + 9);
                buttonsonTue.Add(tue10);

            }    //_____________________________________________________________________

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
                (string resmsgME1, SchoolTask restaskME1) = InitiateButtonGetMsg(tasksonWed, 0);
                wed1.Clicked += async (sender, e) => await Alert_Clicked(resmsgME1, restaskME1);
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
                (string resmsgME2, SchoolTask restaskME2) = InitiateButtonGetMsg(tasksonWed, 1);
                wed2.Clicked += async (sender, e) => await Alert_Clicked(resmsgME2, restaskME2);
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
                (string resmsgME3, SchoolTask restaskME3) = InitiateButtonGetMsg(tasksonWed, 2);
                wed3.Clicked += async (sender, e) => await Alert_Clicked(resmsgME3, restaskME3);

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
                (string resmsgME4, SchoolTask restaskME4) = InitiateButtonGetMsg(tasksonWed, 3);
                wed4.Clicked += async (sender, e) => await Alert_Clicked(resmsgME4, restaskME4);

            
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
                (string resmsgME5, SchoolTask restaskME5) = InitiateButtonGetMsg(tasksonWed, 4);
                wed5.Clicked += async (sender, e) => await Alert_Clicked(resmsgME5, restaskME5);

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
                (string resmsgME6, SchoolTask restaskME6) = InitiateButtonGetMsg(tasksonWed, 5);
                wed6.Clicked += async (sender, e) => await Alert_Clicked(resmsgME6, restaskME6);

           
                grid.Children.Add(wed6, 2, 7);
                buttonsonWed.Add(wed6);



            if (Device.RuntimePlatform == "UWP")

            {
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
                (string resmsgME7, SchoolTask restaskME7) = InitiateButtonGetMsg(tasksonWed, 6);
                wed7.Clicked += async (sender, e) => await Alert_Clicked(resmsgME7, restaskME7);

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
                (string resmsgME8, SchoolTask restaskME8) = InitiateButtonGetMsg(tasksonWed, 7);
                wed8.Clicked += async (sender, e) => await Alert_Clicked(resmsgME8, restaskME8);
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
                (string resmsgME9, SchoolTask restaskME9) = InitiateButtonGetMsg(tasksonWed, 8);
                wed9.Clicked += async (sender, e) => await Alert_Clicked(resmsgME9, restaskME9);

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
                (string resmsgME10, SchoolTask restaskME10) = InitiateButtonGetMsg(tasksonWed, 9);
                wed10.Clicked += async (sender, e) => await Alert_Clicked(resmsgME10, restaskME10);
                grid.Children.Add(wed10, 2, 2 + 9);
                buttonsonWed.Add(wed10);

            }    //_____________________________________________________________________

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
                (string resmsgJ1, SchoolTask restaskJ1) = InitiateButtonGetMsg(tasksonThu, 0);
                thu1.Clicked += async (sender, e) => await Alert_Clicked(resmsgJ1, restaskJ1);
            
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
                (string resmsgJ2, SchoolTask restaskJ2) = InitiateButtonGetMsg(tasksonThu, 1);
                 thu2.Clicked += async (sender, e) => await Alert_Clicked(resmsgJ2, restaskJ2);
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
                (string resmsgJ3, SchoolTask restaskJ3) = InitiateButtonGetMsg(tasksonThu, 2);
                thu3.Clicked += async (sender, e) => await Alert_Clicked(resmsgJ3, restaskJ3);
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
                (string resmsgJ4, SchoolTask restaskJ4) = InitiateButtonGetMsg(tasksonThu, 3);
                thu4.Clicked += async (sender, e) => await Alert_Clicked(resmsgJ4, restaskJ4);
            
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
                (string resmsgJ5, SchoolTask restaskJ5) = InitiateButtonGetMsg(tasksonThu, 4);
                thu5.Clicked += async (sender, e) => await Alert_Clicked(resmsgJ5, restaskJ5);
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
                (string resmsgJ6, SchoolTask restaskJ6) = InitiateButtonGetMsg(tasksonThu, 5);
                thu6.Clicked += async (sender, e) => await Alert_Clicked(resmsgJ6, restaskJ6);
                grid.Children.Add(thu6, 3, 7);

            if (Device.RuntimePlatform == "UWP")
            {
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
                (string resmsgJ7, SchoolTask restaskJ7) = InitiateButtonGetMsg(tasksonThu, 6);
                thu7.Clicked += async (sender, e) => await Alert_Clicked(resmsgJ7, restaskJ7);
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
                (string resmsgJ8, SchoolTask restaskJ8) = InitiateButtonGetMsg(tasksonThu, 7);
                thu8.Clicked += async (sender, e) => await Alert_Clicked(resmsgJ8, restaskJ8);
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
                (string resmsgJ9, SchoolTask restaskJ9) = InitiateButtonGetMsg(tasksonThu, 8);
                thu9.Clicked += async (sender, e) => await Alert_Clicked(resmsgJ9, restaskJ9);

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
                (string resmsgJ10, SchoolTask restaskJ10) = InitiateButtonGetMsg(tasksonThu, 9);
                thu10.Clicked += async (sender, e) => await Alert_Clicked(resmsgJ10, restaskJ10);

                grid.Children.Add(thu10, 3, 2 + 9);

                buttonsonThu.Add(thu7);
                buttonsonThu.Add(thu8);
                buttonsonThu.Add(thu9);
                buttonsonThu.Add(thu10);

            }

                //__________________Add All Thursday buttons__________________________
                buttonsonThu.Add(thu1);
                buttonsonThu.Add(thu2);
                buttonsonThu.Add(thu3);
                buttonsonThu.Add(thu4);
                buttonsonThu.Add(thu5);
                buttonsonThu.Add(thu6);
            
            
               
            
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
                (string resmsgF1, SchoolTask restaskF1) = InitiateButtonGetMsg(tasksonFri, 0);
                fri1.Clicked += async (sender, e) => await Alert_Clicked(resmsgF1, restaskF1);
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
                (string resmsgF2, SchoolTask restaskF2) = InitiateButtonGetMsg(tasksonFri, 1);
                fri2.Clicked += async (sender, e) => await Alert_Clicked(resmsgF2, restaskF2);
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
                (string resmsgF3, SchoolTask restaskF3) = InitiateButtonGetMsg(tasksonFri, 2);
                fri3.Clicked += async (sender, e) => await Alert_Clicked(resmsgF3, restaskF3);
            
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
                (string resmsgF4, SchoolTask restaskF4) = InitiateButtonGetMsg(tasksonFri, 3);
                fri4.Clicked += async (sender, e) => await Alert_Clicked(resmsgF4, restaskF4);
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
                (string resmsgF5, SchoolTask restaskF5) = InitiateButtonGetMsg(tasksonFri, 4);
                fri5.Clicked += async (sender, e) => await Alert_Clicked(resmsgF5, restaskF5);
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
                (string resmsgF6, SchoolTask restaskF6) = InitiateButtonGetMsg(tasksonFri, 5);
                fri6.Clicked += async (sender, e) => await Alert_Clicked(resmsgF6, restaskF6);
                grid.Children.Add(fri6, 4, 7);


            //_____________________________________________________________________

            //________________________Vendredi_____7__________________________________

            if (Device.RuntimePlatform == "UWP")
            {



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
                (string resmsgF7, SchoolTask restaskF7) = InitiateButtonGetMsg(tasksonFri, 6);
                fri7.Clicked += async (sender, e) => await Alert_Clicked(resmsgF7, restaskF7);
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
                (string resmsgF8, SchoolTask restaskF8) = InitiateButtonGetMsg(tasksonFri, 7);
                fri8.Clicked += async (sender, e) => await Alert_Clicked(resmsgF8, restaskF8);
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
                (string resmsgF9, SchoolTask restaskF9) = InitiateButtonGetMsg(tasksonFri, 8);
                fri9.Clicked += async (sender, e) => await Alert_Clicked(resmsgF9, restaskF9);

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
                (string resmsgF10, SchoolTask restaskF10) = InitiateButtonGetMsg(tasksonFri, 9);
                fri10.Clicked += async (sender, e) => await Alert_Clicked(resmsgF10, restaskF10);
                grid.Children.Add(fri10, 4, 2 + 9);
                buttonsonFri.Add(fri7);
                buttonsonFri.Add(fri8);
                buttonsonFri.Add(fri9);
                buttonsonFri.Add(fri10);
            }
                //__________________Add All Friday buttons__________________________
                buttonsonFri.Add(fri1);
                buttonsonFri.Add(fri2);
                buttonsonFri.Add(fri3);
                buttonsonFri.Add(fri4);
                buttonsonFri.Add(fri5);
                buttonsonFri.Add(fri6);
               
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
                (string resmsgSA1, SchoolTask restaskSA1) = InitiateButtonGetMsg(tasksonSat, 0);
                sat1.Clicked += async (sender, e) => await Alert_Clicked(resmsgSA1, restaskSA1);
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
                (string resmsgSA2, SchoolTask restaskSA2) = InitiateButtonGetMsg(tasksonSat, 1);
                sat2.Clicked += async (sender, e) => await Alert_Clicked(resmsgSA2, restaskSA2);
            
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
                (string resmsgSA3, SchoolTask restaskSA3) = InitiateButtonGetMsg(tasksonSat, 2);
                sat3.Clicked += async (sender, e) => await Alert_Clicked(resmsgSA3, restaskSA3);
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
                (string resmsgSA4, SchoolTask restaskSA4) = InitiateButtonGetMsg(tasksonSat, 3);
                sat4.Clicked += async (sender, e) => await Alert_Clicked(resmsgSA4, restaskSA4);
            
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
                (string resmsgSA5, SchoolTask restaskSA5) = InitiateButtonGetMsg(tasksonSat, 4);
                sat5.Clicked += async (sender, e) => await Alert_Clicked(resmsgSA5, restaskSA5);
            
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
                (string resmsgSA6, SchoolTask restaskSA6) = InitiateButtonGetMsg(tasksonSat, 5);
                sat6.Clicked += async (sender, e) => await Alert_Clicked(resmsgSA6, restaskSA6);
           
                grid.Children.Add(sat6, 5, 7);


            //_____________________________________________________________________

            //________________________Samedi_____7__________________________________

            if (Device.RuntimePlatform == "UWP")
            {


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
                (string resmsgSA7, SchoolTask restaskSA7) = InitiateButtonGetMsg(tasksonSat, 6);
                sat7.Clicked += async (sender, e) => await Alert_Clicked(resmsgSA7, restaskSA7);
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
                (string resmsgSA8, SchoolTask restaskSA8) = InitiateButtonGetMsg(tasksonSat, 7);
                sat8.Clicked += async (sender, e) => await Alert_Clicked(resmsgSA8, restaskSA8);
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
                (string resmsgSA9, SchoolTask restaskSA9) = InitiateButtonGetMsg(tasksonSat, 8);
                sat9.Clicked += async (sender, e) => await Alert_Clicked(resmsgSA9, restaskSA9);

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
                (string resmsgSA10, SchoolTask restaskSA10) = InitiateButtonGetMsg(tasksonSat, 9);
                sat10.Clicked += async (sender, e) => await Alert_Clicked(resmsgSA10, restaskSA10);
                grid.Children.Add(sat10, 5, 2 + 9);

                buttonsonSat.Add(sat8);
                buttonsonSat.Add(sat9);
                buttonsonSat.Add(sat7);
                buttonsonSat.Add(sat10);
            }
              //__________________Add All Saturday buttons__________________________
                buttonsonSat.Add(sat1);
                buttonsonSat.Add(sat2);
                buttonsonSat.Add(sat3);
                buttonsonSat.Add(sat4);
                buttonsonSat.Add(sat5);
                buttonsonSat.Add(sat6);
               

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
                (string resmsgSU1, SchoolTask restaskSU1) = InitiateButtonGetMsg(tasksonSun, 0);
                sun1.Clicked += async (sender, e) => await Alert_Clicked(resmsgSU1, restaskSU1);
            
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
                (string resmsgSU2, SchoolTask restaskSU2) = InitiateButtonGetMsg(tasksonSun, 1);
                sun2.Clicked += async (sender, e) => await Alert_Clicked(resmsgSU2, restaskSU2);
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
                (string resmsgSU3, SchoolTask restaskSU3) = InitiateButtonGetMsg(tasksonSun, 2);
                sun3.Clicked += async (sender, e) => await Alert_Clicked(resmsgSU3, restaskSU3);
           
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
                (string resmsgSU4, SchoolTask restaskSU4) = InitiateButtonGetMsg(tasksonSun, 3);
                sun4.Clicked += async (sender, e) => await Alert_Clicked(resmsgSU4, restaskSU4);
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
                (string resmsgSU5, SchoolTask restaskSU5) = InitiateButtonGetMsg(tasksonSun, 4);
                sun5.Clicked += async (sender, e) => await Alert_Clicked(resmsgSU5, restaskSU5);
            
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
                (string resmsgSU6, SchoolTask restaskSU6) = InitiateButtonGetMsg(tasksonSun, 5);
                sun6.Clicked += async (sender, e) => await Alert_Clicked(resmsgSU6, restaskSU6);
                grid.Children.Add(sun6, 6, 7);


            //_____________________________________________________________________

            //________________________Dimanche_____7__________________________________
            if (Device.RuntimePlatform == "UWP")
            {


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
                (string resmsgSU7, SchoolTask restaskSU7) = InitiateButtonGetMsg(tasksonSun, 6);
                sun7.Clicked += async (sender, e) => await Alert_Clicked(resmsgSU7, restaskSU7);
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
                (string resmsgSU8, SchoolTask restaskSU8) = InitiateButtonGetMsg(tasksonSun, 7);
                sun8.Clicked += async (sender, e) => await Alert_Clicked(resmsgSU8, restaskSU8);
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
                (string resmsgSU9, SchoolTask restaskSU9) = InitiateButtonGetMsg(tasksonSun, 8);
                sun9.Clicked += async (sender, e) => await Alert_Clicked(resmsgSU9, restaskSU9);
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
                (string resmsgSU10, SchoolTask restaskSU10) = InitiateButtonGetMsg(tasksonSun, 9);
                sun10.Clicked += async (sender, e) => await Alert_Clicked(resmsgSU10, restaskSU10);
                grid.Children.Add(sun10, 6, 2 + 9);

                buttonsonSun.Add(sun8);
                buttonsonSun.Add(sun9);
                buttonsonSun.Add(sun7);
                buttonsonSun.Add(sun10);

            }
            //__________________Add All Sunday buttons__________________________
            buttonsonSun.Add(sun1);
            buttonsonSun.Add(sun2);
            buttonsonSun.Add(sun3);
            buttonsonSun.Add(sun4);
            buttonsonSun.Add(sun5);
            buttonsonSun.Add(sun6);
            
            // NOTIFICATION CENTER 

            string res_for_notification = "Today's notifications: ";



            if (dayofweektoday == DayOfWeek.Sunday)
            {
                 res_for_notification = res_for_notification + "\n" + "- Go to page Food choices this week to get a brand new meal plan for the week to come!"; }

            if (MyUser.me.CleaningDayDesc == "Monday" && dayofweektoday == DayOfWeek.Monday ||

                MyUser.me.CleaningDayDesc == "Tuesday" && dayofweektoday == DayOfWeek.Tuesday ||

                MyUser.me.CleaningDayDesc == "Wednesday" && dayofweektoday == DayOfWeek.Wednesday ||

                MyUser.me.CleaningDayDesc == "Thursday" && dayofweektoday == DayOfWeek.Thursday ||

                MyUser.me.CleaningDayDesc == "Friday" && dayofweektoday == DayOfWeek.Friday ||

                MyUser.me.CleaningDayDesc == "Saturday" && dayofweektoday == DayOfWeek.Saturday ||

                MyUser.me.CleaningDayDesc == "Sunday" && dayofweektoday == DayOfWeek.Sunday)
                { res_for_notification = res_for_notification + "\n" + "- Today is Cleaning Day, put your favorite playlist on and get ready to tidy your home!";}

            if (MyUser.me.ShoppingDayDesc == "Monday" && dayofweektoday == DayOfWeek.Monday ||
                MyUser.me.ShoppingDayDesc == "Tuesday" && dayofweektoday == DayOfWeek.Tuesday ||
                MyUser.me.ShoppingDayDesc == "Wednesday" && dayofweektoday == DayOfWeek.Wednesday ||
                MyUser.me.ShoppingDayDesc == "Thursday" && dayofweektoday == DayOfWeek.Thursday ||
                MyUser.me.ShoppingDayDesc == "Friday" && dayofweektoday == DayOfWeek.Friday ||
                MyUser.me.ShoppingDayDesc == "Saturday" && dayofweektoday == DayOfWeek.Saturday ||
                MyUser.me.ShoppingDayDesc == "Sunday" && dayofweektoday == DayOfWeek.Sunday){
                res_for_notification = res_for_notification + "\n" + "- Today is Shopping Day, don't forget your shopping bags and have a look at the Shopping List page if you want to follow your meal plan!"; }


            var tasktoday = col.Find(Query.EQ("DueDate", localTime.Date));
            var nbtask = tasktoday.Count();

            var NotificationCenter = new Label { Text = res_for_notification + "\n" + "You have " + nbtask + " task(s) today", FontSize = 16, TextColor = Color.BlueViolet };

            if (Device.RuntimePlatform == "UWP")
            {
                grid.Children.Add(NotificationCenter, 1, 12);

            }
            else
            {
                grid.Children.Add(NotificationCenter, 1, 8);

            }
            

            Grid.SetColumnSpan(NotificationCenter, 6);

            Grid.SetRowSpan(NotificationCenter, 3);







            //Affichage de la grid

            if (Device.RuntimePlatform == "UWP")
            {
                Content = grid;
            }
            else
            {
                Content = scroll;
            }

}

        async private void GotoViewEvents()
        {
            await Navigation.PushAsync(new SeeTasks());
        }

        async private void GotoNewEvent()
        {
            await Navigation.PushAsync(new AddEvent());
        }

        async private Task Alert_Clicked(string message, SchoolTask liltask)

        {

            //return DisplayAlert("Description", message, "ok");

            bool answer = await DisplayAlert("Description", message, "ok", "Delete task");
            if (!answer && liltask!=null)
            {
                var col = Database.db.GetCollection<SchoolTask>("SchoolTasks");
                col.Delete(liltask.Id);
                RefreshAll();
            }
        }



private void Switch_OnToggled(object sender, ToggledEventArgs e)

{

            WorkView = !WorkView; //e.Value;
            RefreshAll();

}

        async private void GotoNewEvent(object sender, ToggledEventArgs e)
        {
            await Navigation.PushAsync(new AddEvent());
        }

        async private void GotoViewEvents(object sender, ToggledEventArgs e)
        {
            await Navigation.PushAsync(new SeeTasks());
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
       
        private (string, SchoolTask) InitiateButtonGetMsg(IEnumerable<SchoolTask> tasks, int rang)
      { //string message = "pas de task";
            string thismessage = message;
            SchoolTask thistask = null;
            if (tasks.Count<SchoolTask>() >= rang + 1)
                {
                    if (tasks.ElementAt<SchoolTask>(rang) != null)
                        {
                             thismessage = tasks.ElementAt<SchoolTask>(rang).SubDesc;
                             thistask = tasks.ElementAt<SchoolTask>(rang);
                         }
                 }
            return (thismessage,thistask);
      }
        public void RefreshAll()
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

        public static void CleanDataBase(DateTime monday)
        {
            var col = Database.db.GetCollection<SchoolTask>("SchoolTasks");
            IEnumerable<SchoolTask> databaseoftheday;

            for (int i = 0; i < 7; i++)
            {
                databaseoftheday= col.Find(Query.EQ("DueDate", monday.AddDays(-1-i).Date));
                foreach (var item in databaseoftheday)
                {
                    col.Delete(item.Id);
                }
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
 