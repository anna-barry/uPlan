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
    public partial class SaveNow : ContentPage
    {

        ListEntry exo1;
        ListEntry exo2;
        ListEntry exo3;
        ListEntry exo4;
        ListEntry exo5;
        ListEntry exo6;
        ListEntry exo7;
        ListEntry exo8;
        ListEntry exo9;
        ListEntry exo10;
        String Type;

        public SaveNow(ListEntry ex1, ListEntry ex2, ListEntry ex3, ListEntry ex4, ListEntry ex5, ListEntry ex6, ListEntry ex7, ListEntry ex8, ListEntry ex9, ListEntry ex10, string type)
        {
            InitializeComponent();
            exo1 = ex1;
            exo2 = ex2;
            exo3 = ex3;
            exo4 = ex4;
            exo5 = ex5;
            exo6 = ex6;
            exo7 = ex7;
            exo8 = ex8;
            exo9 = ex9;
            exo10 = ex10;
            Type = type;
        }

        private async void OnCloseClicked2(object sender, EventArgs args)
        {

            await Navigation.PopAsync();

        }

        private async void Save(object sender, EventArgs args)
        {
            DateTime ForInsert = DateTime.Now;

            Workout.InsertWorkout(exo1, exo2, exo3, exo4, exo5, exo6, exo7, exo8, exo9, exo10, ForInsert, Type);

            await Navigation.PopAsync();

        }
    }
}