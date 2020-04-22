using MediaManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lottie.Forms;
using Lottie;



using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.SimpleAudioPlayer;
using System.Runtime.InteropServices;

namespace UplanTest
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class musik : ContentPage
    {


        public musik()
        {
            InitializeComponent();







        }


        private void ToBack(object sender, EventArgs e)
        {
            Navigation.PushAsync(new WellBeing());
        }
        public ISimpleAudioPlayer p1 = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;


        private async void ToPlay1(object sender, EventArgs e)
        {

            p1.Load("jazz.mp3");

            p1.Play();
            P0.IsVisible = true;
            await P0.ProgressTo(1, 200000, Easing.Linear);








        }
        private void ToPause1(object sender, EventArgs e)
        {

            p1.Pause();
            P0.IsVisible = false;






        }
        private async void ToPlay2(object sender, EventArgs e)
        {
            p1.Load("relax2.mp3");
            p1.Play();
            P1.IsVisible = true;

            await P1.ProgressTo(1, 290000, Easing.Linear);



        }
        private void ToPause2(object sender, EventArgs e)
        {
            p1.Pause();
            P1.IsVisible = false;




        }
        private async void ToPlay3(object sender, EventArgs e)
        {

            p1.Load("relax3.mp3");
            p1.Play();
            P2.IsVisible = true;

            await P2.ProgressTo(1, 218000, Easing.Linear);





        }
        private void ToPause3(object sender, EventArgs e)
        {
            p1.Pause();
            P2.IsVisible = false;




        }
        private async void ToPlay4(object sender, EventArgs e)
        {

            p1.Load("relax4.mp3");
            p1.Play();
            P3.IsVisible = true;
            await P3.ProgressTo(1, 290000, Easing.Linear);



        }
        private void ToPause4(object sender, EventArgs e)
        {
            p1.Pause();
            P3.IsVisible = false;




        }
        private async void ToPlay5(object sender, EventArgs e)
        {

            p1.Load("rock1.mp3");
            p1.Play();
            P4.IsVisible = true;
            await P4.ProgressTo(1, 138000, Easing.Linear);



        }
        private void ToPause5(object sender, EventArgs e)
        {
            p1.Pause();
            P4.IsVisible = false;




        }
        private async void ToPlay6(object sender, EventArgs e)
        {

            p1.Load("rock2.mp3");
            p1.Play();
            P5.IsVisible = true;
            await P5.ProgressTo(1, 231000, Easing.Linear);



        }
        private void ToPause6(object sender, EventArgs e)
        {
            p1.Pause();
            P5.IsVisible = false;




        }
        private async void ToPlay7(object sender, EventArgs e)
        {

            p1.Load("rock3.mp3");
            p1.Play();
            P6.IsVisible = true;
            await P6.ProgressTo(1, 337000, Easing.Linear);




        }
        private void ToPause7(object sender, EventArgs e)
        {
            p1.Pause();
            P6.IsVisible = false;





        }
        private async void ToPlay8(object sender, EventArgs e)
        {

            p1.Load("rock4.mp3");
            p1.Play();
            P7.IsVisible = true;
            await P7.ProgressTo(1, 198000, Easing.Linear);



        }
        private void ToPause8(object sender, EventArgs e)
        {
            p1.Pause();
            P7.IsVisible = false;





        }
    }
}