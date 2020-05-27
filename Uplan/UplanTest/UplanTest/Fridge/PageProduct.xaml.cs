using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using UplanTest.Fridge;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UplanTest
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageProduct : ContentPage
    {
        FrigoBaseDeDonnée prod = new FrigoBaseDeDonnée(); 
        Grid grid = new Grid();
        StackLayout baspage = new StackLayout();
        Label Titre = new Label(); 
        Entry ajoutdescription = new Entry
        {
            Placeholder = "Insert the ingredients of the product",
            HorizontalTextAlignment = TextAlignment.Center,
            WidthRequest = 120

        };
        Label espace = new Label
        {
            HeightRequest = 100
        };
        Label quantity = new Label
        {
            HorizontalTextAlignment = TextAlignment.Center,
            FontSize = 25,
            VerticalTextAlignment = TextAlignment.Center,
            
        };
        Label ingredient = new Label
        {
            
            HorizontalTextAlignment = TextAlignment.Center
        };
        public PageProduct(FrigoBaseDeDonnée produit)
        { 
            Content = grid;
            prod = produit; 
            

           
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(2, GridUnitType.Star) });

            //grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
           
            grid.BackgroundColor = Color.White;


            StackLayout stackTop = new StackLayout();
            stackTop.HorizontalOptions = LayoutOptions.Center;

            Titre.Text = produit.Name;
            Titre.HorizontalTextAlignment = TextAlignment.Center;
            Titre.FontSize = 25;


            // Grid.SetColumnSpan(stackTop, 2); 
            ImageButton Close = new ImageButton();
            Close.Source = "Assets/croix.png";
            Close.HeightRequest = 50;
            Close.Scale = 0.5;
            Close.VerticalOptions = LayoutOptions.Start;
            Close.Clicked += (sender, e) => {
                Navigation.PopAsync();
            };
            stackTop.Children.Add(Close);

            stackTop.Children.Add(Titre);
            grid.Children.Add(stackTop, 0, 0);
            ImageButton nutriscore = new ImageButton();
            nutriscore.WidthRequest = 140;
            stackTop.Children.Add(nutriscore); 
            
            switch (produit.Nutriscore)
            {
                case "a":
                    nutriscore.Source = "Assets/A.png";
                    break;
                case "b":
                    nutriscore.Source = "Assets/B.png";
                    break;
                case "c":
                    nutriscore.Source = "Assets/C.png";
                    break;
                case "d":
                    nutriscore.Source = "Assets/D.png";
                    break; 
                case "e": 
                    nutriscore.Source = "Assets/E.png";
                    break;
                default:
                    Label isnot = new Label
                    {
                        Text = "The nutriscore is not set for this product"
                    };
                    stackTop.Children.Add(isnot); 
                    break; 

            }
            quantity.Text = produit.Quantity; 
            stackTop.Children.Add(quantity); 

            
            Label espace2 = new Label
            {
                HeightRequest = 70
            };


            grid.Children.Add(baspage, 0, 1);
            Label pour100g = new Label
            {
                Text = "Repères nutritionnels pour 100 g/100 mL",
                FontAttributes = FontAttributes.Bold,
                FontSize = 30,
                HorizontalTextAlignment = TextAlignment.Center
            };
            baspage.Children.Add(pour100g);



            baspage.Children.Add(espace2); 


            comparatif(produit.GommetesSucre, produit.Sucre, "Sugar");
            comparatif(produit.GommetesSel, produit.Sel, "Salt");
            comparatif(produit.GommetesMG, produit.Matiere_grasse, "Fat");
            comparatif("", produit.Proteine, "Protein");
            ingredient.Text = "Ingrédients: " + prod.Ingrédients; 
            
            baspage.Children.Add(espace);

            if (produit.Ingrédients == null || produit.Ingrédients == "")
            {

                ImageButton save = new ImageButton
                {
                    Source = "Assets/save.png",
                    HeightRequest = 40,
                    HorizontalOptions = LayoutOptions.Center,
                    ClassId = produit.Name
                    
                };
                save.Clicked += Save_Clicked;
                baspage.Children.Add(ajoutdescription);
                baspage.Children.Add(save); 
            }
            else
            {
                
                baspage.Children.Add(ingredient);
            }
            

        }

        public void refresh()
        {
            Titre.Text = prod.Name;
            quantity.Text = prod.Quantity;
            ingredient.Text = prod.Ingrédients; 
           

        }

        private void Save_Clicked(object sender, EventArgs e)
        {

            var col = Database.db.GetCollection<FrigoBaseDeDonnée>("FrigoBaseDeDonnée");
            prod.Ingrédients= ajoutdescription.Text;
            col.Update(prod);
            Navigation.PushAsync(new FridgePage());  
                     
        }

        public void comparatif (string productgommette, float productquantite, string type)
        {
            StackLayout stack = new StackLayout
            {
                Orientation = StackOrientation.Horizontal
            };
            baspage.Children.Add(stack); 
            ImageButton image = new ImageButton
            {
                WidthRequest = 37
            };
            Label label = new Label
            {
                HorizontalTextAlignment = TextAlignment.Center,
                FontSize = 25, 
                VerticalTextAlignment = TextAlignment.Center
            };
            stack.Children.Add(image);
            stack.Children.Add(label);
            if (productquantite == -1)
            {

                ImageButton plus = new ImageButton
                {
                    Source = "Assets/plus.png",
                    WidthRequest = 37
                };
                plus.Clicked += Plus_Clicked;
                stack.Children.Add(plus);

                image.Source = "Assets/interrogation.png";
                label.Text = "The quantity of " + type + " is not set for this product ";
            }
            else
            {
                label.Text = productquantite + "g: " + type;
                switch (productgommette)
                {
                    case "low":
                        image.Source = "Assets/RondVert.png";
                        label.Text += " in few quantity";
                        break;
                    case "moderate":
                        image.Source = "Assets/Rond_orange.png";
                        label.Text += " In moderate quantity";
                        break;
                    case "high":
                        image.Source = "Assets/RoundRouge.png";
                        label.Text += " In heigh quantity";
                        break;
                    default:

                        break;

                }
            }
            stack.HorizontalOptions = LayoutOptions.FillAndExpand; 

            


            
        }

        private void Plus_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddInfo (prod)); 
        }
    }
}