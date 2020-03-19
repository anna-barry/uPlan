﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace UplanTest
{
    
    public partial class MainPage: MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
          

            //Database.Initiate();
        }

        private void Button_Clicked1(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new CALENDRIER());
            
        }
        private void Button_Clicked2(object sender, EventArgs e)
        {
            
            Detail = new NavigationPage(new AddEvent());
            
        }

        private void Button_Clicked3(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new SeeTasks());
           
        }
        private void Button_Clicked4(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new FoodPlan());
            
        }
        private void Button_Clicked5(object sender,EventArgs e)
        {
            Detail = new NavigationPage(new FoodW());
            
        }
        private void Button_Clicked6(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new ShoppingList());
            
        }
        private void Button_Clicked7(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new WellBeing());
            
        }
        private void Button_Clicked8(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new AboutMe());
            
        }
        private void Button_Clicked9(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new AboutUs());
            
        }

    }
}
