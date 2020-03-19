using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Threading.Tasks;



using LiteDB;

using Xamarin.Forms;



namespace UplanTest

{

    public class CALENDRIER : ContentPage

    {

        private bool WorkView;

        private bool MeView;

        private string message = "no task";



        //Button mon1;

        public CALENDRIER()



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

            DateTime Monday = localTime;

            DateTime Tuesday = localTime;

            DateTime Wednesday = localTime;

            DateTime Thursday = localTime;

            DateTime Friday = localTime;

            DateTime Saturday = localTime;

            DateTime Sunday = localTime;



            if (dayofweektoday == DayOfWeek.Monday)

            {

                Monday = localTime;

                Tuesday = localTime.AddDays(1);

                Wednesday = localTime.AddDays(2);

                Thursday = localTime.AddDays(3);

                Friday = localTime.AddDays(4);

                Saturday = localTime.AddDays(5);

                Sunday = localTime.AddDays(6);

            }

            if (dayofweektoday == DayOfWeek.Tuesday)

            {

                Tuesday = localTime;

                Monday = localTime.AddDays(-1);

                Wednesday = localTime.AddDays(1);

                Thursday = localTime.AddDays(2);

                Friday = localTime.AddDays(3);

                Saturday = localTime.AddDays(4);

                Sunday = localTime.AddDays(5);

            }

            if (dayofweektoday == DayOfWeek.Wednesday)

            {

                Wednesday = localTime;

                Monday = localTime.AddDays(-2);

                Tuesday = localTime.AddDays(-1);

                Thursday = localTime.AddDays(1);

                Friday = localTime.AddDays(2);

                Saturday = localTime.AddDays(3);

                Sunday = localTime.AddDays(4);

            }

            if (dayofweektoday == DayOfWeek.Thursday)

            {

                Thursday = localTime;

                Monday = localTime.AddDays(-3);

                Tuesday = localTime.AddDays(-2);

                Wednesday = localTime.AddDays(-1);

                Friday = localTime.AddDays(1);

                Saturday = localTime.AddDays(2);

                Sunday = localTime.AddDays(3);

            }

            if (dayofweektoday == DayOfWeek.Friday)

            {

                Friday = localTime;

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

                Sunday = localTime;

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



            var tasksonMon = col.Find(Query.EQ("DueDate", Monday));

            var tasksonTue = col.Find(Query.EQ("DueDate", Tuesday));

            var tasksonWed = col.Find(Query.EQ("DueDate", Wednesday));

            var tasksonThu = col.Find(Query.EQ("DueDate", Thursday));

            var tasksonFri = col.Find(Query.EQ("DueDate", Friday));

            var tasksonSat = col.Find(Query.EQ("DueDate", Saturday));

            var tasksonSun = col.Find(Query.EQ("DueDate", Sunday));



            //TRIER LES INFORMATIONS



            //CREATION DES BOUTONDS POUR LES MODES



            Switch swiSchool = new Switch

            {

                HorizontalOptions = LayoutOptions.Center,

                VerticalOptions = LayoutOptions.CenterAndExpand,

                OnColor = Color.BlueViolet

            };

            swiSchool.Toggled += Switch_OnToggled;

            grid.Children.Add(swiSchool, 4, 0);



            var Work = new Label { Text = "Work", FontSize = 10, HorizontalOptions = LayoutOptions.Center };

            grid.Children.Add(Work, 4, 0);





            Switch swiMe = new Switch

            {

                HorizontalOptions = LayoutOptions.Center,

                VerticalOptions = LayoutOptions.CenterAndExpand,

                OnColor = Color.BlueViolet

            };

            swiMe.Toggled += Switch2_OnToggled;

            grid.Children.Add(swiMe, 3, 0);



            var Me = new Label { Text = "Me", FontSize = 10, HorizontalOptions = LayoutOptions.Center };

            grid.Children.Add(Me, 3, 0);



            //Creation des jours de la semaine

            var Lun = new Label { Text = "Monday", FontSize = 20, HorizontalOptions = LayoutOptions.Center };

            grid.Children.Add(Lun, 0, 1);



            var Mar = new Label { Text = "Tuesday", FontSize = 20, HorizontalOptions = LayoutOptions.Center };

            grid.Children.Add(Mar, 1, 1);



            var Mer = new Label { Text = "Wednesday", FontSize = 20, HorizontalOptions = LayoutOptions.Center };

            grid.Children.Add(Mer, 2, 1);



            var Jeu = new Label { Text = "Thursday", FontSize = 20, HorizontalOptions = LayoutOptions.Center };

            grid.Children.Add(Jeu, 3, 1);



            var Fri = new Label { Text = "Friday", FontSize = 20, HorizontalOptions = LayoutOptions.Center };

            grid.Children.Add(Fri, 4, 1);



            var Sam = new Label { Text = "Saturday", FontSize = 20, HorizontalOptions = LayoutOptions.Center };

            grid.Children.Add(Sam, 5, 1);



            var Dim = new Label { Text = "Sunday", FontSize = 20, HorizontalOptions = LayoutOptions.Center };

            grid.Children.Add(Dim, 6, 1);

            //CR2ATION DES 70 BOUTONS

            int collumn = 0;

            //_____________________________________________________________________

            //________________________Lundi___1____________________________________



            Button mon1 = new Button();

            int rang = 0;





            if (tasksonMon.Count<SchoolTask>() != 0)

            {


                if ((tasksonMon.ElementAt<SchoolTask>(rang) != null) || (tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "PERSONAL" && MeView || tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "SCHOOL" && WorkView))

                {

                    mon1.Text = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc;

                    var colour = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryColourDesc;

                    mon1.BackgroundColor = Color.FromHex(colour);

                }

                else

                {

                    mon1.Text = "";

                }

            }

            else

            {

                mon1.Text = "";

            }

            //string message = "pas de task";

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null)

                {

                    message = tasksonMon.ElementAt<SchoolTask>(rang).SubDesc;

                }

            }



            mon1.Clicked += (sender, e) => Alert_Clicked(message);

            grid.Children.Add(mon1, collumn, 2 + rang);

            //_____________________________________________________________________

            //________________________Lundi_______2________________________________



            Button mon2 = new Button();

            rang = 1;

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null && (tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "PERSONAL" && MeView || tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "SCHOOL" && WorkView))

                {

                    mon2.Text = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc;

                    var colour = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryColourDesc;

                    mon2.BackgroundColor = Color.FromHex(colour);

                }

                else

                {

                    mon2.Text = "";

                }

            }

            else

            {

                mon2.Text = "";

            }

            //string message = "pas de task";

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null)

                {

                    message = tasksonMon.ElementAt<SchoolTask>(rang).SubDesc;

                }

            }



            mon2.Clicked += (sender, e) => Alert_Clicked(message);

            grid.Children.Add(mon2, collumn, 2 + rang);



            //_____________________________________________________________________

            //________________________Lundi_____3__________________________________



            Button mon3 = new Button();

            rang = 2;

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null && (tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "PERSONAL" && MeView || tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "SCHOOL" && WorkView))

                {

                    mon3.Text = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc;

                    var colour = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryColourDesc;

                    mon3.BackgroundColor = Color.FromHex(colour);

                }

                else

                {

                    mon3.Text = "";

                }

            }

            else

            {

                mon3.Text = "";

            }

            //string message = "pas de task";

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null)

                {

                    message = tasksonMon.ElementAt<SchoolTask>(rang).SubDesc;

                }

            }



            mon3.Clicked += (sender, e) => Alert_Clicked(message);

            grid.Children.Add(mon3, collumn, 2 + rang);



            //_____________________________________________________________________

            //________________________Lundi_____4__________________________________



            Button mon4 = new Button();

            rang = 3;

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null && (tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "PERSONAL" && MeView || tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "SCHOOL" && WorkView))

                {

                    mon4.Text = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc;

                    var colour = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryColourDesc;

                    mon4.BackgroundColor = Color.FromHex(colour);

                }

                else

                {

                    mon4.Text = "";

                }

            }

            else

            {

                mon4.Text = "";

            }

            //string message = "pas de task";

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null)

                {

                    message = tasksonMon.ElementAt<SchoolTask>(rang).SubDesc;

                }

            }



            mon4.Clicked += (sender, e) => Alert_Clicked(message);

            grid.Children.Add(mon4, collumn, 2 + rang);

            //_____________________________________________________________________

            //________________________Lundi_____5__________________________________

            Button mon5 = new Button();

            rang = 4;

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null && (tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "PERSONAL" && MeView || tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "SCHOOL" && WorkView))

                {

                    mon5.Text = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc;

                    var colour = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryColourDesc;

                    mon5.BackgroundColor = Color.FromHex(colour);

                }

                else

                {

                    mon5.Text = "";

                }

            }

            else

            {

                mon5.Text = "";

            }

            //string message = "pas de task";

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null)

                {

                    message = tasksonMon.ElementAt<SchoolTask>(rang).SubDesc;

                }

            }



            mon5.Clicked += (sender, e) => Alert_Clicked(message);

            grid.Children.Add(mon5, collumn, 2 + rang);



            //_____________________________________________________________________

            //________________________Lundi_____6__________________________________

            Button mon6 = new Button();

            rang = 5;

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null && (tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "PERSONAL" && MeView || tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "SCHOOL" && WorkView))

                {

                    mon6.Text = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc;

                    var colour = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryColourDesc;

                    mon6.BackgroundColor = Color.FromHex(colour);

                }

                else

                {

                    mon6.Text = "";

                }

            }

            else

            {

                mon6.Text = "";

            }

            //string message = "pas de task";

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null)

                {

                    message = tasksonMon.ElementAt<SchoolTask>(rang).SubDesc;

                }

            }



            mon6.Clicked += (sender, e) => Alert_Clicked(message);

            grid.Children.Add(mon6, collumn, 2 + rang);



            //_____________________________________________________________________

            //________________________Lundi_____7__________________________________

            Button mon7 = new Button();

            rang = 6;

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null && (tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "PERSONAL" && MeView || tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "SCHOOL" && WorkView))

                {

                    mon7.Text = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc;

                    var colour = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryColourDesc;

                    mon7.BackgroundColor = Color.FromHex(colour);

                }

                else

                {

                    mon7.Text = "";

                }

            }

            else

            {

                mon7.Text = "";

            }

            //string message = "pas de task";

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null)

                {

                    message = tasksonMon.ElementAt<SchoolTask>(rang).SubDesc;

                }

            }



            mon7.Clicked += (sender, e) => Alert_Clicked(message);

            grid.Children.Add(mon7, collumn, 2 + rang);



            //_____________________________________________________________________

            //________________________Lundi_____8__________________________________

            Button mon8 = new Button();

            rang = 7;

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null && (tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "PERSONAL" && MeView || tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "SCHOOL" && WorkView))

                {

                    mon8.Text = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc;

                    var colour = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryColourDesc;

                    mon8.BackgroundColor = Color.FromHex(colour);

                }

                else

                {

                    mon8.Text = "";

                }

            }

            else

            {

                mon8.Text = "";

            }

            //string message = "pas de task";

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null)

                {

                    message = tasksonMon.ElementAt<SchoolTask>(rang).SubDesc;

                }

            }



            mon8.Clicked += (sender, e) => Alert_Clicked(message);

            grid.Children.Add(mon8, collumn, 2 + rang);



            //_____________________________________________________________________

            //________________________Lundi_____9__________________________________

            Button mon9 = new Button();

            rang = 8;

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null && (tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "PERSONAL" && MeView || tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "SCHOOL" && WorkView))

                {

                    mon9.Text = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc;

                    var colour = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryColourDesc;

                    mon9.BackgroundColor = Color.FromHex(colour);

                }

                else

                {

                    mon9.Text = "";

                }

            }

            else

            {

                mon9.Text = "";

            }

            //string message = "pas de task";

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null)

                {

                    message = tasksonMon.ElementAt<SchoolTask>(rang).SubDesc;

                }

            }



            mon9.Clicked += (sender, e) => Alert_Clicked(message);

            grid.Children.Add(mon9, collumn, 2 + rang);



            //_____________________________________________________________________

            //________________________Lundi_____10__________________________________

            Button mon10 = new Button();

            rang = 9;

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null && (tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "PERSONAL" && MeView || tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "SCHOOL" && WorkView))

                {

                    mon10.Text = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc;

                    var colour = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryColourDesc;

                    mon10.BackgroundColor = Color.FromHex(colour);

                }

                else

                {

                    mon10.Text = "";

                }

            }

            else

            {

                mon10.Text = "";

            }

            //string message = "pas de task";

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null)

                {

                    message = tasksonMon.ElementAt<SchoolTask>(rang).SubDesc;

                }

            }



            mon10.Clicked += (sender, e) => Alert_Clicked(message);

            grid.Children.Add(mon10, collumn, 2 + rang);



            collumn = 1;

            //_____________________________________________________________________

            //________________________Mardi___1____________________________________



            Button tue1 = new Button();

            rang = 0;



            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null && (tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "PERSONAL" && MeView || tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "SCHOOL" && WorkView))

                {

                    tue1.Text = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc;

                    var colour = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryColourDesc;

                    tue1.BackgroundColor = Color.FromHex(colour);

                }

                else

                {

                    tue1.Text = "";

                }

            }

            else

            {

                tue1.Text = "";

            }

            //string message = "pas de task";

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null)

                {

                    message = tasksonMon.ElementAt<SchoolTask>(rang).SubDesc;

                }

            }



            tue1.Clicked += (sender, e) => Alert_Clicked(message);

            grid.Children.Add(tue1, collumn, rang + 2);

            //_____________________________________________________________________

            //________________________Mardi_______2________________________________



            Button tue2 = new Button();

            rang = 1;



            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null && (tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "PERSONAL" && MeView || tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "SCHOOL" && WorkView))

                {

                    tue2.Text = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc;

                    var colour = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryColourDesc;

                    tue2.BackgroundColor = Color.FromHex(colour);

                }

                else

                {

                    tue2.Text = "";

                }

            }

            else

            {

                tue2.Text = "";

            }

            //string message = "pas de task";

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null)

                {

                    message = tasksonMon.ElementAt<SchoolTask>(rang).SubDesc;

                }

            }



            tue2.Clicked += (sender, e) => Alert_Clicked(message);

            grid.Children.Add(tue2, collumn, rang + 2);



            //_____________________________________________________________________

            //________________________Mardi_____3__________________________________



            Button tue3 = new Button();

            rang = 2;

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null && (tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "PERSONAL" && MeView || tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "SCHOOL" && WorkView))

                {

                    tue3.Text = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc;

                    var colour = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryColourDesc;

                    tue3.BackgroundColor = Color.FromHex(colour);

                }

                else

                {

                    tue3.Text = "";

                }

            }

            else

            {

                tue3.Text = "";

            }

            //string message = "pas de task";

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null)

                {

                    message = tasksonMon.ElementAt<SchoolTask>(rang).SubDesc;

                }

            }



            tue3.Clicked += (sender, e) => Alert_Clicked(message);

            grid.Children.Add(tue3, collumn, 2 + rang);



            //_____________________________________________________________________

            //________________________Mardi_____4__________________________________



            Button tue4 = new Button();

            rang = 3;

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null && (tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "PERSONAL" && MeView || tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "SCHOOL" && WorkView))

                {

                    tue4.Text = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc;

                    var colour = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryColourDesc;

                    tue4.BackgroundColor = Color.FromHex(colour);

                }

                else

                {

                    tue4.Text = "";

                }

            }

            else

            {

                tue4.Text = "";

            }

            //string message = "pas de task";

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null)

                {

                    message = tasksonMon.ElementAt<SchoolTask>(rang).SubDesc;

                }

            }



            tue4.Clicked += (sender, e) => Alert_Clicked(message);

            grid.Children.Add(tue4, collumn, 2 + rang);

            //_____________________________________________________________________

            //________________________Mardi_____5__________________________________

            Button tue5 = new Button();

            rang = 4;

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null && (tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "PERSONAL" && MeView || tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "SCHOOL" && WorkView))

                {

                    tue5.Text = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc;

                    var colour = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryColourDesc;

                    tue5.BackgroundColor = Color.FromHex(colour);

                }

                else

                {

                    tue5.Text = "";

                }

            }

            else

            {

                tue5.Text = "";

            }

            //string message = "pas de task";

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null)

                {

                    message = tasksonMon.ElementAt<SchoolTask>(rang).SubDesc;

                }

            }



            tue5.Clicked += (sender, e) => Alert_Clicked(message);

            grid.Children.Add(tue5, collumn, 2 + rang);



            //_____________________________________________________________________

            //________________________Mardi_____6__________________________________

            Button tue6 = new Button();

            rang = 5;

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null && (tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "PERSONAL" && MeView || tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "SCHOOL" && WorkView))

                {

                    tue6.Text = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc;

                    var colour = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryColourDesc;

                    tue6.BackgroundColor = Color.FromHex(colour);

                }

                else

                {

                    tue6.Text = "";

                }

            }

            else

            {

                tue6.Text = "";

            }

            //string message = "pas de task";

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null)

                {

                    message = tasksonMon.ElementAt<SchoolTask>(rang).SubDesc;

                }

            }



            tue6.Clicked += (sender, e) => Alert_Clicked(message);

            grid.Children.Add(tue6, collumn, 2 + rang);



            //_____________________________________________________________________

            //________________________Mardi_____7__________________________________

            Button tue7 = new Button();

            rang = 6;

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null && (tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "PERSONAL" && MeView || tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "SCHOOL" && WorkView))

                {

                    tue7.Text = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc;

                    var colour = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryColourDesc;

                    tue7.BackgroundColor = Color.FromHex(colour);

                }

                else

                {

                    tue7.Text = "";

                }

            }

            else

            {

                tue7.Text = "";

            }

            //string message = "pas de task";

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null)

                {

                    message = tasksonMon.ElementAt<SchoolTask>(rang).SubDesc;

                }

            }



            tue7.Clicked += (sender, e) => Alert_Clicked(message);

            grid.Children.Add(tue7, collumn, 2 + rang);



            //_____________________________________________________________________

            //________________________Mardi_____8__________________________________

            Button tue8 = new Button();

            rang = 7;

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null && (tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "PERSONAL" && MeView || tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "SCHOOL" && WorkView))

                {

                    tue8.Text = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc;

                    var colour = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryColourDesc;

                    tue8.BackgroundColor = Color.FromHex(colour);

                }

                else

                {

                    tue8.Text = "";

                }

            }

            else

            {

                tue8.Text = "";

            }

            //string message = "pas de task";

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null)

                {

                    message = tasksonMon.ElementAt<SchoolTask>(rang).SubDesc;

                }

            }



            tue8.Clicked += (sender, e) => Alert_Clicked(message);

            grid.Children.Add(tue8, collumn, 2 + rang);



            //_____________________________________________________________________

            //________________________Mardi_____9__________________________________

            Button tue9 = new Button();

            rang = 8;

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null && (tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "PERSONAL" && MeView || tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "SCHOOL" && WorkView))

                {

                    tue9.Text = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc;

                    var colour = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryColourDesc;

                    tue9.BackgroundColor = Color.FromHex(colour);

                }

                else

                {

                    tue9.Text = "";

                }

            }

            else

            {

                tue9.Text = "";

            }

            //string message = "pas de task";

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null)

                {

                    message = tasksonMon.ElementAt<SchoolTask>(rang).SubDesc;

                }

            }



            tue9.Clicked += (sender, e) => Alert_Clicked(message);

            grid.Children.Add(tue9, collumn, 2 + rang);



            //_____________________________________________________________________

            //________________________Mardi_____10__________________________________

            Button tue10 = new Button();

            rang = 9;

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null && (tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "PERSONAL" && MeView || tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "SCHOOL" && WorkView))

                {

                    tue10.Text = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc;

                    var colour = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryColourDesc;

                    tue10.BackgroundColor = Color.FromHex(colour);

                }

                else

                {

                    mon10.Text = "";

                }

            }

            else

            {

                tue10.Text = "";

            }

            //string message = "pas de task";

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null)

                {

                    message = tasksonMon.ElementAt<SchoolTask>(rang).SubDesc;

                }

            }



            tue10.Clicked += (sender, e) => Alert_Clicked(message);

            grid.Children.Add(tue10, collumn, 2 + rang);



            collumn = 2;

            //_____________________________________________________________________

            //________________________Mercredi___1_________________________________



            Button wed1 = new Button();

            rang = 0;



            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null && (tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "PERSONAL" && MeView || tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "SCHOOL" && WorkView))

                {

                    wed1.Text = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc;

                    var colour = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryColourDesc;

                    wed1.BackgroundColor = Color.FromHex(colour);

                }

                else

                {

                    wed1.Text = "";

                }

            }

            else

            {

                wed1.Text = "";

            }

            //string message = "pas de task";

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null)

                {

                    message = tasksonMon.ElementAt<SchoolTask>(rang).SubDesc;

                }

            }



            wed1.Clicked += (sender, e) => Alert_Clicked(message);

            grid.Children.Add(wed1, collumn, rang + 2);

            //_____________________________________________________________________

            //________________________Mercredi_______2_____________________________



            Button wed2 = new Button();

            rang = 1;



            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null && (tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "PERSONAL" && MeView || tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "SCHOOL" && WorkView))

                {

                    wed2.Text = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc;

                    var colour = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryColourDesc;

                    wed2.BackgroundColor = Color.FromHex(colour);

                }

                else

                {

                    wed2.Text = "";

                }

            }

            else

            {

                wed2.Text = "";

            }

            //string message = "pas de task";

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null)

                {

                    message = tasksonMon.ElementAt<SchoolTask>(rang).SubDesc;

                }

            }



            wed2.Clicked += (sender, e) => Alert_Clicked(message);

            grid.Children.Add(wed2, collumn, rang + 2);



            //_____________________________________________________________________

            //________________________Mercredi_____3_______________________________



            Button wed3 = new Button();

            rang = 2;

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null && (tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "PERSONAL" && MeView || tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "SCHOOL" && WorkView))

                {

                    wed3.Text = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc;

                    var colour = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryColourDesc;

                    wed3.BackgroundColor = Color.FromHex(colour);

                }

                else

                {

                    wed3.Text = "";

                }

            }

            else

            {

                wed3.Text = "";

            }

            //string message = "pas de task";

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null)

                {

                    message = tasksonMon.ElementAt<SchoolTask>(rang).SubDesc;

                }

            }



            wed3.Clicked += (sender, e) => Alert_Clicked(message);

            grid.Children.Add(wed3, collumn, 2 + rang);



            //_____________________________________________________________________

            //________________________Mercredi_____4_______________________________



            Button wed4 = new Button();

            rang = 3;

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null && (tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "PERSONAL" && MeView || tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "SCHOOL" && WorkView))

                {

                    wed4.Text = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc;

                    var colour = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryColourDesc;

                    wed4.BackgroundColor = Color.FromHex(colour);

                }

                else

                {

                    wed4.Text = "";

                }

            }

            else

            {

                wed4.Text = "";

            }

            //string message = "pas de task";

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null)

                {

                    message = tasksonMon.ElementAt<SchoolTask>(rang).SubDesc;

                }

            }



            wed4.Clicked += (sender, e) => Alert_Clicked(message);

            grid.Children.Add(wed4, collumn, 2 + rang);

            //_____________________________________________________________________

            //________________________Mercredi_____5_______________________________

            Button wed5 = new Button();

            rang = 4;

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null && (tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "PERSONAL" && MeView || tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "SCHOOL" && WorkView))

                {

                    wed5.Text = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc;

                    var colour = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryColourDesc;

                    wed5.BackgroundColor = Color.FromHex(colour);

                }

                else

                {

                    wed5.Text = "";

                }

            }

            else

            {

                wed5.Text = "";

            }

            //string message = "pas de task";

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null)

                {

                    message = tasksonMon.ElementAt<SchoolTask>(rang).SubDesc;

                }

            }



            wed5.Clicked += (sender, e) => Alert_Clicked(message);

            grid.Children.Add(wed5, collumn, 2 + rang);



            //_____________________________________________________________________

            //________________________Mercredi_____6_______________________________

            Button wed6 = new Button();

            rang = 5;

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null && (tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "PERSONAL" && MeView || tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "SCHOOL" && WorkView))

                {

                    wed6.Text = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc;

                    var colour = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryColourDesc;

                    wed6.BackgroundColor = Color.FromHex(colour);

                }

                else

                {

                    wed6.Text = "";

                }

            }

            else

            {

                wed6.Text = "";

            }

            //string message = "pas de task";

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null)

                {

                    message = tasksonMon.ElementAt<SchoolTask>(rang).SubDesc;

                }

            }



            wed6.Clicked += (sender, e) => Alert_Clicked(message);

            grid.Children.Add(wed6, collumn, 2 + rang);



            //_____________________________________________________________________

            //________________________Mercredi_____7_______________________________

            Button wed7 = new Button();

            rang = 6;

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null && (tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "PERSONAL" && MeView || tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "SCHOOL" && WorkView))

                {

                    wed7.Text = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc;

                    var colour = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryColourDesc;

                    wed7.BackgroundColor = Color.FromHex(colour);

                }

                else

                {

                    wed7.Text = "";

                }

            }

            else

            {

                wed7.Text = "";

            }

            //string message = "pas de task";

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null)

                {

                    message = tasksonMon.ElementAt<SchoolTask>(rang).SubDesc;

                }

            }



            wed7.Clicked += (sender, e) => Alert_Clicked(message);

            grid.Children.Add(wed7, collumn, 2 + rang);



            //_____________________________________________________________________

            //________________________Mercredi_____8_______________________________

            Button wed8 = new Button();

            rang = 7;

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null && (tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "PERSONAL" && MeView || tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "SCHOOL" && WorkView))

                {

                    wed8.Text = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc;

                    var colour = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryColourDesc;

                    wed8.BackgroundColor = Color.FromHex(colour);

                }

                else

                {

                    wed8.Text = "";

                }

            }

            else

            {

                wed8.Text = "";

            }

            //string message = "pas de task";

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null)

                {

                    message = tasksonMon.ElementAt<SchoolTask>(rang).SubDesc;

                }

            }



            wed8.Clicked += (sender, e) => Alert_Clicked(message);

            grid.Children.Add(wed8, collumn, 2 + rang);



            //_____________________________________________________________________

            //________________________Mercredi_____9_______________________________

            Button wed9 = new Button();

            rang = 8;

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null && (tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "PERSONAL" && MeView || tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "SCHOOL" && WorkView))

                {

                    wed9.Text = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc;

                    var colour = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryColourDesc;

                    wed9.BackgroundColor = Color.FromHex(colour);

                }

                else

                {

                    wed9.Text = "";

                }

            }

            else

            {

                wed9.Text = "";

            }

            //string message = "pas de task";

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null)

                {

                    message = tasksonMon.ElementAt<SchoolTask>(rang).SubDesc;

                }

            }



            wed9.Clicked += (sender, e) => Alert_Clicked(message);

            grid.Children.Add(wed9, collumn, 2 + rang);



            //_____________________________________________________________________

            //________________________Mercredi_____10______________________________

            Button wed10 = new Button();

            rang = 9;

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null && (tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "PERSONAL" && MeView || tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "SCHOOL" && WorkView))

                {

                    wed10.Text = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc;

                    var colour = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryColourDesc;

                    wed10.BackgroundColor = Color.FromHex(colour);

                }

                else

                {

                    mon10.Text = "";

                }

            }

            else

            {

                wed10.Text = "";

            }

            //string message = "pas de task";

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null)

                {

                    message = tasksonMon.ElementAt<SchoolTask>(rang).SubDesc;

                }

            }



            wed10.Clicked += (sender, e) => Alert_Clicked(message);

            grid.Children.Add(wed10, collumn, 2 + rang);



            collumn = 3;

            //_____________________________________________________________________

            //________________________Jeudi___1____________________________________



            Button thu1 = new Button();

            rang = 0;



            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null && (tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "PERSONAL" && MeView || tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "SCHOOL" && WorkView))

                {

                    thu1.Text = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc;

                    var colour = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryColourDesc;

                    thu1.BackgroundColor = Color.FromHex(colour);

                }

                else

                {

                    thu1.Text = "";

                }

            }

            else

            {

                thu1.Text = "";

            }

            //string message = "pas de task";

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null)

                {

                    message = tasksonMon.ElementAt<SchoolTask>(rang).SubDesc;

                }

            }



            thu1.Clicked += (sender, e) => Alert_Clicked(message);

            grid.Children.Add(thu1, collumn, rang + 2);

            //_____________________________________________________________________

            //________________________Jeudi_______2________________________________



            Button thu2 = new Button();

            rang = 1;



            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null && (tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "PERSONAL" && MeView || tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "SCHOOL" && WorkView))

                {

                    thu2.Text = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc;

                    var colour = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryColourDesc;

                    thu2.BackgroundColor = Color.FromHex(colour);

                }

                else

                {

                    thu2.Text = "";

                }

            }

            else

            {

                thu2.Text = "";

            }

            //string message = "pas de task";

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null)

                {

                    message = tasksonMon.ElementAt<SchoolTask>(rang).SubDesc;

                }

            }



            thu2.Clicked += (sender, e) => Alert_Clicked(message);

            grid.Children.Add(thu2, collumn, rang + 2);



            //_____________________________________________________________________

            //________________________Jeudi_____3__________________________________



            Button thu3 = new Button();

            rang = 2;

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null && (tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "PERSONAL" && MeView || tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "SCHOOL" && WorkView))

                {

                    thu3.Text = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc;

                    var colour = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryColourDesc;

                    thu3.BackgroundColor = Color.FromHex(colour);

                }

                else

                {

                    thu3.Text = "";

                }

            }

            else

            {

                thu3.Text = "";

            }

            //string message = "pas de task";

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null)

                {

                    message = tasksonMon.ElementAt<SchoolTask>(rang).SubDesc;

                }

            }



            thu3.Clicked += (sender, e) => Alert_Clicked(message);

            grid.Children.Add(thu3, collumn, 2 + rang);



            //_____________________________________________________________________

            //________________________Jeudi_____4__________________________________



            Button thu4 = new Button();

            rang = 3;

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null && (tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "PERSONAL" && MeView || tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "SCHOOL" && WorkView))

                {

                    thu4.Text = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc;

                    var colour = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryColourDesc;

                    thu4.BackgroundColor = Color.FromHex(colour);

                }

                else

                {

                    thu4.Text = "";

                }

            }

            else

            {

                thu4.Text = "";

            }

            //string message = "pas de task";

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null)

                {

                    message = tasksonMon.ElementAt<SchoolTask>(rang).SubDesc;

                }

            }



            thu4.Clicked += (sender, e) => Alert_Clicked(message);

            grid.Children.Add(thu4, collumn, 2 + rang);

            //_____________________________________________________________________

            //________________________Jeudi_____5__________________________________

            Button thu5 = new Button();

            rang = 4;

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null && (tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "PERSONAL" && MeView || tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "SCHOOL" && WorkView))

                {

                    thu5.Text = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc;

                    var colour = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryColourDesc;

                    thu5.BackgroundColor = Color.FromHex(colour);

                }

                else

                {

                    thu5.Text = "";

                }

            }

            else

            {

                thu5.Text = "";

            }

            //string message = "pas de task";

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null)

                {

                    message = tasksonMon.ElementAt<SchoolTask>(rang).SubDesc;

                }

            }



            thu5.Clicked += (sender, e) => Alert_Clicked(message);

            grid.Children.Add(thu5, collumn, 2 + rang);



            //_____________________________________________________________________

            //________________________Jeudi_____6__________________________________

            Button thu6 = new Button();

            rang = 5;

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null && (tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "PERSONAL" && MeView || tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "SCHOOL" && WorkView))

                {

                    thu6.Text = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc;

                    var colour = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryColourDesc;

                    thu6.BackgroundColor = Color.FromHex(colour);

                }

                else

                {

                    thu6.Text = "";

                }

            }

            else

            {

                thu6.Text = "";

            }

            //string message = "pas de task";

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null)

                {

                    message = tasksonMon.ElementAt<SchoolTask>(rang).SubDesc;

                }

            }



            thu6.Clicked += (sender, e) => Alert_Clicked(message);

            grid.Children.Add(thu6, collumn, 2 + rang);



            //_____________________________________________________________________

            //________________________Jeudi_____7__________________________________

            Button thu7 = new Button();

            rang = 6;

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null && (tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "PERSONAL" && MeView || tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "SCHOOL" && WorkView))

                {

                    thu7.Text = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc;

                    var colour = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryColourDesc;

                    thu7.BackgroundColor = Color.FromHex(colour);

                }

                else

                {

                    thu7.Text = "";

                }

            }

            else

            {

                thu7.Text = "";

            }

            //string message = "pas de task";

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null)

                {

                    message = tasksonMon.ElementAt<SchoolTask>(rang).SubDesc;

                }

            }



            thu7.Clicked += (sender, e) => Alert_Clicked(message);

            grid.Children.Add(thu7, collumn, 2 + rang);



            //_____________________________________________________________________

            //________________________Jeudi_____8__________________________________

            Button thu8 = new Button();

            rang = 7;

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null && (tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "PERSONAL" && MeView || tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "SCHOOL" && WorkView))

                {

                    thu8.Text = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc;

                    var colour = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryColourDesc;

                    thu8.BackgroundColor = Color.FromHex(colour);

                }

                else

                {

                    thu8.Text = "";

                }

            }

            else

            {

                thu8.Text = "";

            }

            //string message = "pas de task";

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null)

                {

                    message = tasksonMon.ElementAt<SchoolTask>(rang).SubDesc;

                }

            }



            thu8.Clicked += (sender, e) => Alert_Clicked(message);

            grid.Children.Add(thu8, collumn, 2 + rang);



            //_____________________________________________________________________

            //________________________Jeudi_____9__________________________________

            Button thu9 = new Button();

            rang = 8;

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null && (tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "PERSONAL" && MeView || tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "SCHOOL" && WorkView))

                {

                    thu9.Text = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc;

                    var colour = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryColourDesc;

                    thu9.BackgroundColor = Color.FromHex(colour);

                }

                else

                {

                    thu9.Text = "";

                }

            }

            else

            {

                thu9.Text = "";

            }

            //string message = "pas de task";

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null)

                {

                    message = tasksonMon.ElementAt<SchoolTask>(rang).SubDesc;

                }

            }



            thu9.Clicked += (sender, e) => Alert_Clicked(message);

            grid.Children.Add(thu9, collumn, 2 + rang);



            //_____________________________________________________________________

            //________________________Jeudi_____10__________________________________

            Button thu10 = new Button();

            rang = 9;

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null && (tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "PERSONAL" && MeView || tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "SCHOOL" && WorkView))

                {

                    thu10.Text = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc;

                    var colour = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryColourDesc;

                    thu10.BackgroundColor = Color.FromHex(colour);

                }

                else

                {

                    mon10.Text = "";

                }

            }

            else

            {

                thu10.Text = "";

            }

            //string message = "pas de task";

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null)

                {

                    message = tasksonMon.ElementAt<SchoolTask>(rang).SubDesc;

                }

            }



            thu10.Clicked += (sender, e) => Alert_Clicked(message);

            grid.Children.Add(thu10, collumn, 2 + rang);



            collumn = 4;

            //_____________________________________________________________________

            //________________________Vendredi___1_________________________________

            Button fri1 = new Button();

            rang = 0;

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null && (tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "PERSONAL" && MeView || tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "SCHOOL" && WorkView))

                {

                    fri1.Text = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc;

                    var colour = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryColourDesc;

                    fri1.BackgroundColor = Color.FromHex(colour);

                }

                else

                {

                    fri1.Text = "";

                }

            }

            else

            {

                fri1.Text = "";

            }

            //string message = "pas de task";

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null)

                {

                    message = tasksonMon.ElementAt<SchoolTask>(rang).SubDesc;

                }

            }

            fri1.Clicked += (sender, e) => Alert_Clicked(message);

            grid.Children.Add(fri1, collumn, rang + 2);

            //_____________________________________________________________________

            //________________________Vendredi_______2_____________________________

            Button fri2 = new Button();

            rang = 1;

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null && (tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "PERSONAL" && MeView || tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "SCHOOL" && WorkView))

                {

                    fri2.Text = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc;

                    var colour = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryColourDesc;

                    fri2.BackgroundColor = Color.FromHex(colour);

                }

                else

                {

                    fri2.Text = "";

                }

            }

            else

            {

                fri2.Text = "";

            }

            //string message = "pas de task";

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null)

                {

                    message = tasksonMon.ElementAt<SchoolTask>(rang).SubDesc;

                }

            }

            fri2.Clicked += (sender, e) => Alert_Clicked(message);

            grid.Children.Add(fri2, collumn, rang + 2);

            //_____________________________________________________________________

            //________________________Vendredi_____3__________________________________

            Button fri3 = new Button();

            rang = 2;

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null && (tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "PERSONAL" && MeView || tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "SCHOOL" && WorkView))

                {

                    fri3.Text = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc;

                    var colour = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryColourDesc;

                    fri3.BackgroundColor = Color.FromHex(colour);

                }

                else

                {

                    fri3.Text = "";

                }

            }

            else

            {

                fri3.Text = "";

            }

            //string message = "pas de task";

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null)

                {

                    message = tasksonMon.ElementAt<SchoolTask>(rang).SubDesc;

                }

            }

            fri3.Clicked += (sender, e) => Alert_Clicked(message);

            grid.Children.Add(fri3, collumn, 2 + rang);

            //_____________________________________________________________________

            //________________________Vendredi_____4__________________________________

            Button fri4 = new Button();

            rang = 3;

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null && (tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "PERSONAL" && MeView || tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "SCHOOL" && WorkView))

                {

                    fri4.Text = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc;

                    var colour = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryColourDesc;

                    fri4.BackgroundColor = Color.FromHex(colour);

                }

                else

                {

                    fri4.Text = "";

                }

            }

            else

            {

                fri4.Text = "";

            }

            //string message = "pas de task";

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null)

                {

                    message = tasksonMon.ElementAt<SchoolTask>(rang).SubDesc;

                }

            }

            fri4.Clicked += (sender, e) => Alert_Clicked(message);

            grid.Children.Add(fri4, collumn, 2 + rang);

            //_____________________________________________________________________

            //________________________Vendredi_____5__________________________________

            Button fri5 = new Button();

            rang = 4;

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null && (tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "PERSONAL" && MeView || tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "SCHOOL" && WorkView))

                {

                    fri5.Text = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc;

                    var colour = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryColourDesc;

                    fri5.BackgroundColor = Color.FromHex(colour);

                }

                else

                {

                    fri5.Text = "";

                }

            }

            else

            {

                fri5.Text = "";

            }

            //string message = "pas de task";

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null)

                {

                    message = tasksonMon.ElementAt<SchoolTask>(rang).SubDesc;

                }

            }

            fri5.Clicked += (sender, e) => Alert_Clicked(message);

            grid.Children.Add(fri5, collumn, 2 + rang);

            //_____________________________________________________________________

            //________________________Vendredi_____6__________________________________

            Button fri6 = new Button();

            rang = 5;

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null && (tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "PERSONAL" && MeView || tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "SCHOOL" && WorkView))

                {

                    fri6.Text = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc;

                    var colour = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryColourDesc;

                    fri6.BackgroundColor = Color.FromHex(colour);

                }

                else

                {

                    fri6.Text = "";

                }

            }

            else

            {

                fri6.Text = "";

            }

            //string message = "pas de task";

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null)

                {

                    message = tasksonMon.ElementAt<SchoolTask>(rang).SubDesc;

                }

            }

            fri6.Clicked += (sender, e) => Alert_Clicked(message);

            grid.Children.Add(fri6, collumn, 2 + rang);

            //_____________________________________________________________________

            //________________________Vendredi_____7__________________________________

            Button fri7 = new Button();

            rang = 6;

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null && (tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "PERSONAL" && MeView || tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "SCHOOL" && WorkView))

                {

                    fri7.Text = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc;

                    var colour = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryColourDesc;

                    fri7.BackgroundColor = Color.FromHex(colour);

                }

                else

                {

                    fri7.Text = "";

                }

            }

            else

            {

                fri7.Text = "";

            }

            //string message = "pas de task";

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null)

                {

                    message = tasksonMon.ElementAt<SchoolTask>(rang).SubDesc;

                }

            }

            fri7.Clicked += (sender, e) => Alert_Clicked(message);

            grid.Children.Add(fri7, collumn, 2 + rang);

            //_____________________________________________________________________

            //________________________Vendredi_____8__________________________________

            Button fri8 = new Button();

            rang = 7;

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null && (tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "PERSONAL" && MeView || tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "SCHOOL" && WorkView))

                {

                    fri8.Text = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc;

                    var colour = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryColourDesc;

                    fri8.BackgroundColor = Color.FromHex(colour);

                }

                else

                {

                    fri8.Text = "";

                }

            }

            else

            {

                fri8.Text = "";

            }

            //string message = "pas de task";

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null)

                {

                    message = tasksonMon.ElementAt<SchoolTask>(rang).SubDesc;

                }

            }

            fri8.Clicked += (sender, e) => Alert_Clicked(message);

            grid.Children.Add(fri8, collumn, 2 + rang);

            //_____________________________________________________________________

            //________________________Vendredi_____9_______________________________

            Button fri9 = new Button();

            rang = 8;

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null && (tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "PERSONAL" && MeView || tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "SCHOOL" && WorkView))

                {

                    fri9.Text = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc;

                    var colour = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryColourDesc;

                    fri9.BackgroundColor = Color.FromHex(colour);

                }

                else

                {

                    fri9.Text = "";

                }

            }

            else

            {

                fri9.Text = "";

            }

            //string message = "pas de task";

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null)

                {

                    message = tasksonMon.ElementAt<SchoolTask>(rang).SubDesc;

                }

            }

            fri9.Clicked += (sender, e) => Alert_Clicked(message);

            grid.Children.Add(fri9, collumn, 2 + rang);

            //_____________________________________________________________________

            //________________________Vendredi_____10______________________________

            Button fri10 = new Button();

            rang = 9;

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null && (tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "PERSONAL" && MeView || tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "SCHOOL" && WorkView))

                {

                    fri10.Text = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc;

                    var colour = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryColourDesc;

                    fri10.BackgroundColor = Color.FromHex(colour);

                }

                else

                {

                    mon10.Text = "";

                }

            }

            else

            {

                fri10.Text = "";

            }

            //string message = "pas de task";

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null)

                {

                    message = tasksonMon.ElementAt<SchoolTask>(rang).SubDesc;

                }

            }

            fri10.Clicked += (sender, e) => Alert_Clicked(message);

            grid.Children.Add(fri10, collumn, 2 + rang);



            collumn = 5;

            //_____________________________________________________________________

            //________________________Samedi___1____________________________________

            Button sat1 = new Button();

            rang = 0;

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null && (tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "PERSONAL" && MeView || tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "SCHOOL" && WorkView))

                {

                    sat1.Text = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc;

                    var colour = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryColourDesc;

                    sat1.BackgroundColor = Color.FromHex(colour);

                }

                else

                {

                    sat1.Text = "";

                }

            }

            else

            {

                sat1.Text = "";

            }

            //string message = "pas de task";

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null)

                {

                    message = tasksonMon.ElementAt<SchoolTask>(rang).SubDesc;

                }

            }

            sat1.Clicked += (sender, e) => Alert_Clicked(message);

            grid.Children.Add(sat1, collumn, rang + 2);

            //_____________________________________________________________________

            //________________________Samedi_______2________________________________

            Button sat2 = new Button();

            rang = 1;

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null && (tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "PERSONAL" && MeView || tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "SCHOOL" && WorkView))

                {

                    sat2.Text = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc;

                    var colour = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryColourDesc;

                    sat2.BackgroundColor = Color.FromHex(colour);

                }

                else

                {

                    sat2.Text = "";

                }

            }

            else

            {

                sat2.Text = "";

            }

            //string message = "pas de task";

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null)

                {

                    message = tasksonMon.ElementAt<SchoolTask>(rang).SubDesc;

                }

            }

            sat2.Clicked += (sender, e) => Alert_Clicked(message);

            grid.Children.Add(sat2, collumn, rang + 2);

            //_____________________________________________________________________

            //_______________________Samedi_____3__________________________________

            Button sat3 = new Button();

            rang = 2;

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null && (tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "PERSONAL" && MeView || tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "SCHOOL" && WorkView))

                {

                    sat3.Text = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc;

                    var colour = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryColourDesc;

                    sat3.BackgroundColor = Color.FromHex(colour);

                }

                else

                {

                    sat3.Text = "";

                }

            }

            else

            {

                sat3.Text = "";

            }

            //string message = "pas de task";

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null)

                {

                    message = tasksonMon.ElementAt<SchoolTask>(rang).SubDesc;

                }

            }

            sat3.Clicked += (sender, e) => Alert_Clicked(message);

            grid.Children.Add(sat3, collumn, 2 + rang);

            //_____________________________________________________________________

            //________________________Samedi_____4__________________________________

            Button sat4 = new Button();

            rang = 3;

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null && (tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "PERSONAL" && MeView || tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "SCHOOL" && WorkView))

                {

                    sat4.Text = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc;

                    var colour = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryColourDesc;

                    sat4.BackgroundColor = Color.FromHex(colour);

                }

                else

                {

                    sat4.Text = "";

                }

            }

            else

            {

                sat4.Text = "";

            }

            //string message = "pas de task";

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null)

                {

                    message = tasksonMon.ElementAt<SchoolTask>(rang).SubDesc;

                }

            }

            sat4.Clicked += (sender, e) => Alert_Clicked(message);

            grid.Children.Add(sat4, collumn, 2 + rang);

            //_____________________________________________________________________

            //________________________Samedi_____5__________________________________

            Button sat5 = new Button();

            rang = 4;

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null && (tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "PERSONAL" && MeView || tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "SCHOOL" && WorkView))

                {

                    sat5.Text = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc;

                    var colour = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryColourDesc;

                    sat5.BackgroundColor = Color.FromHex(colour);

                }

                else

                {

                    sat5.Text = "";

                }

            }

            else

            {

                sat5.Text = "";

            }

            //string message = "pas de task";

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null)

                {

                    message = tasksonMon.ElementAt<SchoolTask>(rang).SubDesc;

                }

            }

            sat5.Clicked += (sender, e) => Alert_Clicked(message);

            grid.Children.Add(sat5, collumn, 2 + rang);

            //_____________________________________________________________________

            //________________________Samedi_____6__________________________________

            Button sat6 = new Button();

            rang = 5;

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null && (tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "PERSONAL" && MeView || tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "SCHOOL" && WorkView))

                {

                    sat6.Text = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc;

                    var colour = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryColourDesc;

                    sat6.BackgroundColor = Color.FromHex(colour);

                }

                else

                {

                    sat6.Text = "";

                }

            }

            else

            {

                sat6.Text = "";

            }

            //string message = "pas de task";

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null)

                {

                    message = tasksonMon.ElementAt<SchoolTask>(rang).SubDesc;

                }

            }

            sat6.Clicked += (sender, e) => Alert_Clicked(message);

            grid.Children.Add(sat6, collumn, 2 + rang);

            //_____________________________________________________________________

            //________________________Samedi_____7__________________________________

            Button sat7 = new Button();

            rang = 6;

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null && (tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "PERSONAL" && MeView || tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "SCHOOL" && WorkView))

                {

                    sat7.Text = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc;

                    var colour = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryColourDesc;

                    sat7.BackgroundColor = Color.FromHex(colour);

                }

                else

                {

                    sat7.Text = "";

                }

            }

            else

            {

                sat7.Text = "";

            }

            //string message = "pas de task";

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null)

                {

                    message = tasksonMon.ElementAt<SchoolTask>(rang).SubDesc;

                }

            }

            sat7.Clicked += (sender, e) => Alert_Clicked(message);

            grid.Children.Add(sat7, collumn, 2 + rang);

            //_____________________________________________________________________

            //________________________Samedi_____8__________________________________

            Button sat8 = new Button();

            rang = 7;

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null && (tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "PERSONAL" && MeView || tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "SCHOOL" && WorkView))

                {

                    sat8.Text = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc;

                    var colour = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryColourDesc;

                    sat8.BackgroundColor = Color.FromHex(colour);

                }

                else

                {

                    sat8.Text = "";

                }

            }

            else

            {

                sat8.Text = "";

            }

            //string message = "pas de task";

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null)

                {

                    message = tasksonMon.ElementAt<SchoolTask>(rang).SubDesc;

                }

            }

            sat8.Clicked += (sender, e) => Alert_Clicked(message);

            grid.Children.Add(sat8, collumn, 2 + rang);

            //_____________________________________________________________________

            //________________________Samedi_____9__________________________________

            Button sat9 = new Button();

            rang = 8;

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null && (tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "PERSONAL" && MeView || tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "SCHOOL" && WorkView))

                {

                    sat9.Text = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc;

                    var colour = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryColourDesc;

                    sat9.BackgroundColor = Color.FromHex(colour);

                }

                else

                {

                    sat9.Text = "";

                }

            }

            else

            {

                sat9.Text = "";

            }

            //string message = "pas de task";

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null)

                {

                    message = tasksonMon.ElementAt<SchoolTask>(rang).SubDesc;

                }

            }

            sat9.Clicked += (sender, e) => Alert_Clicked(message);

            grid.Children.Add(sat9, collumn, 2 + rang);

            //_____________________________________________________________________

            //________________________Samedi_____10________________________________

            Button sat10 = new Button();

            rang = 9;

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null && (tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "PERSONAL" && MeView || tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "SCHOOL" && WorkView))

                {

                    sat10.Text = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc;

                    var colour = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryColourDesc;

                    sat10.BackgroundColor = Color.FromHex(colour);

                }

                else

                {

                    mon10.Text = "";

                }

            }

            else

            {

                sat10.Text = "";

            }

            //string message = "pas de task";

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null)

                {

                    message = tasksonMon.ElementAt<SchoolTask>(rang).SubDesc;

                }

            }

            sat10.Clicked += (sender, e) => Alert_Clicked(message);

            grid.Children.Add(sat10, collumn, 2 + rang);



            collumn = 6;

            //_____________________________________________________________________

            //________________________Dimanche___1____________________________________

            Button sun1 = new Button();

            rang = 0;

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null && (tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "PERSONAL" && MeView || tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "SCHOOL" && WorkView))

                {

                    sun1.Text = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc;

                    var colour = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryColourDesc;

                    sun1.BackgroundColor = Color.FromHex(colour);

                }

                else

                {

                    sun1.Text = "";

                }

            }

            else

            {

                sun1.Text = "";

            }

            //string message = "pas de task";

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null)

                {

                    message = tasksonMon.ElementAt<SchoolTask>(rang).SubDesc;

                }

            }

            sun1.Clicked += (sender, e) => Alert_Clicked(message);

            grid.Children.Add(sun1, collumn, rang + 2);

            //_____________________________________________________________________

            //________________________Dimanche_______2________________________________

            Button sun2 = new Button();

            rang = 1;

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null && (tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "PERSONAL" && MeView || tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "SCHOOL" && WorkView))

                {

                    sun2.Text = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc;

                    var colour = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryColourDesc;

                    sun2.BackgroundColor = Color.FromHex(colour);

                }

                else

                {

                    sun2.Text = "";

                }

            }

            else

            {

                sun2.Text = "";

            }

            //string message = "pas de task";

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null)

                {

                    message = tasksonMon.ElementAt<SchoolTask>(rang).SubDesc;

                }

            }

            sun2.Clicked += (sender, e) => Alert_Clicked(message);

            grid.Children.Add(sun2, collumn, rang + 2);

            //_____________________________________________________________________

            //________________________Dimanche_____3__________________________________

            Button sun3 = new Button();

            rang = 2;

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null && (tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "PERSONAL" && MeView || tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "SCHOOL" && WorkView))

                {

                    sun3.Text = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc;

                    var colour = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryColourDesc;

                    sun3.BackgroundColor = Color.FromHex(colour);

                }

                else

                {

                    sun3.Text = "";

                }

            }

            else

            {

                sun3.Text = "";

            }

            //string message = "pas de task";

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null)

                {

                    message = tasksonMon.ElementAt<SchoolTask>(rang).SubDesc;

                }

            }

            sun3.Clicked += (sender, e) => Alert_Clicked(message);

            grid.Children.Add(sun3, collumn, 2 + rang);

            //_____________________________________________________________________

            //________________________Dimanche_____4__________________________________

            Button sun4 = new Button();

            rang = 3;

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null && (tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "PERSONAL" && MeView || tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "SCHOOL" && WorkView))

                {

                    sun4.Text = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc;

                    var colour = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryColourDesc;

                    sun4.BackgroundColor = Color.FromHex(colour);

                }

                else

                {

                    sun4.Text = "";

                }

            }

            else

            {

                sun4.Text = "";

            }

            //string message = "pas de task";

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null)

                {

                    message = tasksonMon.ElementAt<SchoolTask>(rang).SubDesc;

                }

            }

            sun4.Clicked += (sender, e) => Alert_Clicked(message);

            grid.Children.Add(sun4, collumn, 2 + rang);

            //_____________________________________________________________________

            //________________________Dimanche_____5_______________________________

            Button sun5 = new Button();

            rang = 4;

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null && (tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "PERSONAL" && MeView || tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "SCHOOL" && WorkView))

                {

                    sun5.Text = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc;

                    var colour = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryColourDesc;

                    sun5.BackgroundColor = Color.FromHex(colour);

                }

                else

                {

                    sun5.Text = "";

                }

            }

            else

            {

                sun5.Text = "";

            }

            //string message = "pas de task";

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null)

                {

                    message = tasksonMon.ElementAt<SchoolTask>(rang).SubDesc;

                }

            }

            sun5.Clicked += (sender, e) => Alert_Clicked(message);

            grid.Children.Add(sun5, collumn, 2 + rang);

            //_____________________________________________________________________

            //_______________________Dimanche_____6________________________________

            Button sun6 = new Button();

            rang = 5;

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null && (tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "PERSONAL" && MeView || tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "SCHOOL" && WorkView))

                {

                    sun6.Text = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc;

                    var colour = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryColourDesc;

                    sun6.BackgroundColor = Color.FromHex(colour);

                }

                else

                {

                    sun6.Text = "";

                }

            }

            else

            {

                sun6.Text = "";

            }

            //string message = "pas de task";

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null)

                {

                    message = tasksonMon.ElementAt<SchoolTask>(rang).SubDesc;

                }

            }

            sun6.Clicked += (sender, e) => Alert_Clicked(message);

            grid.Children.Add(sun6, collumn, 2 + rang);

            //_____________________________________________________________________

            //________________________Dimanche_____7__________________________________

            Button sun7 = new Button();

            rang = 6;

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null && (tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "PERSONAL" && MeView || tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "SCHOOL" && WorkView))

                {

                    sun7.Text = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc;

                    var colour = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryColourDesc;

                    sun7.BackgroundColor = Color.FromHex(colour);

                }

                else

                {

                    sun7.Text = "";

                }

            }

            else

            {

                sun7.Text = "";

            }

            //string message = "pas de task";

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null)

                {

                    message = tasksonMon.ElementAt<SchoolTask>(rang).SubDesc;

                }

            }

            sun7.Clicked += (sender, e) => Alert_Clicked(message);

            grid.Children.Add(sun7, collumn, 2 + rang);

            //_____________________________________________________________________

            //________________________Dimanche_____8__________________________________

            Button sun8 = new Button();

            rang = 7;

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null && (tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "PERSONAL" && MeView || tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "SCHOOL" && WorkView))

                {

                    sun8.Text = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc;

                    var colour = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryColourDesc;

                    sun8.BackgroundColor = Color.FromHex(colour);

                }

                else

                {

                    sun8.Text = "";

                }

            }

            else

            {

                sun8.Text = "";

            }

            //string message = "pas de task";

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null)

                {

                    message = tasksonMon.ElementAt<SchoolTask>(rang).SubDesc;

                }

            }

            sun8.Clicked += (sender, e) => Alert_Clicked(message);

            grid.Children.Add(sun8, collumn, 2 + rang);

            //_____________________________________________________________________

            //________________________Dimanche_____9__________________________________

            Button sun9 = new Button();

            rang = 8;

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null && (tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "PERSONAL" && MeView || tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "SCHOOL" && WorkView))

                {

                    sun9.Text = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc;

                    var colour = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryColourDesc;

                    sun9.BackgroundColor = Color.FromHex(colour);

                }

                else

                {

                    sun9.Text = "";

                }

            }

            else

            {

                sun9.Text = "";

            }

            //string message = "pas de task";

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null)

                {

                    message = tasksonMon.ElementAt<SchoolTask>(rang).SubDesc;

                }

            }

            sun9.Clicked += (sender, e) => Alert_Clicked(message);

            grid.Children.Add(sun9, collumn, 2 + rang);

            //_____________________________________________________________________

            //________________________Dimanche_____10__________________________________

            Button sun10 = new Button();

            rang = 9;

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null && (tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "PERSONAL" && MeView || tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc == "SCHOOL" && WorkView))

                {

                    sun10.Text = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryDesc;

                    var colour = tasksonMon.ElementAt<SchoolTask>(rang).TaskCategoryColourDesc;

                    sun10.BackgroundColor = Color.FromHex(colour);

                }

                else

                {

                    mon10.Text = "";

                }

            }

            else

            {

                sun10.Text = "";

            }

            //string message = "pas de task";

            if (tasksonMon.Count<SchoolTask>() != 0)

            {

                if (tasksonMon.ElementAt<SchoolTask>(rang) != null)

                {

                    message = tasksonMon.ElementAt<SchoolTask>(rang).SubDesc;

                }

            }

            sun10.Clicked += (sender, e) => Alert_Clicked(message);

            grid.Children.Add(sun10, collumn, 2 + rang);







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







            var tasktoday = col.Find(Query.EQ("DueDate", localTime));

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

            WorkView = e.Value;

        }



        private void Switch2_OnToggled(object sender, ToggledEventArgs e)

        {

            MeView = e.Value;

        }





    }

}