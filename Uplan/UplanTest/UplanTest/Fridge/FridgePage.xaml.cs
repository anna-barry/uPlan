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
        Entry EntréeCodeBarre = new Entry();
        Label SortieApi = new Label();
        Button valider = new Button();
        DatePicker peremption = new DatePicker();
        public FridgePage()
        {

            ApiHelper.InitializeClient();
            


            var grid = new Grid();
            ScrollView scrollView = new ScrollView { Orientation = ScrollOrientation.Vertical };
            scrollView.Content = grid;
            Content = scrollView;

            var col = Database.db.GetCollection<FrigoBaseDeDonnée>("FrigoBaseDeDonnée");
            int longu = col.Count();





            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(10) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(70) });

            for (int i = 1; i < longu + 8; i++)

            {

                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(40) });

            }



            for (int j = 1; j < 4; j++)

            {

                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            }


            var TextFridge = new Label { Text = "My Fridge", FontSize = 30, FontAttributes = FontAttributes.Bold, TextColor = Color.BlueViolet };



            grid.Children.Add(TextFridge, 1, 0);
            TextFridge.HorizontalTextAlignment = TextAlignment.Center;
            var Fridge = new Frame { BorderColor = Color.Black };
            grid.Children.Add(Fridge, 1, 1);

            Grid.SetRowSpan(Fridge, longu + 3);

            var AddProduct = new Label { Text = "Add a product", TextColor = Color.Black, HorizontalTextAlignment = TextAlignment.Center };
            grid.Children.Add(AddProduct, 2, 0);










            valider.Clicked += new EventHandler(this.Sauvegarder_Clicked);
            valider.Text = "Save";





            int k = 1;
            foreach (var item in col.FindAll())
            {
                if (DateTime.Now <= item.Peremption)
                {
                    Button btn = new Button();
                    grid.Children.Add(btn, 1, k);
                    btn.Text = item.Name;
                    btn.Clicked += new EventHandler(this.button_click);
                }
                else
                {
                    col.Delete(item.Id);
                }


                k++;
            }

            Label addperemp = new Label();
            addperemp.Text = "Peremption date:";
            addperemp.TextColor = Color.MediumVioletRed;

            addperemp.VerticalTextAlignment = TextAlignment.End;




            DateTime date = peremption.Date;
            grid.Children.Add(peremption, 6, 10);
            Grid.SetColumnSpan(peremption, 3);




            grid.Children.Add(EntréeCodeBarre, 2, 1);
            grid.Children.Add(addperemp, 2, 3);
            grid.Children.Add(peremption, 2, 4);
            grid.Children.Add(valider, 2, 6);

            grid.Children.Add(SortieApi, 2, 8);

            Grid.SetRowSpan(EntréeCodeBarre, 2);
            Grid.SetRowSpan(peremption, 2);
            Grid.SetRowSpan(valider, 2);








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
                SortieApi.TextColor = Color.Red;
                SortieApi.BackgroundColor = Color.White;
            }
            else
            {
                if (nutriInfo.Ingredients_text != null)
                {
                    FrigoBaseDeDonnée.InsertProduct(EntréeCodeBarre.Text, nutriInfo.Product_name_fr, nutriInfo.Nutriments.Sugars_100g, nutriInfo.Nutriments.Salt_100g, nutriInfo.Nutriments.Fat_100g, nutriInfo.Nutrient_levels.Salt, nutriInfo.Nutrient_levels.Sugars, nutriInfo.Nutrient_levels.Fat, nutriInfo.Nutriments.Proteins_100g, nutriInfo.Ingredients_text, peremption.Date);
                    SortieApi.Text = "The pruduct has been aded with succes in your pantry";
                }

                else
                    SortieApi.Text = "Erreur dans le code barre";



                Navigation.PushAsync(new FridgePage());

            }

        }
    }
}
