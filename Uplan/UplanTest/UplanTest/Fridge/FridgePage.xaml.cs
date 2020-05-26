using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using LiteDB;
using Xamarin.Forms;
using System.Runtime;
using System.Runtime.InteropServices;
using Xamarin.Forms.Xaml;

namespace UplanTest
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FridgePage : ContentPage
    {
        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);

        Label Notif_Bas = new Label();
        Entry EntréeCodeBarre = new Entry();
        Label SortieApi = new Label();
        Button valider = new Button();
        DatePicker peremption = new DatePicker();
        Entry SiPasCodeBarre = new Entry();
        Entry Description = new Entry();
        Label addperemp = new Label();
        Grid grid = new Grid();

        public FridgePage()
        {


            ApiHelper.InitializeClient();




            ScrollView scrollView = new ScrollView { Orientation = ScrollOrientation.Vertical };
            scrollView.Content = grid;
            Content = scrollView;

            var col = Database.db.GetCollection<FrigoBaseDeDonnée>("FrigoBaseDeDonnée");
            int longu = col.Count();





            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(10) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(70) });

            for (int i = 1; i < longu + 12; i++)

            {

                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(40) });

            }



            for (int j = 1; j < 3; j++)

            {

                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            }

            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(10) });

            var TextFridge = new Label { Text = "My Fridge", FontSize = 30, FontAttributes = FontAttributes.Bold, TextColor = Color.White };




            TextFridge.HorizontalTextAlignment = TextAlignment.Center;


            var AddProduct = new Label { Text = "Add a product", TextColor = Color.White, HorizontalTextAlignment = TextAlignment.Center, FontAttributes = FontAttributes.Bold, FontSize = 30 };
            grid.Children.Add(AddProduct, 2, 0);



            addperemp.Text = "Peremption date:";
            addperemp.TextColor = Color.Black;
            addperemp.VerticalTextAlignment = TextAlignment.End;
            addperemp.HorizontalTextAlignment = TextAlignment.Center;

            EntréeCodeBarre.TextColor = Color.White;
            EntréeCodeBarre.BackgroundColor = Color.BlueViolet;
            EntréeCodeBarre.Placeholder = "Enter a barrcode";
            EntréeCodeBarre.HorizontalTextAlignment = TextAlignment.Center;

            valider.Clicked += new EventHandler(this.Sauvegarder_Clicked);
            valider.Text = "Save";
            valider.TextColor = Color.White;
            valider.BackgroundColor = Color.BlueViolet;
            valider.FontSize = 24;

            SiPasCodeBarre.Placeholder = "Description of the product (if it doesn't have a barcode)";
            SiPasCodeBarre.BackgroundColor = Color.BlueViolet;
            SiPasCodeBarre.TextColor = Color.White;
            SiPasCodeBarre.HorizontalTextAlignment = TextAlignment.Center;



            SortieApi.FontSize = 15;
            SortieApi.HorizontalTextAlignment = TextAlignment.Center;

            create();






            DateTime date = peremption.Date;



            grid.Children.Add(TextFridge, 1, 0);
            grid.Children.Add(EntréeCodeBarre, 2, 1);
            grid.Children.Add(SiPasCodeBarre, 2, 3);
            grid.Children.Add(addperemp, 2, 5);
            grid.Children.Add(peremption, 2, 6);
            grid.Children.Add(valider, 2, 8);
            grid.Children.Add(SortieApi, 2, 10);
            grid.Children.Add(Notif_Bas, 1, longu + 12);


            Grid.SetRowSpan(EntréeCodeBarre, 2);
            Grid.SetRowSpan(peremption, 2);
            Grid.SetRowSpan(valider, 2);
            Grid.SetColumnSpan(Notif_Bas, 2);
            Grid.SetRowSpan(SiPasCodeBarre, 2);


            ImageButton Close = new ImageButton();
            Close.Scale = 0.9;
            Close.Source = "Assets/croix.png";
            Close.Clicked += (sender, e) => OnCloseClicked2();
            grid.Children.Add(Close, 3, 0);




            grid.BackgroundColor = Color.White;

            create();

        }

        public void create()
        {

            var col = Database.db.GetCollection<FrigoBaseDeDonnée>("FrigoBaseDeDonnée");
            int longu = col.Count();
            int k = 1;
            var Fridge = new Frame { BorderColor = Color.FromHex("685C69") };

            grid.Children.Add(Fridge, 1, 1);
            if (longu == 0)
            {
                Grid.SetRowSpan(Fridge, 1);
            }
            else
            {
                Grid.SetRowSpan(Fridge, longu);
            }

            Notif_Bas.Text = "";
            foreach (var item in col.FindAll())
            {
                if (DateTime.Now.Date <= item.Peremption.Date)
                {
                    if (DateTime.Now.Date == item.Peremption.Date)
                    {
                        Notif_Bas.Text += $"IMPORTANT: the product {item.Name} is good until today! \n";
                    }
                    if (DateTime.Now.Date.AddDays(+2) == item.Peremption.Date)
                    {
                        Notif_Bas.Text += $"IMPORTANT: the product {item.Name} needs to be eaten before two days time!\n";
                    }



                    StackLayout stack = new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        Spacing = 0,


                    };


                    Button btn = new Button();
                    grid.Children.Add(stack, 1, k);
                    stack.Children.Add(btn);
                    btn.Text = item.Name;
                    btn.Clicked += new EventHandler(this.button_click);
                    btn.BackgroundColor = Color.BlueViolet;
                    btn.BorderColor = Color.FromHex("685C69");
                    btn.BorderWidth = 3;
                    btn.TextColor = Color.White;


                    ImageButton delete = new ImageButton
                    {
                        Source = "Assets/trash.png",
                        BorderColor = Color.White,
                        WidthRequest = 50,
                        Margin = new Thickness(0, 1, 2, 0),
                        CornerRadius = 5,

                    };
                    delete.ClassId = Convert.ToString(item.Id);

                    delete.Clicked += new EventHandler(this.Delete_Clicked);

                    stack.Children.Add(delete);

                    btn.HorizontalOptions = LayoutOptions.FillAndExpand;


                }

                else
                {
                    col.Delete(item.Id);
                }


                k++;
            }
        }

        private void Delete_Clicked(object sender, EventArgs e)
        {
            var col = Database.db.GetCollection<FrigoBaseDeDonnée>("FrigoBaseDeDonnée");
            ImageButton delete = sender as ImageButton;
            int id = Convert.ToInt32(delete.ClassId);
            col.Delete(id);
            Navigation.PushAsync(new FridgePage());
        }

        void button_click(System.Object sender, System.EventArgs e)
        {
            var col = Database.db.GetCollection<FrigoBaseDeDonnée>("FrigoBaseDeDonnée");
            Button btn = sender as Button;
            Navigation.PushAsync(new PageProduct(col.FindOne(Query.EQ("Name", btn.Text))));

            //var col = Database.db.GetCollection<FrigoBaseDeDonnée>("FrigoBaseDeDonnée");
            //var result = col.FindOne(Query.EQ("Name", btn.Text));
            //Navigation.PushAsync(new PageProduct(result));
        }
        async private void Sauvegarder_Clicked(System.Object sender, System.EventArgs e)
        {
            int Desc;
            if (!InternetGetConnectedState(out Desc, 0))
            {
                SortieApi.Text = "You are not connected to the Internet";
            }
            else
            {
                var col = Database.db.GetCollection<FrigoBaseDeDonnée>("FrigoBaseDeDonnée");
                if (EntréeCodeBarre.Text == null || EntréeCodeBarre.Text == "")
                {
                    if (SiPasCodeBarre.Text != null)
                    {
                        FrigoBaseDeDonnée.InsertProduct(null, SiPasCodeBarre.Text, -1, -1, -1, null, null, null, -1, null, peremption.Date, null, null);

                        create();
                    }
                }
                else
                {
                    var nutriInfo = await InfoResponseApi.LoadInfo((EntréeCodeBarre.Text));
                    if (nutriInfo == null)
                    {
                        SortieApi.Text = "Invalid Barcode";
                    }
                    else
                    {

                        if (nutriInfo.Ingredients_text != null)
                        {
                            FrigoBaseDeDonnée.InsertProduct(EntréeCodeBarre.Text, nutriInfo.Product_name_fr, nutriInfo.Nutriments.Sugars_100g, nutriInfo.Nutriments.Salt_100g, nutriInfo.Nutriments.Fat_100g, nutriInfo.Nutrient_levels.Salt, nutriInfo.Nutrient_levels.Sugars, nutriInfo.Nutrient_levels.Fat, nutriInfo.Nutriments.Proteins_100g, nutriInfo.Ingredients_text, peremption.Date, nutriInfo.Nutrition_grades, nutriInfo.Quantity);
                            SortieApi.Text = "The product has been added with succes to your pantry";

                            create();


                        }

                        else
                            SortieApi.Text = "Invalid Barcode";


                    }
                }
            }



        }



        private async void OnCloseClicked2()
        {

            await Navigation.PopAsync();

        }
    }
}
