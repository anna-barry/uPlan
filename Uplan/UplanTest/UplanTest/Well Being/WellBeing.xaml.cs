using System;
using System.Collections.Generic;
using System.Linq;
using Plugin.SimpleAudioPlayer;
using SkiaSharp;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.Buttons;
using Xamarin.Forms;
using LiteDB;
using MediaManager;
using MediaManager.Forms;

using Xamarin.Forms.Xaml;
using Syncfusion.XForms.Buttons;
using Xamarin.Forms.PlatformConfiguration;
using System.Text.RegularExpressions;
using UplanTest;
using MediaManager.Player;
using System.ComponentModel;
using MediaManager.Notifications;
//using UplanTest.Well_Being;//

namespace UplanTest
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WellBeing : ContentPage


    {

        Label Tittle = new Label { Text = "My Well Being", TextColor = Color.Violet, FontSize = 40};






        Label QUOTESs = new Label {   VerticalTextAlignment = TextAlignment.Center, FontAttributes = FontAttributes.Italic, FontSize = 40};

        ImageButton others = new ImageButton { Source = "Assets/plus.png", HeightRequest = 30};

        Button chrono1 = new Button { WidthRequest = 60,  HeightRequest = 60, CornerRadius = 50, BorderColor = Color.White, BackgroundColor = Color.FromHex("#2A6A74"), Text = "10m",  TextColor = Color.White, FontAttributes = FontAttributes.Bold };

        Button chrono2 = new Button { WidthRequest = 60, HeightRequest = 60, CornerRadius = 50, BorderColor = Color.White, BackgroundColor = Color.FromHex("#FF1B91A3"), Text = "15m", TextColor = Color.White, FontAttributes = FontAttributes.Bold };

        Button chrono3 = new Button { WidthRequest = 60, HeightRequest = 60, CornerRadius = 50, BorderColor = Color.White, BackgroundColor = Color.FromHex("#FF12BBD5"), Text = "20m", TextColor = Color.White, FontAttributes = FontAttributes.Bold };

        Button chrono4 = new Button { WidthRequest = 40, HeightRequest = 40, CornerRadius = 50, BorderColor = Color.White, BackgroundColor = Color.FromHex("#FF03DCFD"), Text = "30m", TextColor = Color.White, FontAttributes = FontAttributes.Bold };
        ImageButton back = new ImageButton { HeightRequest = 10, Source = "Assets/backf.png" };

        Frame c1 = new Frame { BackgroundColor = Color.Violet, Margin = 5, BorderColor = Color.Black, CornerRadius = 50, HeightRequest = 60, WidthRequest = 60, IsClippedToBounds = true, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center };
        Frame c2 = new Frame { BackgroundColor = Color.Violet, Margin = 5, BorderColor = Color.Black, CornerRadius = 50, HeightRequest = 60, WidthRequest = 60, IsClippedToBounds = true, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center };
        Frame c3 = new Frame { BackgroundColor = Color.Violet, Margin = 5, BorderColor = Color.Black, CornerRadius = 50, HeightRequest = 60, WidthRequest = 60, IsClippedToBounds = true, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center};
        Frame c4 = new Frame { BackgroundColor = Color.Violet, Margin = 5, BorderColor = Color.Black, CornerRadius = 50, HeightRequest = 60, WidthRequest = 60, IsClippedToBounds = true, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center };

        Grid grid = new Grid();

        Frame CView = new Frame
        {
           // BackgroundColor = Color.FromHex("#FFE6ACF3"),
            BorderColor = Color.Gray,
            HasShadow = false,
            CornerRadius = 5,
            Padding = 15,
            Content = new StackLayout

            {
                Children =
                    {
                      new Label
                      {
                           Text = "Select your Rest Time",
                           
                           HorizontalTextAlignment = TextAlignment.Center,
                           FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                           FontAttributes = FontAttributes.Bold
                      },
                       new BoxView
                      {
                           Color = Color.BlueViolet,
                            HeightRequest = 2,
                            HorizontalOptions = LayoutOptions.Fill
                      },
                       //QUOTESs
                       
                      
                       
                    }


            }
        };
        Frame Tpass = new Frame { IsVisible = false, BorderColor = Color.Gray, HasShadow = false, CornerRadius = 5, Padding = 15 };
       
        public WellBeing()
        {

            c1.Content = chrono1;
            c2.Content = chrono2;
            c3.Content = chrono3;
            c4.Content = chrono4;

            
            InitializeComponent();

            var col = Database.db.GetCollection<ListEntry>("ListEntries");  

            Random rand = new Random();

            int rando = rand.Next(0, 40);


            var truc = col.FindOne(Query.And(Query.EQ("Type", "QUOTES"), Query.EQ("Code", Convert.ToString(rando))));
           
          



            
            grid.BackgroundColor = Color.AliceBlue;
            

            ScrollView scroll = new ScrollView { Orientation = ScrollOrientation.Both };
            scroll.Content = grid;
            Content = scroll;

            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(50) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(50) });
            for (int i = 1; i < 8; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(100) });

            }

            for (int k = 0; k < 8; k++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(150) });

            }

            //_______Affichage des quotes_________________

            Image moral = new Image { Source = "Assets/moral.png" };

            //____________FRAME POUR QUOTES__________________________
            Frame QuoteView = new Frame
            {
                BorderColor = Color.Gray,
              //  BackgroundColor = Color.FromHex("#FFE4C0ED"),
                HasShadow = false,
                CornerRadius = 5,
                Padding = 15,
                Content = new StackLayout
                
                {
                    Children =
                    {
                      new Label
                      {
                           Text = "Quote of the day",
                          
                          // TextColor = Color.White,
                           HorizontalTextAlignment = TextAlignment.Center,
                           FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                           FontAttributes = FontAttributes.Bold
                      },
                       new BoxView
                      { 
                           Color = Color.BlueViolet,
                            HeightRequest = 2,
                            HorizontalOptions = LayoutOptions.Fill
                      },
                       //QUOTESs
                       
                      
                       
                    }
                    
                    
                }
            };

            //_______ Frame pour les Timers___________
         



            //______________Affichage des chronos______________



            QUOTESs.Text = truc.Description;



         
         
            grid.Children.Add(QuoteView, 1, 2);
           
            grid.Children.Add(QUOTESs, 1, 2);

            grid.Children.Add(CView, 1, 6);
            // grid.Children.Add(others, 2, 3);

            grid.Children.Add(Tittle, 5, 1);
            grid.Children.Add(back, 0, 0);
            grid.Children.Add(Tpass, 9, 1);

            grid.Children.Add(c1, 1, 7);
            grid.Children.Add(c2, 2, 7);
            grid.Children.Add(c3, 3, 7);
            grid.Children.Add(c4, 4, 7);

            Grid.SetColumnSpan(Tittle, 2);
          
            Grid.SetColumnSpan(QuoteView, 4);
            Grid.SetColumnSpan(QUOTESs, 3);
            Grid.SetRowSpan(QuoteView, 3);
            Grid.SetRowSpan(QUOTESs, 3);
            Grid.SetColumnSpan(CView, 4);
            Grid.SetRowSpan(CView, 2);

            back.IsVisible = false;

            back.Clicked += new EventHandler(this.Back);

            //_____LEs timers___________

            chrono1.Clicked += new EventHandler(this.ten);
            chrono2.Clicked += new EventHandler(this.fivet);
            chrono3.Clicked += new EventHandler(this.twenty);
            chrono4.Clicked += new EventHandler(this.thirty);



            others.HorizontalOptions = LayoutOptions.End;

           // others.Clicked += new EventHandler(this.SeeOther);

            
        }

       /* void SeeOther (System.Object sender, System.EventArgs e)
        {
            

            var col = Database.db.GetCollection<ListEntry>("ListEntries");  // Les QUotes

            Random rand = new Random();

            int rando = rand.Next(0, 40);


            var truc = col.FindOne(Query.And(Query.EQ("Type", "QUOTES"), Query.EQ("Code", Convert.ToString(rando))));

            QUOTESs.Animate("animation", new Animation(v => QUOTESs.Scale = v, 1, 1, Easing.CubicInOut));
            QUOTESs.Text = truc.Description;
            QUOTESs.FontAttributes = FontAttributes.Italic;

           
        } */

        void ten(System.Object sender, System.EventArgs e)

        {
            
            Tpass.IsVisible = true;
            grid.Children.Add(c1, 9, 1);
            c1.HeightRequest = 80;
            back.IsVisible = true;
            CView.IsVisible = false;
            c2.IsVisible = false;
            c3.IsVisible = false;
            c4.IsVisible = false;

            int second = 59;
            int minutes = 9;
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
             {
                //action toutes les secondes
                Device.BeginInvokeOnMainThread(() =>
                 {
                     chrono1.Animate("animation", new Animation(v => QUOTESs.Scale = v, 1, 1, Easing.CubicInOut));
                     
                     chrono1.Text =Convert.ToString(minutes) +":" + Convert.ToString(second);
                     second--;


                 });
               

                 if ((second == 0) && (minutes != 0))
                 {
                     second = 59;
                     minutes--;
                 }
                 if ((second == 0) && (minutes == 0))
                 {
                     DisplayAlert("Alert", "Your break time has finished", "cancel");
                     return false;
                 }
                 return true;
             });


            

           
            
        }
            

            
            
            




        
        void fivet(System.Object sender, System.EventArgs e)

        {
            CView.IsVisible = false;
            
            Tpass.IsVisible = true;
            grid.Children.Add(c2, 9, 1);



       
            back.IsVisible = true;
            c1.IsVisible = false;
            c3.IsVisible = false;
            c4.IsVisible = false;
            int second = 59;
            int minutes = 14;
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                //action toutes les secondes
                Device.BeginInvokeOnMainThread(() =>
                {

                    chrono2.Text = Convert.ToString(minutes) + ":" + Convert.ToString(second);
                    second--;


                });


                if ((second == 0) && (minutes != 0))
                {
                    second = 59;
                    minutes--;
                }
                if ((second == 0) && (minutes == 0))
                {
                    DisplayAlert("Alert", "Your break time has finished", "cancel");
                    return false;
                }
                return true;
            });





        }
        void twenty(System.Object sender, System.EventArgs e)

        {
            CView.IsVisible = false;
          
           
            Tpass.IsVisible = true;
            grid.Children.Add(c3, 9, 1);

            back.IsVisible = true;
            c1.IsVisible = false;
            c2.IsVisible = false;
            c4.IsVisible = false;
            int minutes = 19;
            int second = 59;
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                //action toutes les secondes
                Device.BeginInvokeOnMainThread(() =>
                {

                    chrono3.Text = Convert.ToString(minutes) + ":" + Convert.ToString(second);
                    second--;


                });




                if ((second == 0) && (minutes != 0))
                {
                    second = 59;
                    minutes--;
                }
                if ((second == 0) && (minutes == 0))
                {
                    DisplayAlert("Alert", "Your break time has finished", "cancel");
                    return false;
                }
                return true;
            });




        }
        void thirty(System.Object sender, System.EventArgs e)

        {
            Tpass.IsVisible = true;
            grid.Children.Add(c4, 9, 1);
            CView.IsVisible = false;
           
          
            back.IsVisible = true;
            c1.IsVisible = false;
            c2.IsVisible = false;
            c3.IsVisible = false;

            int minutes = 29;
            int second = 59;
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                //action toutes les secondes
                Device.BeginInvokeOnMainThread(() =>
                {

                    chrono4.Text = Convert.ToString(minutes) + ":" + Convert.ToString(second);
                    second--;


                });



                if ((second == 0) && (minutes != 0))
                {
                    second = 59;
                    minutes--;
                }
                if ((second == 0) && (minutes == 0))
                {
                    DisplayAlert("Alert", "Your break time has finished", "cancel");
                    return false;
                }
                return true;
            });




        }
        void Back(System.Object sender, System.EventArgs e)

        {

            Navigation.PushAsync(new WellBeing());
            



        }






    }

}