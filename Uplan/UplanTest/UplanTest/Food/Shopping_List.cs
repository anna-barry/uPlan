using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using LiteDB;

using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms.Xaml;

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
            Label LShopList = new Label();
            LShopList.Text = "Shopping List";
            LShopList.TextColor = Color.MediumVioletRed;
            LShopList.FontSize = 26;
            LShopList.TextDecorations = TextDecorations.Underline;
            grid.Children.Add(LShopList, 1, 0);
            Grid.SetColumnSpan(LShopList, 3);
            //Add(nom,col,row)

            //________________________________________________________

            //__________________ Frame = Liste de Courses_________________
            List<(Label, CheckBox)> AllOfLabAndCheck = GetAllFoodItem();

            var testgrid = new Xamarin.Forms.Grid();
            int roww = 2;
            for (int i = 0; i < 2; i++)
            {
                testgrid.ColumnDefinitions.Add(new ColumnDefinition()
                {
                    Width = new GridLength(100, GridUnitType.Absolute)
                });
            }

            for (int i = 0; i < 2; i++)
            {
                testgrid.RowDefinitions.Add(new RowDefinition()
                {
                    Height = new GridLength(100, GridUnitType.Absolute)
                });
            }
            foreach ((Label labb, CheckBox checkk) in AllOfLabAndCheck)
            {
                checkk.Color = Color.BlueViolet;
                testgrid.Children.Add(checkk,1,roww);
                testgrid.Children.Add(labb,2,roww);
                roww += 1;
            }


            StackLayout test = new StackLayout();
            foreach((Label labb, CheckBox checkk) in AllOfLabAndCheck)
            {
                checkk.Color = Color.BlueViolet;
                test.Children.Add(checkk);
                test.Children.Add(labb);
            }

            Content = testgrid;
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
        

        /*Content = new StackLayout 
        {

                {
                    /*new Label
                            {
                                Text = "Card Example",
                                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                                TextColor = Color.DarkSlateBlue,
                                FontAttributes = FontAttributes.Bold

                                },

                    new Label
                             {
                                Text = "Frames can wrap more complex layouts to create more complex UI components, such as this card!"
                                }




        }
    };*/

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


            //________________________________________________________________________________
            //__________________ Add Food From Meal Plan _____________________________________
            
            ImageButton AddFoodFromMeal = new ImageButton();
            AddFoodFromMeal.Source = "Assets/IconMealPlanForSH.png";
            AddFoodFromMeal.Scale = 0.75;
            AddFoodFromMeal.Clicked += (sender, e) => GetShoppinForWeek();
            grid.Children.Add(AddFoodFromMeal, 4, 2);



            //________________________________________________________
            ScrollContainer.Content = grid;

            Content = ScrollContainer;
        }


        public static void GetShoppinForWeek()
        {
            var col = Database.db.GetCollection<FoodItem>("FoodForShoppingList");
            //INSERT FOOD ITEM FOR EACH FOOD OF THIS WEEK
            // for the dueDate the idea is that for the next Sunday the food must be eaten (new food plan after that) 
            //-> we need to add the possibility to change all due Dates
            DateTime res = GetNextSunday();

            string typeForCarb1 = MyFoodWeek.thisweek.FoodCategoryTypeCarb1;
            string codeForCarb1 = MyFoodWeek.thisweek.FoodCategoryCodeCarb1;
            string descForCarb1 = MyFoodWeek.thisweek.FoodCategoryDescCarb1;
            FoodItem.InsertFoodItem(typeForCarb1, codeForCarb1, descForCarb1, res);
            col.Insert(FoodItem.getEntryfromTypeAndCode(typeForCarb1, codeForCarb1));

            string typeForCarb2 = MyFoodWeek.thisweek.FoodCategoryTypeCarb2;
            string codeForCarb2 = MyFoodWeek.thisweek.FoodCategoryCodeCarb2;
            string descForCarb2 = MyFoodWeek.thisweek.FoodCategoryDescCarb2;
            FoodItem.InsertFoodItem(typeForCarb2, codeForCarb2, descForCarb2, res);
            col.Insert(FoodItem.getEntryfromTypeAndCode(typeForCarb2, codeForCarb2));

            string typeForCarb3 = MyFoodWeek.thisweek.FoodCategoryTypeCarb3;
            string codeForCarb3 = MyFoodWeek.thisweek.FoodCategoryCodeCarb3;
            string descForCarb3 = MyFoodWeek.thisweek.FoodCategoryDescCarb2;
            FoodItem.InsertFoodItem(typeForCarb3, codeForCarb3, descForCarb3, res);
            col.Insert(FoodItem.getEntryfromTypeAndCode(typeForCarb3, codeForCarb3));

            string typeForProt1 = MyFoodWeek.thisweek.FoodCategoryTypeProt1;
            string codeForProt1 = MyFoodWeek.thisweek.FoodCategoryCodeProt1;
            string descForProt1 = MyFoodWeek.thisweek.FoodCategoryDescProt1;
            FoodItem.InsertFoodItem(typeForProt1, codeForProt1, descForProt1, res);
            col.Insert(FoodItem.getEntryfromTypeAndCode(typeForProt1, codeForProt1));

            string typeForProt2 = MyFoodWeek.thisweek.FoodCategoryTypeProt2;
            string codeForProt2 = MyFoodWeek.thisweek.FoodCategoryCodeProt2;
            string descForProt2 = MyFoodWeek.thisweek.FoodCategoryDescProt2;
            FoodItem.InsertFoodItem(typeForProt2, codeForProt2, descForProt2, res);
            col.Insert(FoodItem.getEntryfromTypeAndCode(typeForProt2, codeForProt2));

            string typeForProt3 = MyFoodWeek.thisweek.FoodCategoryTypeProt3;
            string codeForProt3 = MyFoodWeek.thisweek.FoodCategoryCodeProt3;
            string descForProt3 = MyFoodWeek.thisweek.FoodCategoryDescProt3;
            FoodItem.InsertFoodItem(typeForProt3, codeForProt3, descForProt3, res);
            col.Insert(FoodItem.getEntryfromTypeAndCode(typeForProt3, codeForProt3));

            string typeForVeggie1 = MyFoodWeek.thisweek.FoodCategoryTypeVeggies1;
            string codeForVeggie1 = MyFoodWeek.thisweek.FoodCategoryCodeVeggies1;
            string descForVeggie1 = MyFoodWeek.thisweek.FoodCategoryDescVeggies1;
            FoodItem.InsertFoodItem(typeForVeggie1, codeForVeggie1, descForVeggie1, res);
            col.Insert(FoodItem.getEntryfromTypeAndCode(typeForVeggie1, codeForVeggie1));

            string typeForVeggie2 = MyFoodWeek.thisweek.FoodCategoryTypeVeggies2;
            string codeForVeggie2 = MyFoodWeek.thisweek.FoodCategoryCodeVeggies2;
            string descForVeggie2 = MyFoodWeek.thisweek.FoodCategoryDescVeggies2;
            FoodItem.InsertFoodItem(typeForVeggie2, codeForVeggie2, descForVeggie2, res);
            col.Insert(FoodItem.getEntryfromTypeAndCode(typeForVeggie2, codeForVeggie2));

            string typeForVeggie3 = MyFoodWeek.thisweek.FoodCategoryTypeVeggies3;
            string codeForVeggie3 = MyFoodWeek.thisweek.FoodCategoryCodeVeggies3;
            string descForVeggie3 = MyFoodWeek.thisweek.FoodCategoryDescVeggies3;
            FoodItem.InsertFoodItem(typeForVeggie3, codeForVeggie3, descForVeggie3, res);
            col.Insert(FoodItem.getEntryfromTypeAndCode(typeForVeggie3, codeForVeggie3));


        }

        public static DateTime GetNextSunday()
        {
            DateTime res = DateTime.Now;
            if (res.DayOfWeek != DayOfWeek.Sunday)
            {

                if (res.DayOfWeek == DayOfWeek.Monday)
                {
                    res = res.AddDays(6);
                }
                if (res.DayOfWeek == DayOfWeek.Tuesday)
                {
                    res = res.AddDays(5);
                }
                if (res.DayOfWeek == DayOfWeek.Wednesday)
                {
                    res = res.AddDays(4);
                }
                if (res.DayOfWeek == DayOfWeek.Thursday)
                {
                    res = res.AddDays(3);
                }
                if (res.DayOfWeek == DayOfWeek.Friday)
                {
                    res = res.AddDays(2);
                }
                if (res.DayOfWeek == DayOfWeek.Saturday)
                {
                    res = res.AddDays(1);
                }
            }
            return res;
        }
        public static void RefreshFoodItems()
        {
            var col = Database.db.GetCollection<FoodItem>("FoodForShoppingList");
            col.DeleteAll();
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

            var col = Database.db.GetCollection<FoodItem>("FoodForShoppingList");
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
                            forCheck.IsVisible = false;
                        }
                    };

                };

                res.Add((forCheck, checkBox));


            }
            


            return res;

        }

    }

}

