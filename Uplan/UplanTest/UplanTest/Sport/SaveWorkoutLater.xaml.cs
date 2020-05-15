using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UplanTest
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SaveWorkoutLater : ContentPage
    {
        public bool repeatonce = false;
        public bool repeatwice = false;
        public bool repeathrice = false;
        ListEntry ex1;
        ListEntry ex2;
        ListEntry ex3;
        ListEntry ex4;
        ListEntry ex5;
        ListEntry ex6;
        ListEntry ex7;
        ListEntry ex8;
        ListEntry ex9;
        ListEntry ex10;


        public SaveWorkoutLater(ListEntry ex1,ListEntry ex2,ListEntry ex3,ListEntry ex4, ListEntry ex5,ListEntry ex6, ListEntry ex7, ListEntry ex8, ListEntry ex9,ListEntry ex10)
        {
            InitializeComponent();
        }

        private async void OnCloseClicked2(object sender, EventArgs args)
        {

            await Navigation.PopAsync();

        }

        private async void Save(object sender, EventArgs args)
        {
            DateTime ForInsert = DateTime.Now;
            DateTime? selectedDate1 = DatePick.Date;

            if (selectedDate1.HasValue)

            {ForInsert = (DateTime)selectedDate1;}
            Workout.InsertWorkout(ex1, ex2, ex3, ex4, ex5, ex6, ex7, ex8, ex9, ex10, ForInsert);
            if(repeatonce)
            {
                Workout.InsertWorkout(ex1, ex2, ex3, ex4, ex5, ex6, ex7, ex8, ex9, ex10, ForInsert.AddDays(7));
            }


            if (repeatwice)
            {
                Workout.InsertWorkout(ex1, ex2, ex3, ex4, ex5, ex6, ex7, ex8, ex9, ex10, ForInsert.AddDays(7));
                Workout.InsertWorkout(ex1, ex2, ex3, ex4, ex5, ex6, ex7, ex8, ex9, ex10, ForInsert.AddDays(14));
            }

            if (repeathrice)
            {
                Workout.InsertWorkout(ex1, ex2, ex3, ex4, ex5, ex6, ex7, ex8, ex9, ex10, ForInsert.AddDays(7));
                Workout.InsertWorkout(ex1, ex2, ex3, ex4, ex5, ex6, ex7, ex8, ex9, ex10, ForInsert.AddDays(14));
                Workout.InsertWorkout(ex1, ex2, ex3, ex4, ex5, ex6, ex7, ex8, ex9, ex10, ForInsert.AddDays(21));
            }
            await Navigation.PopAsync();

        }

        private async void Once(object sender, EventArgs args)
        {

            repeatonce = !repeatonce;
            if(Oncee.BackgroundColor == Color.White)
            {
                Oncee.BackgroundColor = Color.CadetBlue;
            }
            else
            {
                Oncee.BackgroundColor = Color.White;
            }
            Twicee.BackgroundColor = Color.White;
            Thricee.BackgroundColor = Color.White;

        }

        private async void Twice(object sender, EventArgs args)
        {

            repeatwice = !repeatwice;
            if (Twicee.BackgroundColor == Color.White)
            {
                Twicee.BackgroundColor = Color.CadetBlue;
            }
            else
            {
                Twicee.BackgroundColor = Color.White;
            }
            Oncee.BackgroundColor = Color.White;
            
            Thricee.BackgroundColor = Color.White;

        }

        private async void Thrice(object sender, EventArgs args)
        {

            repeathrice = !repeathrice;
            if (Thricee.BackgroundColor == Color.White)
            {
                Thricee.BackgroundColor = Color.CadetBlue;
            }
            else
            {
                Thricee.BackgroundColor = Color.White;
            }
            Oncee.BackgroundColor = Color.White;

            Twicee.BackgroundColor = Color.White;

        }
    }
}