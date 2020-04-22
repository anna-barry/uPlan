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
using Syncfusion.Licensing.crypto.encodings;

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
        public ISimpleAudioPlayer p1 = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
        public ISimpleAudioPlayer p2 = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
        public ISimpleAudioPlayer p3 = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
        public ISimpleAudioPlayer p4 = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
        public ISimpleAudioPlayer p5 = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
        public ISimpleAudioPlayer p6 = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
        public ISimpleAudioPlayer p7 = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
        public ISimpleAudioPlayer p8 = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
        bool play1 = false;
        bool play2 = false;
        bool play3 = false;
        bool play4 = false;
        bool play5 = false;
        bool play6 = false;
        bool play7 = false;
        bool play8 = false;


        private async void ToPlay1(object sender, EventArgs e)
        {
           
            if (!play1)
            {
                p1.Load("jazz.mp3");
                play1 = true;
            }
           
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
            if (!play2)
            {
                p2.Load("relax2.mp3");
                play2 = true;
            }
            
             p2.Play();
             P1.IsVisible = true;
           

            await P1.ProgressTo(1, 290000, Easing.Linear);



        }
        private void ToPause2(object sender, EventArgs e)
        {
            p2.Pause();
            P1.IsVisible = false;




        }
        private async void ToPlay3(object sender, EventArgs e)
        {

            if (!play3)
            {
                p3.Load("relax3.mp3");
                play3 = true;
            }
            p3.Play();
            P2.IsVisible = true;

            await P2.ProgressTo(1, 218000, Easing.Linear);





        }
        private void ToPause3(object sender, EventArgs e)
        {
            p3.Pause();
            P2.IsVisible = false;




        }
        private async void ToPlay4(object sender, EventArgs e)
        {
            if (!play4)
            {
                p4.Load("relax4.mp3");
                play4 = true;
            }
            p4.Play();
            P3.IsVisible = true;
            await P3.ProgressTo(1, 290000, Easing.Linear);



        }
        private void ToPause4(object sender, EventArgs e)
        {
            p4.Pause();
            P3.IsVisible = false;




        }
        private async void ToPlay5(object sender, EventArgs e)
        {
            if (!play5)
            {
                p5.Load("rock1.mp3");
                play5 = true;
            }

            p5.Play();
            P4.IsVisible = true;
            await P4.ProgressTo(1, 138000, Easing.Linear);



        }
        private void ToPause5(object sender, EventArgs e)
        {
            p5.Pause();
            P4.IsVisible = false;




        }
        private async void ToPlay6(object sender, EventArgs e)
        {
            if (!play6)
            {
                p6.Load("rock2.mp3");
                play6 = true;
            }
            p6.Play();
            P5.IsVisible = true;
            await P5.ProgressTo(1, 231000, Easing.Linear);



        }
        private void ToPause6(object sender, EventArgs e)
        {
            p6.Pause();
            P5.IsVisible = false;


        }
        private async void ToPlay7(object sender, EventArgs e)
        {
            if (!play7)
            {
                p7.Load("rock3.mp3");
                play7 = true;
            }
            p7.Play();
            P6.IsVisible = true;
            await P6.ProgressTo(1, 337000, Easing.Linear);




        }
        private void ToPause7(object sender, EventArgs e)
        {
            p7.Pause();
            P6.IsVisible = false;





        }
        private async void ToPlay8(object sender, EventArgs e)
        {
            if (!play8)
            {
                p8.Load("rock4.mp3");
                play8 = true;
            }
            
            p8.Play();
            P7.IsVisible = true;
            await P7.ProgressTo(1, 198000, Easing.Linear);



        }
        private void ToPause8(object sender, EventArgs e)
        {
            p8.Pause();
            P7.IsVisible = false;





        }
    }
}