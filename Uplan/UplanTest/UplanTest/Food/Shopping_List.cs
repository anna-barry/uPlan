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
    class Shopping_List: ContentPage
    {
        public Shopping_List()
        {
            ScrollView ScrollContainer = new ScrollView
            {
                Orientation = ScrollOrientation.Both,
            };

            var grid = new Xamarin.Forms.Grid();

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
            tt.TextColor = Color.MediumVioletRed;
            tt.FontSize = 30;
            tt.HorizontalTextAlignment = TextAlignment.Center;
            tt.FontAttributes = FontAttributes.Bold;
            grid.Children.Add(tt, 1, 0);
            Grid.SetColumnSpan(tt, 12);
            //Add(nom,col,row)

            //______________ Titre de la liste___________________________
            Label LShopList = new Label();
            LShopList.Text = "Shopping List";
            LShopList.TextColor = Color.MediumVioletRed;
            LShopList.FontSize = 26;
            LShopList.FontAttributes = FontAttributes.Bold;
            grid.Children.Add(LShopList, 1, 0);
            Grid.SetColumnSpan(LShopList, 3);
            //Add(nom,col,row)

            //____________________________________________________________
            //__________________ Frame = Liste de Courses_________________
            List<(Label, CheckBox)> AllOfLabAndCheck = GetAllFoodItem();

            var testgrid = new Xamarin.Forms.Grid();
            int roww = 2;
            for (int i = 0; i < 3; i++)
            {
                testgrid.ColumnDefinitions.Add(new ColumnDefinition()
                {
                    Width = new GridLength(100, GridUnitType.Absolute)
                });
            }

            for (int i = 0; i < 3; i++)
            {
                testgrid.RowDefinitions.Add(new RowDefinition()
                {
                    Height = new GridLength(100, GridUnitType.Absolute)
                });
            }


            foreach ((Label labb, CheckBox checkk) in AllOfLabAndCheck)
            {
                checkk.Color = Color.BlueViolet; 
                testgrid.Children.Add(checkk,0,roww);
                testgrid.Children.Add(labb,1, roww);
                roww += 1;
            }


            StackLayout test = new StackLayout();
             foreach((Label labb, CheckBox checkk) in AllOfLabAndCheck) //(Label labb, CheckBox checkk)
             {
                 checkk.Color = Color.BlueViolet;
                 
                 test.Children.Add(checkk);
                 test.Children.Add(labb);
             }

            //Content = testgrid;
            Frame frame = new Frame
            {
                BorderColor = Color.DarkSlateBlue,
                CornerRadius = 10,
                HasShadow = true,
                ScaleX = 1,
                ScaleY = 1,

                //Content = new Label { Text = "Example" }


                Content = test
            };
        

            grid.Children.Add(frame, 1 , 1);
            Grid.SetColumnSpan(frame, 3);
            Grid.SetRowSpan(frame, 15);

            //______________________________________________________________________________

            //__________________Refresh button______________________________________________

            ImageButton Refresh = new ImageButton();
            Refresh.Source = "Assets/refresh_Icon.png";
            Refresh.Scale = 0.75;
            Refresh.Clicked += (sender, e) => RefreshFoodItems();
            grid.Children.Add(Refresh, 4, 1);
          
            //__________________________________________________________________________
            //______________ Ajout de chose dans ses placards___________________________
            Label ADD = new Label();
            ADD.Text = "Add in my pantry";
            ADD.TextColor = Color.MediumVioletRed;
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
            simpleADD.TextColor = Color.MediumVioletRed;
            simpleADD.HorizontalTextAlignment = TextAlignment.Center;
            simpleADD.VerticalTextAlignment = TextAlignment.Center;
            simpleADD.FontAttributes = FontAttributes.Bold;
            simpleADD.FontSize = 15;
            simpleADD.HorizontalTextAlignment = TextAlignment.Start;
            grid.Children.Add(simpleADD, 6, 2);
            Grid.SetColumnSpan(simpleADD, 3);

            //entrée du code

            Entry codeplace = new Entry();
            string code = codeplace.Text;
            grid.Children.Add(codeplace,6,3);
            Grid.SetColumnSpan(codeplace, 2);

            Button save = new Button();
            save.Text = "ENTER";
            grid.Children.Add(save, 8, 3);
            //save.Clicked += (sender, e) => UseTheAPI(); 

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
            manuADD.TextColor = Color.MediumVioletRed;
            manuADD.FontSize = 15;
            manuADD.HorizontalTextAlignment = TextAlignment.Center;
            manuADD.VerticalTextAlignment = TextAlignment.Center;
            manuADD.FontAttributes = FontAttributes.Bold;
            manuADD.VerticalTextAlignment = TextAlignment.Start;
            grid.Children.Add(manuADD, 6, 5);
            Grid.SetColumnSpan(manuADD, 3);

            //titre du type
            Label addtype = new Label();
            addtype.Text = "Food Type:";
            addtype.TextColor = Color.MediumVioletRed;
            addtype.FontSize = 15;
            addtype.VerticalTextAlignment = TextAlignment.End;
            grid.Children.Add(addtype, 6, 5);
            Grid.SetColumnSpan(addtype, 3);

            //picker du type
             Picker foodtype = new Picker();
            var type = codeplace.Text;
            grid.Children.Add(foodtype, 6, 6);
            Grid.SetColumnSpan(foodtype, 2);

            /*faire ici un bouton ajout de type si il 'existe pas*/
             
            Button moretype = new Button();
            moretype.Text = "+";
            grid.Children.Add(moretype ,8, 6);
            /*moretype.Clicked += (sender, e) => type=AddType();  --fonction qui amèene a une page dans les type de add food à add food
             */

            //entrée desrciption
            Label adddesc = new Label();
            adddesc.Text = "Food Description:";
            adddesc.TextColor = Color.MediumVioletRed;
            adddesc.FontSize = 15;
            adddesc.VerticalTextAlignment = TextAlignment.End;
            grid.Children.Add(adddesc, 6, 7);
            Grid.SetColumnSpan(adddesc, 3);

            Entry fooddesc = new Entry();
            string desc = codeplace.Text;
            grid.Children.Add(fooddesc, 6, 8);
            Grid.SetColumnSpan(fooddesc, 3);

            //date de peremtpion
            Label addperemp = new Label();
            addperemp.Text = "Peremption date:";
            addperemp.TextColor = Color.MediumVioletRed;
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


            //______________ Affichage de ses placards___________________________
            Label Fridge = new Label();
            Fridge.Text = "What is in my pantry?";
            Fridge.TextColor = Color.MediumVioletRed;
            Fridge.FontSize = 26;
            Fridge.FontAttributes = FontAttributes.Bold;
            grid.Children.Add(Fridge, 11, 1);
            Grid.SetColumnSpan(Fridge, 3);

            //________________________________________________________
            ScrollContainer.Content = grid;

            Content = ScrollContainer;
        }


        public void RefreshFoodItems() //async
        {
            var col = Database.db.GetCollection<FoodItem>("FoodForShoppingList");
            col.DeleteAll();
           //await Navigation.PushAsync(new Shopping_List());
        }

        public static void RefreshView()
        { 
            
        }

        public static List<(Label,CheckBox)> GetAllFoodItem()
        {
            List<(Label, CheckBox)> res = new List<(Label, CheckBox)>();

            /*___________________ Info ______________________________
            CheckBox checkBox = new CheckBox { IsChecked = true };

            void OnCheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e)
                    {
                        // Perform required operation after examining e.Value
                                                                                   }
            checkBox.CheckedChanged += (sender, e) =>
                                                                                   */

            var col = Database.db.GetCollection<FoodItem>("FoodForShoppinglist");
            var results = col.FindAll();
            
            foreach(var lilres in results)
            {
                Label forCheck = new Label();
                forCheck.Text = lilres.NameDesc;

                CheckBox checkBox = new CheckBox();
                {
                    checkBox.CheckedChanged += (sender, e) =>
                    {
                        if (e.Value)

                        {
                            col.Delete(lilres.Id);
                            //orCheck.SetBinding({ x: Reference checkBox}, Path = checkbox.IsChecked);
                            //forCheck.IsVisible = false;
                        }
                    };

                };

                res.Add((forCheck, checkBox));


            }
            


            return res;

        }

    }

}

