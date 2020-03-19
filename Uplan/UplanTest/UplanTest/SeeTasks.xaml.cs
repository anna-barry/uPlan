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
            string res = "Tasks:" + "\n" ;
            editorr.Text = res;

        }

        private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            // DateTime date;
            // DateTime? selectedDate = dp.SelectedDate;
            DateTime? selectedDate1 = dpp.Date;
            if (selectedDate1.HasValue)
            {
                var col = Database.db.GetCollection<SchoolTask>("SchoolTasks");
                //Database.Initiate();
                string res = "These are the tasks for the day you selected";
                var tasksonday = col.Find(Query.EQ("DueDate", selectedDate1));
                int i = 1;
                foreach(var task in tasksonday)
                {

                    res = res + "Task n°" + i + "\n" + "-";
                    res +=(string) task.Description;
                    res += "\n";
                    res += (string)task.SubDesc;

                    i += 1;
                }
                editorr.Text = res;

            }

        }
    }
}