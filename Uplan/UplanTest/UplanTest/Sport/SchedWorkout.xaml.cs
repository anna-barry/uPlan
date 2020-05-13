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
    public partial class SchedWorkout : ContentPage
    {
        public SchedWorkout()
        {
            InitializeComponent();

            //___________ Add Content here in case of change __________
            Abs1.Content = Strength;
            Abs2.Content = IronClad;
            Abs3.Content = Obliques;
            Abs4.Content = WOCrunches;
            Abs5.Content = SumAb1;
            Abs6.Content = SumAb2;
            Arms1.Content = ForArms1;
            Arms2.Content = ForArms2;
            Arms3.Content = ForArms3;
            Arms4.Content = ForArms4;
            Arms5.Content = ForArms5;
            Arms6.Content = ForArms6;
        }

        private async void OnCloseClicked2(object sender, EventArgs args)
        {

            await Navigation.PopAsync();

        }

        private async void GetInfoAbs1(object sender, EventArgs args)
        {

            
        }

        private async void AddAbs1(object sender, EventArgs args)
        {

            

        }

        private async void GetInfoAbs2(object sender, EventArgs args)
        {


        }

        private async void AddAbs2(object sender, EventArgs args)
        {



        }

        private async void GetInfoAbs3(object sender, EventArgs args)
        {


        }

        private async void AddAbs3(object sender, EventArgs args)
        {



        }

        private async void GetInfoAbs4(object sender, EventArgs args)
        {


        }

        private async void AddAbs4(object sender, EventArgs args)
        {



        }

        private async void GetInfoAbs5(object sender, EventArgs args)
        {


        }

        private async void AddAbs5(object sender, EventArgs args)
        {



        }

        private async void GetInfoAbs6(object sender, EventArgs args)
        {


        }

        private async void AddAbs6(object sender, EventArgs args)
        {



        }

        private async void GetInfoArms1(object sender, EventArgs args)
        {


        }

        private async void AddArms1(object sender, EventArgs args)
        {



        }

        private async void GetInfoArms2(object sender, EventArgs args)
        {


        }

        private async void AddArms2(object sender, EventArgs args)
        {



        }

        private async void GetInfoArms3(object sender, EventArgs args)
        {


        }

        private async void AddArms3(object sender, EventArgs args)
        {



        }

        private async void GetInfoArms4(object sender, EventArgs args)
        {


        }

        private async void AddArms4(object sender, EventArgs args)
        {



        }

        private async void GetInfoArms5(object sender, EventArgs args)
        {


        }

        private async void AddArms5(object sender, EventArgs args)
        {



        }

        private async void GetInfoArms6(object sender, EventArgs args)
        {


        }

        private async void AddArms6(object sender, EventArgs args)
        {



        }
    }
}