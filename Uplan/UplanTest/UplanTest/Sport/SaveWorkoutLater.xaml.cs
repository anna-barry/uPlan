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

        public SaveWorkoutLater()
        {
            InitializeComponent();
        }

        private async void OnCloseClicked2(object sender, EventArgs args)
        {

            await Navigation.PopAsync();

        }

        private async void Save(object sender, EventArgs args)
        {

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