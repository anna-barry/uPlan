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

            //______________ Titre de la page___________________________
            Label tt = new Label();
            tt.Text = "MY KITCHEN";
            tt.TextColor = Color.BlueViolet;
            tt.FontSize = 30;
            tt.HorizontalTextAlignment = TextAlignment.Center;
            tt.FontAttributes = FontAttributes.Bold;
            grid.Children.Add(tt, 1, 0);
            Grid.SetColumnSpan(tt, 12);
            

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

            //__________________________________________________________________________
            //______________ Ajout de chose dans ses placards___________________________
            Label ADD = new Label();
            ADD.Text = "Add in my pantry";
            ADD.TextColor = Color.BlueViolet;
            ADD.FontSize = 26;
            ADD.FontAttributes = FontAttributes.Bold;
            grid.Children.Add(ADD, 6, 1);
            Grid.SetColumnSpan(ADD, 3);

            //______________Initialisation des valeurs que l'on souhaite______________
            /*string desc;
             * DateTime peremp;
             * string type;
             * sring code; (le code et le type ici sont =) */

            //______________Bouton pour utiliser l'api?_________________________________
            Label simpleADD = new Label();
            simpleADD.Text = "Scan or enter the code of your product";
            simpleADD.TextColor = Color.BlueViolet;
            simpleADD.HorizontalTextAlignment = TextAlignment.Center;
            simpleADD.VerticalTextAlignment = TextAlignment.Center;
            simpleADD.FontAttributes = FontAttributes.Bold;
            simpleADD.FontSize = 15;
            simpleADD.HorizontalTextAlignment = TextAlignment.Start;
            grid.Children.Add(simpleADD, 6, 2);
            Grid.SetColumnSpan(simpleADD, 3);

            //entrée du code

            //Entry EntréeCodeBarre = new Entry();
            string code = EntréeCodeBarre.Text;
            grid.Children.Add(EntréeCodeBarre, 6, 3);
            Grid.SetColumnSpan(EntréeCodeBarre, 2);

            Button save = new Button();
            save.Text = "ENTER";
            save.Clicked += (sender, e) => Sauvegarder_Clicked(sender, e);
            grid.Children.Add(save, 8, 3);


            //clique sur un bouton pour utiliser l'api?

            Button scan = new Button();
            scan.Text = "SCAN";
            grid.Children.Add(scan, 6, 4);
            Grid.SetColumnSpan(scan, 3);
            //scan.Clicked += (sender, e) => // use code barre -> UseTheAPI();

            // pour rentrer manuellement 

            //titre
            Label manuADD = new Label();
            manuADD.Text = "Add by yourslef";
            manuADD.TextColor = Color.BlueViolet;
            manuADD.FontSize = 15;
            manuADD.HorizontalTextAlignment = TextAlignment.Center;
            manuADD.VerticalTextAlignment = TextAlignment.Center;
            manuADD.FontAttributes = FontAttributes.Bold;
            manuADD.VerticalTextAlignment = TextAlignment.Start;
            grid.Children.Add(manuADD, 6, 5);
            Grid.SetColumnSpan(manuADD, 3);

            //titre du type
            /**  Label addtype = new Label();
              addtype.Text = "Food Type:";
              addtype.TextColor = Color.MediumVioletRed;
              addtype.FontSize = 15;
              addtype.VerticalTextAlignment = TextAlignment.End;
              grid.Children.Add(addtype, 6, 5);
              Grid.SetColumnSpan(addtype, 3); */

            //picker du type
            /**  Picker foodtype = new Picker();
             var type = EntréeCodeBarre.Text;
             grid.Children.Add(foodtype, 6, 6);
             Grid.SetColumnSpan(foodtype, 2); */

            /*faire ici un bouton ajout de type si il 'existe pas*/

            /**Button moretype = new Button();
            moretype.Text = "+";
            grid.Children.Add(moretype ,8, 6); */
            /*moretype.Clicked += (sender, e) => type=AddType();  --fonction qui amèene a une page dans les type de add food à add food
             */

            //entrée desrciption
            Label adddesc = new Label();
            adddesc.Text = "Nutriscore of the product:";
            adddesc.TextColor = Color.BlueViolet;
            adddesc.FontSize = 15;
            adddesc.VerticalTextAlignment = TextAlignment.End;
            grid.Children.Add(adddesc, 6, 7);
            Grid.SetColumnSpan(adddesc, 3);

            Label novads = new Label();
            novads.Text = "NovaScore of the product:";
            novads.TextColor = Color.BlueViolet;
            novads.FontSize = 15;
            novads.VerticalTextAlignment = TextAlignment.End;
            grid.Children.Add(adddesc, 7, 7);
            Grid.SetColumnSpan(adddesc, 3);



            string desc = SortieApi.Text;
            grid.Children.Add(SortieApi, 6, 8);
            Grid.SetColumnSpan(SortieApi, 3);



            //date de peremtpion
            Label addperemp = new Label();
            addperemp.Text = "Peremption date:";
            addperemp.TextColor = Color.BlueViolet;
            manuADD.FontSize = 15;
            addperemp.VerticalTextAlignment = TextAlignment.End;
            grid.Children.Add(addperemp, 6, 9);
            Grid.SetColumnSpan(addperemp, 3);

            DatePicker peremption = new DatePicker();
            DateTime date = peremption.Date;
            grid.Children.Add(peremption, 6, 10);
            Grid.SetColumnSpan(peremption, 3);

            //ici faire select a type, avec un petit boouton add a coté au cas ou on veuille en rajouter
            //le code sera le meme 

            Button added = new Button();
            added.Text = "Add";
            grid.Children.Add(added, 6, 11);
            Grid.SetColumnSpan(added, 3);


            /*______________ Affichage de ses placards___________________________
            Label Fridge = new Label();
            Fridge.Text = "What is in my pantry?";
            Fridge.TextColor = Color.MediumVioletRed;
            Fridge.FontSize = 26;
            Fridge.FontAttributes = FontAttributes.Bold;
            grid.Children.Add(Fridge, 11, 1);
            Grid.SetColumnSpan(Fridge, 3);

            //________________________________________________________
            */
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

