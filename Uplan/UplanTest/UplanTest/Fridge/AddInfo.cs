using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

using Xamarin.Forms;

namespace UplanTest.Fridge
{
    public class AddInfo : ContentPage
    {
        FrigoBaseDeDonnée produit; 
        Grid grid = new Grid(); 
        Entry quantity1 = new Entry();
        Entry quantity2 = new Entry();
        Entry quantity3 = new Entry();
        Entry quantity4 = new Entry();
        Label reussi1 = new Label
        {
            FontSize = 15
        };
        Label reussi2 = new Label
        {
            FontSize = 15
        };
        Label reussi3 = new Label
        {
            FontSize = 15
        };
        Label reussi4 = new Label
        {
            FontSize = 15
        };
        Button Save1 = new Button
        {
            Text = "Save",
            BackgroundColor = Color.Black,
            TextColor = Color.White,
            ClassId = "Sugar" 


        };
        Button Save2 = new Button
        {
            Text = "Save",
            BackgroundColor = Color.Black,
            TextColor = Color.White,
            ClassId = "Salt"


        }; 
        Button Save3 = new Button
        {
            Text = "Save",
            BackgroundColor = Color.Black,
            TextColor = Color.White,
            ClassId = "MG"


        };
        Button Save4 = new Button
        {
            Text = "Save",
            BackgroundColor = Color.Black,
            TextColor = Color.White,
            ClassId = "Protein"


        };
        Button vert1 = new Button
        {
            BackgroundColor = Color.Green,
            HeightRequest = 35,
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,
            WidthRequest = 50


        };
        Button vert2 = new Button
        {
            BackgroundColor = Color.Green,
            HeightRequest = 35,
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,
            WidthRequest = 50


        };
        Button vert3 = new Button
        {
            BackgroundColor = Color.Green,
            HeightRequest = 35,
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,
            WidthRequest = 50


        };
        Button orange1 = new Button
        {
            BackgroundColor = Color.Orange,
            HeightRequest = 35,
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,
            WidthRequest = 50

        };
        Button orange2 = new Button
        {
            BackgroundColor = Color.Orange,
            HeightRequest = 35,
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,
            WidthRequest = 50

        };
        Button orange3 = new Button
        {
            BackgroundColor = Color.Orange,
            HeightRequest = 35,
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,
            WidthRequest = 50

        };
        Button rouge1 = new Button
        {
            BackgroundColor = Color.Red,
            HeightRequest = 35,
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,
            WidthRequest = 50

        };
        Button rouge2 = new Button
        {
            BackgroundColor = Color.Red,
            HeightRequest = 35,
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,
            WidthRequest = 50

        };
        Button rouge3 = new Button
        {
            BackgroundColor = Color.Red,
            HeightRequest = 35,
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,
            WidthRequest = 50

        };

        Button SaveAll = new Button
        {
            BackgroundColor = Color.Black,
            Text = "Save All", 
            TextColor = Color.White
        }; 


        public AddInfo(FrigoBaseDeDonnée prod)
        {
            produit = prod; 
            
            ScrollView scrollView = new ScrollView { Orientation = ScrollOrientation.Vertical };
            scrollView.Content = grid;
            Content = scrollView;
            for (int i =0; i< 18; i++)
            {
                if (i == 0|| i == 5 || i == 10 || i == 15)
                {
                    grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(45) });
                }
                else
                {
                    grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(30) });
                }      
                    
            }
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });


            add("Sugar", 0);
            quantity1.Placeholder = "Enter the quantity of Sugar of the product";
            grid.Children.Add(vert1, 0, 1);
            grid.Children.Add(orange1, 1, 1);
            grid.Children.Add(rouge1, 2, 1); 
            grid.Children.Add(quantity1, 1, 2);
            grid.Children.Add(reussi1, 1, 4);
            grid.Children.Add(Save1, 1, 3);

            add("Salt", 5);
            grid.Children.Add(vert2, 0, 6);
            grid.Children.Add(orange2, 1, 6);
            grid.Children.Add(rouge2, 2, 6); 
            grid.Children.Add(quantity2, 1, 7);
            grid.Children.Add(Save2, 1, 8);
            grid.Children.Add(reussi2, 1, 9); 
            quantity2.Placeholder = "Enter the quantity of Salt of the product";

            add("Fat", 10);
            grid.Children.Add(vert3, 0, 11);
            grid.Children.Add(orange3, 1, 11);
            grid.Children.Add(rouge3, 2, 11); 
            grid.Children.Add(quantity3, 1, 12);
            grid.Children.Add(Save3, 1, 13);
            grid.Children.Add(reussi3, 1, 14);
            grid.Children.Add(SaveAll, 1, 15); 
            quantity3.Placeholder = "Enter the quantity of Fat of the product";


            Save1.Clicked += Save1_Clicked;
            Save2.Clicked += Save2_Clicked;
            Save3.Clicked += Save3_Clicked;
            Save4.Clicked += Save4_Clicked;

            vert1.Clicked += Vert1_Clicked;
            vert2.Clicked += Vert2_Clicked;
            vert3.Clicked += Vert3_Clicked;

            orange1.Clicked += Orange1_Clicked;
            orange2.Clicked += Orange2_Clicked;
            orange3.Clicked += Orange3_Clicked;

            rouge1.Clicked += Rouge1_Clicked;
            rouge2.Clicked += Rouge2_Clicked;
            rouge3.Clicked += Rouge3_Clicked;

            SaveAll.Clicked += SaveAll_Clicked;

        }

        private void SaveAll_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FridgePage()); 
        }

        private void Orange3_Clicked(object sender, EventArgs e)
        {
            var col = Database.db.GetCollection<FrigoBaseDeDonnée>("FrigoBaseDeDonnée");
            produit.GommetesMG = "moderate"; 
            col.Update(produit); 
        }

        private void Orange2_Clicked(object sender, EventArgs e)
        {
            var col = Database.db.GetCollection<FrigoBaseDeDonnée>("FrigoBaseDeDonnée");
            produit.GommetesSel = "moderate";
            col.Update(produit);
        }

        private void Orange1_Clicked(object sender, EventArgs e)
        {
            var col = Database.db.GetCollection<FrigoBaseDeDonnée>("FrigoBaseDeDonnée");
            produit.GommetesSucre = "moderate";
            col.Update(produit);
        }

        private void Rouge3_Clicked(object sender, EventArgs e)
        {
            var col = Database.db.GetCollection<FrigoBaseDeDonnée>("FrigoBaseDeDonnée");
            produit.GommetesMG = "high";
            col.Update(produit);

        }

        private void Rouge2_Clicked(object sender, EventArgs e)
        {
            var col = Database.db.GetCollection<FrigoBaseDeDonnée>("FrigoBaseDeDonnée");
            produit.GommetesSel = "high";
            col.Update(produit);
        }

        private void Rouge1_Clicked(object sender, EventArgs e)
        {
            var col = Database.db.GetCollection<FrigoBaseDeDonnée>("FrigoBaseDeDonnée");
            produit.GommetesSucre = "high";
            col.Update(produit);
        }

        private void Vert3_Clicked(object sender, EventArgs e)
        {
            var col = Database.db.GetCollection<FrigoBaseDeDonnée>("FrigoBaseDeDonnée");
            produit.GommetesMG = "low";
            col.Update(produit);
        }

        private void Vert2_Clicked(object sender, EventArgs e)
        {
            var col = Database.db.GetCollection<FrigoBaseDeDonnée>("FrigoBaseDeDonnée");
            produit.GommetesSel = "low";
            col.Update(produit);
        }

        private void Vert1_Clicked(object sender, EventArgs e)
        {
            var col = Database.db.GetCollection<FrigoBaseDeDonnée>("FrigoBaseDeDonnée");
            produit.GommetesSucre = "low";
            col.Update(produit);
        }

        private void Save4_Clicked(object sender, EventArgs e)
        {
            var col = Database.db.GetCollection<FrigoBaseDeDonnée>("FrigoBaseDeDonnée");
            try
            {
                float j;
                float.TryParse(quantity1.Text, out j);
                produit.Proteine = j;
                col.Update(produit);
                reussi1.Text = "Les modifications ont bien été aportées";

            }
            catch (Exception)
            {
                reussi1.Text = "Les modifications ont échouées";
            }

         
        }

        private void Save3_Clicked(object sender, EventArgs e)
        {
            var col = Database.db.GetCollection<FrigoBaseDeDonnée>("FrigoBaseDeDonnée");
            try
            {
                float j;
                float.TryParse(quantity3.Text, out j);
                produit.Matiere_grasse = j;
                col.Update(produit);
                reussi3.Text = "Les modifications ont bien été aportées";

            }
            catch (Exception)
            {
                reussi3.Text = "Les modifications ont échouées";
            }
         
        }

        private void Save2_Clicked(object sender, EventArgs e)
        {
            var col = Database.db.GetCollection<FrigoBaseDeDonnée>("FrigoBaseDeDonnée");
            try
            {
                float j;
                float.TryParse(quantity2.Text, out j);
                produit.Sel = j;
                col.Update(produit);
                reussi2.Text = "Les modifications ont bien été aportées";

            }
            catch (Exception)
            {
                reussi2.Text = "Les modifications ont échouées";
            }
            
        }

        private void Save1_Clicked(object sender, EventArgs e)
        {
            var col = Database.db.GetCollection<FrigoBaseDeDonnée>("FrigoBaseDeDonnée");
            try
            {
                float j;
                float.TryParse(quantity1.Text, out j);
                produit.Sucre = j;
                col.Update(produit);
                reussi1.Text = "Les modifications ont bien été aportées";

            }
            catch (Exception)
            {
                reussi1.Text = "Les modifications ont échouées";
            }
           
        }

        public void add (string type, int numeroligne)
        {
            Label choix = new Label
            {
                Text = $"Choose the quantity of {type}",
                FontAttributes = FontAttributes.Bold,
                FontSize = 20,
                HorizontalTextAlignment = TextAlignment.Center


            }; 
            
            grid.Children.Add(choix, 1, numeroligne);


        }


        
    }
}