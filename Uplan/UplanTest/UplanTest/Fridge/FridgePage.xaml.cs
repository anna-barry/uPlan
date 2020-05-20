using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;
using Xamarin.Forms;

using Xamarin.Forms.Xaml;

namespace UplanTest
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FridgePage : ContentPage
    {
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
            var Fridge = new Frame { BorderColor = Color.White };
            grid.Children.Add(Fridge, 1, 1);

            Grid.SetRowSpan(Fridge, longu + 3);

            var AddProduct = new Label { Text = "Add a product", TextColor = Color.White,  HorizontalTextAlignment = TextAlignment.Center,FontAttributes =  FontAttributes.Bold, FontSize = 30};
            grid.Children.Add(AddProduct, 2, 0);


           
            addperemp.Text = "Peremption date:";
            addperemp.TextColor = Color.White;
            addperemp.VerticalTextAlignment = TextAlignment.End;
            addperemp.HorizontalTextAlignment = TextAlignment.Center; 

            EntréeCodeBarre.TextColor = Color.White; 
            EntréeCodeBarre.BackgroundColor = Color.FromHex("685C69");
            EntréeCodeBarre.Placeholder = "Enter a barrcode";
            EntréeCodeBarre.HorizontalTextAlignment = TextAlignment.Center; 

            valider.Clicked += new EventHandler(this.Sauvegarder_Clicked);
            valider.Text = "Save";
            valider.TextColor = Color.White;
            valider.BackgroundColor = Color.FromHex("685C69");
            valider.FontSize = 24;

            SiPasCodeBarre.Placeholder = "Description of the product (if it doesn't have a barcode)";
            SiPasCodeBarre.BackgroundColor = Color.FromHex("685C69");
            SiPasCodeBarre.TextColor = Color.White;
            SiPasCodeBarre.HorizontalTextAlignment = TextAlignment.Center;

            Notif_Bas.TextColor = Color.White;

            SortieApi.TextColor = Color.White;
            SortieApi.FontSize = 15;
            SortieApi.HorizontalTextAlignment = TextAlignment.Center; 

            int k = 1;
            foreach (var item in col.FindAll())
            {
                if(DateTime.Now.Date <= item.Peremption.Date)
                {
                    if(DateTime.Now.Date == item.Peremption.Date)
                    {
                        Notif_Bas.Text += $"Attention le produit {item.Name} se périme aujourd'hui \n";
                    }
                    if(DateTime.Now.Date.AddDays(+2) == item.Peremption.Date)
                    {
                        Notif_Bas.Text += $"Attention le produit {item.Name} se périme dans deux jours \n";
                    }
                  
                  
                    Button btn = new Button();
                    grid.Children.Add(btn, 1, k);
                    btn.Text = item.Name;
                    btn.Clicked += new EventHandler(this.button_click);
                    btn.BackgroundColor = Color.FromHex("685C69");
                    btn.BorderColor = Color.White;
                    btn.TextColor = Color.White; 
                    
                }
                
                else
                {
                    col.Delete(item.Id);
                }


                k++;
            }

            




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
            Close.Source = "Assets/croix.png";
            Close.Clicked += (sender, e) => OnCloseClicked2();
            grid.Children.Add(Close, 0, 2);

            


            grid.BackgroundColor = Color.FromHex("180719");

            

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

            var nutriInfo = await InfoResponseApi.LoadInfo((EntréeCodeBarre.Text));
            if (nutriInfo == null)
            {
                SortieApi.Text = "Barcode Invalid";
            }
            else
            {
                var col = Database.db.GetCollection<FrigoBaseDeDonnée>("FrigoBaseDeDonnée");
                if (nutriInfo.Ingredients_text != null)
                {
                    FrigoBaseDeDonnée.InsertProduct(EntréeCodeBarre.Text, nutriInfo.Product_name_fr, nutriInfo.Nutriments.Sugars_100g, nutriInfo.Nutriments.Salt_100g, nutriInfo.Nutriments.Fat_100g ,nutriInfo.Nutrient_levels.Salt, nutriInfo.Nutrient_levels.Sugars, nutriInfo.Nutrient_levels.Fat, nutriInfo.Nutriments.Proteins_100g, nutriInfo.Ingredients_text,peremption.Date);
                    SortieApi.Text = "The pruduct has been aded with succes in your pantry";
                    int k = 1;
                    foreach (var item in col.FindAll())
                    {
                        if (DateTime.Now.Date <= item.Peremption.Date)
                        {
                            if (DateTime.Now.Date == item.Peremption.Date)
                            {
                                Notif_Bas.Text += $"Attention le produit {item.Name} se périme aujourd'hui \n";
                            }
                            if (DateTime.Now.Date.AddDays(+2) == item.Peremption.Date)
                            {
                                Notif_Bas.Text += $"Attention le produit {item.Name} se périme dans deux jours \n";
                            }


                            Button btn = new Button();
                            grid.Children.Add(btn, 1, k);
                            btn.Text = item.Name;
                            btn.Clicked += new EventHandler(this.button_click);
                            btn.BackgroundColor = Color.FromHex("685C69");
                            btn.BorderColor = Color.White;
                            btn.TextColor = Color.White;

                        }

                        else
                        {
                            col.Delete(item.Id);
                        }


                        k++;
                    }


                }

                else
                    SortieApi.Text = "Barcode Invalid";
                

            }
           

        }

        private async void OnCloseClicked2()
        {

            await Navigation.PopAsync();

        }
    }
}
