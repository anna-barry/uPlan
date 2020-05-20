using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UplanTest
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewWorkouts : ContentPage
    {
        public List<string> ToCallMon = new List<string>();
        public List<string> ToCallTue = new List<string>();
        public List<string> ToCallWed = new List<string>();
        public List<string> ToCallThu = new List<string>();
        public List<string> ToCallFri = new List<string>();
        public List<string> ToCallSat = new List<string>();
        public List<string> ToCallSun = new List<string>();

        public ViewWorkouts()
        {
            InitializeComponent();

            DateTime localTime = DateTime.Now;
            var dayofweektoday = localTime.DayOfWeek;


            var Monday = localTime;

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
            var c = Database.db.GetCollection<Workout>("AllWorkouts");
            List<string> mon=DisplayWorkout(Monday,0,ToCallMon);
            monday.ItemsSource = mon;
            List<string> tue=DisplayWorkout(Tuesday, 1, ToCallTue);
            tuesday.ItemsSource = tue;
            List<string> wed=DisplayWorkout(Wednesday, 2, ToCallWed);
            wednesday.ItemsSource = wed;
            List<string> thu=DisplayWorkout(Thursday, 3, ToCallThu);
            thursday.ItemsSource = thu;
            List<string> fri=DisplayWorkout(Friday, 4, ToCallFri);
            friday.ItemsSource = fri;
            List<string> sat=DisplayWorkout(Saturday, 5, ToCallSat);
            saturday.ItemsSource = sat;
            List<string> sun=DisplayWorkout(Sunday, 6, ToCallSun);
            sunday.ItemsSource = sun;

            monday.ItemSelected += async (sender, e) =>
            {
                bool answer = await DisplayAlert("Delete workout", "Do you really want to delete this workout?", "No", "yes");
                if (!answer)
                {
                    string res = monday.SelectedItem.ToString();
                    var resultforItem = c.FindOne(Query.EQ("Type", res));
                    DateTime thisDate = resultforItem.DueDate;
                    c.Delete(resultforItem.Id);
                    mon.Remove(res);
                    var col = Database.db.GetCollection<SchoolTask>("SchoolTasks");

                    var resultInST = col.FindOne(Query.And(Query.EQ("Description", "My workout"), Query.EQ("DueDate", thisDate)));
                    col.Delete(resultInST.Id);
                    monday.ItemsSource = null;
                    monday.ItemsSource = mon;
                }
            };

            tuesday.ItemSelected += async (sender, e) =>
            {
                bool answer = await DisplayAlert("Delete workout", "Do you really want to delete this workout?", "No", "yes");
                if (!answer)
                {
                    string res = tuesday.SelectedItem.ToString();
                    var resultforItem = c.FindOne(Query.EQ("Type", res));
                    DateTime thisDate = resultforItem.DueDate;
                    c.Delete(resultforItem.Id);
                    tue.Remove(res);
                    var col = Database.db.GetCollection<SchoolTask>("SchoolTasks");

                    var resultInST = col.FindOne(Query.And(Query.EQ("Description", "My workout"), Query.EQ("DueDate", thisDate)));
                    col.Delete(resultInST.Id);
                    tuesday.ItemsSource = null;
                    tuesday.ItemsSource = tue;
                }
            };

            wednesday.ItemSelected += async (sender, e) =>
            {
                bool answer = await DisplayAlert("Delete workout", "Do you really want to delete this workout?", "No", "yes");
                if (!answer)
                {
                    string res = wednesday.SelectedItem.ToString();
                    var resultforItem = c.FindOne(Query.EQ("Type", res));
                    DateTime thisDate = resultforItem.DueDate;
                    c.Delete(resultforItem.Id);
                    wed.Remove(res);
                    var col = Database.db.GetCollection<SchoolTask>("SchoolTasks");

                    var resultInST = col.FindOne(Query.And(Query.EQ("Description", "My workout"), Query.EQ("DueDate", thisDate)));
                    col.Delete(resultInST.Id);
                    wednesday.ItemsSource = null;
                    wednesday.ItemsSource = wed;
                }
            };

            thursday.ItemSelected += async (sender, e) =>
            {
                bool answer = await DisplayAlert("Delete workout", "Do you really want to delete this workout?", "No", "yes");
                if (!answer)
                {
                    string res = thursday.SelectedItem.ToString();
                    var resultforItem = c.FindOne(Query.EQ("Type", res));
                    DateTime thisDate = resultforItem.DueDate;
                    c.Delete(resultforItem.Id);
                    thu.Remove(res);
                    var col = Database.db.GetCollection<SchoolTask>("SchoolTasks");

                    var resultInST = col.FindOne(Query.And(Query.EQ("Description", "My workout"), Query.EQ("DueDate", thisDate)));
                    col.Delete(resultInST.Id);
                    thursday.ItemsSource = null;
                    thursday.ItemsSource = thu;
                }
            };

            friday.ItemSelected += async (sender, e) =>
            {
                bool answer = await DisplayAlert("Delete workout", "Do you really want to delete this workout?", "No", "yes");
                if (!answer)
                {
                    string res = friday.SelectedItem.ToString();
                    var resultforItem = c.FindOne(Query.EQ("Type", res));
                    DateTime thisDate = resultforItem.DueDate;
                    c.Delete(resultforItem.Id);
                    fri.Remove(res);
                    var col = Database.db.GetCollection<SchoolTask>("SchoolTasks");

                    var resultInST = col.FindOne(Query.And(Query.EQ("Description", "My workout"), Query.EQ("DueDate", thisDate)));
                    col.Delete(resultInST.Id);
                    friday.ItemsSource = null;
                    friday.ItemsSource = fri;
                }
            };

            saturday.ItemSelected += async (sender, e) =>
            {
                bool answer = await DisplayAlert("Delete workout", "Do you really want to delete this workout?", "No", "yes");
                if (!answer)
                {
                    string res = saturday.SelectedItem.ToString();
                    var resultforItem = c.FindOne(Query.EQ("Type", res));
                    DateTime thisDate = resultforItem.DueDate;
                    c.Delete(resultforItem.Id);
                    sat.Remove(res);
                    var col = Database.db.GetCollection<SchoolTask>("SchoolTasks");

                    var resultInST = col.FindOne(Query.And(Query.EQ("Description", "My workout"), Query.EQ("DueDate", thisDate)));
                    col.Delete(resultInST.Id);
                    saturday.ItemsSource = null;
                    saturday.ItemsSource = sat;
                }
            };

            sunday.ItemSelected += async (sender, e) =>
            {
                bool answer = await DisplayAlert("Delete workout", "Do you really want to delete this workout?", "No", "yes");
                if (!answer)
                {
                    string res = wednesday.SelectedItem.ToString();
                    var resultforItem = c.FindOne(Query.EQ("Type", res));
                    DateTime thisDate = resultforItem.DueDate;
                    c.Delete(resultforItem.Id);
                    sun.Remove(res);
                    var col = Database.db.GetCollection<SchoolTask>("SchoolTasks");

                    var resultInST = col.FindOne(Query.And(Query.EQ("Description", "My workout"), Query.EQ("DueDate", thisDate)));
                    col.Delete(resultInST.Id);
                    sunday.ItemsSource = null;
                    sunday.ItemsSource = sun;
                }
            };
        }   

        public static List<string> DisplayWorkout(DateTime date, int col, List<string> toadd)
        {
            
            var c = Database.db.GetCollection<Workout>("AllWorkouts");
            var list = c.Find(Query.EQ("DueDate", date.Date));
            foreach(var workout in list)
            {
                toadd.Add(workout.Type);
            }

            return toadd;

        }
        private async void OnCloseClicked2(object sender, EventArgs args)
        {
            await Navigation.PopAsync();

        }

        private async void playworkout(object sender, EventArgs args)
        {

            await Navigation.PushAsync( new StartWorkout(DateTime.Now));

        }
    }
}