using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using LiteDB;

namespace UplanTest
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [DesignTimeVisible(false)]
    public partial class AccountPage : ContentPage
    {
        ListHelper lh_accom_type;
        ListHelper lh_shop_day;
        ListHelper lh_clean_day;
        ListHelper rest_day;

        public AccountPage()
        {
            InitializeComponent();
           
            editor.Text = User.GetLoginMessage();
            User_Name.Text = MyUser.me.Name;
            Email.Text = MyUser.me.EmailAddress;

            lh_accom_type = new ListHelper("ACCOMODATION_TYPES", MyUser.me.AccomodationType.Id, "");
            Accomodation_type.ItemsSource = lh_accom_type.DisplayList;
            Accomodation_type.SelectedIndex = lh_accom_type.CurrentIndex;

            lh_shop_day = new ListHelper("DAYS", 0, MyUser.me.ShoppingDay);
            Shopping_Day.ItemsSource = lh_shop_day.DisplayList;
            Shopping_Day.SelectedIndex = lh_shop_day.CurrentIndex;

            lh_clean_day = new ListHelper("DAYS", 0, MyUser.me.CleaningDay);
            Cleaning_Day.ItemsSource = lh_clean_day.DisplayList;
            Cleaning_Day.SelectedIndex = lh_clean_day.CurrentIndex;

            rest_day= new ListHelper("DAYS", 0, MyUser.me.RestDay);
            Rest_Day.ItemsSource = rest_day.DisplayList;
            Rest_Day.SelectedIndex= rest_day.CurrentIndex;
           
        }

        async void OnButtonClicked(object sender, EventArgs args)
        {
            MyUser.Update(User_Name.Text, Email.Text,
                lh_accom_type.ListEntryList[Accomodation_type.SelectedIndex],
                lh_shop_day.CodeList[Shopping_Day.SelectedIndex],
                lh_clean_day.CodeList[Cleaning_Day.SelectedIndex],
                rest_day.CodeList[Rest_Day.SelectedIndex]
                );

            editor.Text = User.GetLoginMessage();


           await Navigation.PushAsync(new MainPage());
        }
       }
    }
