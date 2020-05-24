using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using LiteDB;

using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms.Xaml;
using System.Collections.Specialized;

namespace UplanTest
{
    //public Xamarin.Forms.Grid grid = new Xamarin.Forms.Grid();
    class Shopping_List : ContentPage
    {
        Entry EntréeCodeBarre = new Entry();
        Entry SortieApi = new Entry();
        public static Xamarin.Forms.Grid grid = new Xamarin.Forms.Grid();
        public static StackLayout test = new StackLayout();
        public static Frame frame = new Frame();
        public static Xamarin.Forms.Grid gridforSL = new Xamarin.Forms.Grid();

        public Shopping_List()
        {
            test.Children.Clear();
            gridforSL.Children.Clear();
            ApiHelper.InitializeClient();

            ScrollView ScrollContainer = new ScrollView
            {
                Orientation = ScrollOrientation.Both,
            };

            int colMax = 15;
            int rowMax = 15;
            for (int i = 0; i < colMax; i++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition()
                {
                    Width = new GridLength(100, GridUnitType.Absolute)
                });
            }

            for (int i = 0; i < rowMax; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition()
                {
                    Height = new GridLength(100, GridUnitType.Absolute)
                });
            }

            

            //______________ Titre de la liste___________________________
            Label LShopList = new Label();
            LShopList.Text = "Shopping List";
            LShopList.TextColor = Color.BlueViolet;
            LShopList.FontSize = 26;
            LShopList.FontAttributes = FontAttributes.Bold;
            grid.Children.Add(LShopList, 1, 0);
            Grid.SetColumnSpan(LShopList, 3);
           

            //____________________________________________________________
            //__________________ Frame = Liste de Courses_________________
            List<(Label, CheckBox)> AllOfLabAndCheck = GetAllFoodItem();

          
            
            for (int i = 0; i < 3; i++)
            {
                gridforSL.ColumnDefinitions.Add(new ColumnDefinition()
                {
                    Width = new GridLength(100, GridUnitType.Absolute)
                });
            }

            for (int i = 0; i < 20; i++)
            {
                gridforSL.RowDefinitions.Add(new RowDefinition()
                {
                    Height = new GridLength(100, GridUnitType.Absolute)
                });
            }
            //_________________ Testing grid for this #ITWORKSNOW
            int roww = 0;
            
            foreach ((Label labb, CheckBox checkk) in AllOfLabAndCheck) //(Label labb, CheckBox checkk)
            {
                checkk.Color = Color.BlueViolet;
                checkk.FlowDirection = FlowDirection.LeftToRight;
                checkk.HorizontalOptions = LayoutOptions.End;

                gridforSL.Children.Add(checkk, 0,roww);

                labb.FontSize = 18;
                labb.HorizontalTextAlignment = TextAlignment.Start;
                labb.VerticalOptions = LayoutOptions.Center;
                gridforSL.Children.Add(labb,1,roww);
                Grid.SetColumnSpan(labb, 2);
                
                
                roww += 1;

            }
            int coundofgrid=gridforSL.Children.Count();
            frame.Content = gridforSL;
            frame.BorderColor = Color.DarkSlateBlue;
            frame.CornerRadius = 10;



            grid.Children.Add(frame, 1, 1);
            Grid.SetColumnSpan(frame, 3);
            Grid.SetRowSpan(frame, 15);

            //_____________________________________________________________________________
            //____________________________ Close _________________________________________
            ImageButton Close = new ImageButton();
            Close.Source= "Assets/croix.png";
            Close.HeightRequest = 50;
            Close.Scale = 0.5;
            Close.VerticalOptions = LayoutOptions.Start;
            Close.Clicked += (sender, e) => OnCloseClicked2();
            grid.Children.Add(Close, 3, 0);


            //______________________________________________________________________________
            //__________________Refresh button______________________________________________

            ImageButton Refresh = new ImageButton();
            Refresh.Source = "Assets/refresh_Icon.png";
            Refresh.Scale = 0.75;
            Refresh.Clicked += (sender, e) => RefreshFoodItems();
            grid.Children.Add(Refresh, 4, 1);


            //_____________________________________________________________________________
            //____________________ Add in Shopping List ___________________________________
            ImageButton Add_To_SL = new ImageButton();
            Add_To_SL.Source = "Assets/Add_Food.png";
            Add_To_SL.Scale = 0.65;
            Add_To_SL.Clicked += (sender, e) => Add(sender,e);
            grid.Children.Add(Add_To_SL, 4, 2);

           
            ScrollContainer.Content = grid;

            Content = ScrollContainer;
        }



        public void RefreshFoodItems() //async
        {
            var col = Database.db.GetCollection<FoodItem>("FoodForShoppingList");
            col.DeleteAll();
            RefreshView();
        }

        public static void RefreshView()
        {
            //test.IsVisible = false;
           // grid.Children.Remove(gridforSL);
           // grid.Children.Remove(frame);
            List<(Label, CheckBox)> AllOfLabAndCheck = GetAllFoodItem();
            gridforSL.Children.Clear();
            
            int roww = 0;

            foreach ((Label labb, CheckBox checkk) in AllOfLabAndCheck) //(Label labb, CheckBox checkk)
            {
                checkk.Color = Color.BlueViolet;
                checkk.FlowDirection = FlowDirection.LeftToRight;
                checkk.HorizontalOptions = LayoutOptions.End;

                gridforSL.Children.Add(checkk, 0, roww);

                labb.FontSize = 18;
                labb.HorizontalTextAlignment = TextAlignment.Start;
                labb.VerticalOptions = LayoutOptions.Center;
                gridforSL.Children.Add(labb, 1, roww);
                Grid.SetColumnSpan(labb, 2);

                roww += 1;

            }
            int coundofgrid = gridforSL.Children.Count();
            frame.Content = gridforSL;
            frame.BorderColor = Color.DarkSlateBlue;
            frame.CornerRadius = 10;
            grid.Children.Add(frame, 1, 1);
            Grid.SetColumnSpan(frame, 3);
            Grid.SetRowSpan(frame, 15);

        }

        public static List<(Label, CheckBox)> GetAllFoodItem()
        {
            List<(Label, CheckBox)> res = new List<(Label, CheckBox)>();

            var col = Database.db.GetCollection<FoodItem>("FoodForShoppinglist");
            var results = col.FindAll();

            foreach (var lilres in results)
            {
                Label forCheck = new Label();
                forCheck.Text = "        "+lilres.Amount+" "+lilres.NameDesc;

                CheckBox checkBox = new CheckBox();
                {
                    checkBox.CheckedChanged += (sender, e) =>
                    {
                        if (e.Value)

                        {
                            col.Delete(lilres.Id);
                            checkBox.IsVisible = false;
                            forCheck.IsVisible = false;
                        }
                    };

                };

                res.Add((forCheck, checkBox));


            }



            return res;

        }

        private async void OnCloseClicked2()
        {
            await Navigation.PopAsync();

        }
        async private void Sauvegarder_Clicked(System.Object sender, System.EventArgs e)
        {

            var nutriInfo = await InfoResponseApi.LoadInfo((EntréeCodeBarre.Text));
            if (nutriInfo == null)
            {
                SortieApi.Text = "Barcode Invalid";
                SortieApi.TextColor = Color.Red;
                SortieApi.BackgroundColor = Color.White;
            }
            else
            {

                if (nutriInfo.Nutrition_grades == null)
                {
                    SortieApi.Text = "The product is not listed";
                    SortieApi.BackgroundColor = Color.Black;
                    SortieApi.TextColor = Color.White;

                }

                else
                {
                    string nutri = nutriInfo.Nutrition_grades;
                    
                    SortieApi.TextColor = Color.White;
                  //  SortieApi.Text = $"The nutritional score of the product is { nutri.ToUpper()}\n The nova score of the product is {nova.ToUpper()}";
                    switch (nutri)
                    {
                        case ("a"):
                            SortieApi.BackgroundColor = Color.FromHex("#038141");

                            break;
                        case ("b"):
                            SortieApi.BackgroundColor = Color.FromHex("#85BB2F");
                            break;
                        case ("c"):
                            SortieApi.BackgroundColor = Color.FromHex("#FECB02");
                            break;
                        case ("d"):
                            SortieApi.BackgroundColor = Color.FromHex("#EE8100");
                            break;
                        case ("e"):
                            SortieApi.BackgroundColor = Color.FromHex("#E63E11");
                            break;


                    }
                }


            }

        }
        //________________ Fonction pour réorienter vers la page Ajouter un élément dans la liste de courses
        async void Add(object sender, EventArgs args)

        {

            await Navigation.PushAsync(new AddInShop());
        }



    }

}

