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