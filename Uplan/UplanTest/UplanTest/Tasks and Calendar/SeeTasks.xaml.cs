using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UplanTest
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SeeTasks : ContentPage
    {
        public SeeTasks()
        {
            InitializeComponent();
            string res = "These are the tasks for today you selected (" + DateTime.Today.Date.ToString("dd/MM/yyyy") + "):" + "\n" + "\n";
            //saytheday.Text= "These are the tasks for today you selected (" + DateTime.Today.Date.ToString("dd/MM/yyyy") + "):";
            editorr.Text = res;
            
            //saytheday.FontAttributes = FontAttributes.Bold;
            //saytheday.TextColor = Color.MediumVioletRed;
            var col = Database.db.GetCollection<SchoolTask>("SchoolTasks");
            //Database.Initiate();
           
           
            var tasksonday = col.Find(Query.EQ("DueDate", DateTime.Today));
            int i = 1;
            

            foreach (var task in tasksonday)
            {
                
                res = res + "Task n°" + i + '\n' + "-" ;
                res += (string)task.Description;
                res += '\n';
                res = res+ (string)task.SubDesc +'\n';
                res += '\n';
                
                i += 1;
            }
            editorr.Text = res;
            editorr.TextColor = Color.RoyalBlue;

            /* thistackLayout.Children.Add(editorr);
             thisscroll.Content = thistackLayout;
             Content = thisscroll;*/

            /*var scroll = new ScrollView();
            Content = scroll;
            var stack = new StackLayout();
            stack.Children.Add(new BoxView { BackgroundColor = Color.Red, HeightRequest = 600, WidthRequest = 600 });
            stack.Children.Add(new Entry());*/

        }

        private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
           
            DateTime date;
            // DateTime? selectedDate = dp.SelectedDate;
            DateTime? selectedDate1 = dpp.Date;
            if (selectedDate1.HasValue)
            {
                 var col = Database.db.GetCollection<SchoolTask>("SchoolTasks");
                //Database.Initiate();
                date = dpp.Date;
                string lildate = date.ToString("dd/MM/yyyy");
                string res = "These are the tasks for the day you selected ("+ lildate + "): " + "\n" + "\n";
                var tasksonday = col.Find(Query.EQ("DueDate", selectedDate1));
                int i = 1;
                foreach(var task in tasksonday)
                {
                    res = res + "\n" + "Task n°" + i + "\n" + "-";
                    res +=(string) task.Description;
                    res += '\n';
                    res += (string)task.SubDesc + '\n';

                    i += 1;
                }
                editorr.Text = res;
                

            }

        }

        private async void OnCloseClicked2(object sender, EventArgs args)
        {

            await Navigation.PopAsync();

        }
    }
}