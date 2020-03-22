using System;

using Xamarin.Forms;

using Xamarin.Forms.Xaml;

using System.Linq;

using System.Text;

using System.Threading.Tasks;

using LiteDB;
//using System.Drawing;



namespace UplanTest

{

    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class AddEvent : ContentPage

    {



        ListHelper eventype;

        ListHelper eventsoutype;

        ListHelper coloursforevent;

        ListHelper timeconsuminglevel;

        Boolean pers=false;
        Boolean school=false;

        public DateTime? FavoriteDay { get; set; }

        public AddEvent()



        {

            InitializeComponent();



            /*eventype = new ListHelper("TASK_CATEGORIES", -1, "");

            // pListType, int pCurrentId, string pCurrentCode

            Task_type.ItemsSource = eventype.DisplayList;

            Task_type.SelectedIndex = eventype.CurrentIndex;

            string sl = Convert.ToString(Task_type.SelectedItem);

            
            Task_type.SelectedIndexChanged += (sender, args) =>
            {   
                Task_subtype.ItemsSource = null;
                string test = Convert.ToString(Task_type.SelectedItem);
                OnPropertyChanged();

                if (test== "Personal")

                {

                    eventsoutype = new ListHelper("TASK_SUBTYPE_PERS", -1, "");

                    Task_subtype.ItemsSource = eventsoutype.DisplayList;

                    Task_subtype.SelectedIndex = eventsoutype.CurrentIndex; 

                }

                else

                {

                    eventsoutype = new ListHelper("TASK_SUBTYPE_SC", -1, "");

                    Task_subtype.ItemsSource = eventsoutype.DisplayList;

                    Task_subtype.SelectedIndex = eventsoutype.CurrentIndex; 

                }

            };

            if (sl == "Personal")

            {

                eventsoutype = new ListHelper("TASK_SUBTYPE_PERS", -1, "");

                Task_subtype.ItemsSource = eventsoutype.DisplayList;

                Task_subtype.SelectedIndex = eventsoutype.CurrentIndex;

            }

            else

            {

                eventsoutype = new ListHelper("TASK_SUBTYPE_SC", -1, "");

                Task_subtype.ItemsSource = eventsoutype.DisplayList;

                Task_subtype.SelectedIndex = eventsoutype.CurrentIndex;

            }
            


            if(school)
            {

                eventsoutype = new ListHelper("TASK_SUBTYPE_SC", -1, "");

                Task_subtype.ItemsSource = eventsoutype.DisplayList;

                Task_subtype.SelectedIndex = eventsoutype.CurrentIndex;

            }
            else
            {

                eventsoutype = new ListHelper("TASK_SUBTYPE_PERS", -1, "");

                Task_subtype.ItemsSource = eventsoutype.DisplayList;

                Task_subtype.SelectedIndex = eventsoutype.CurrentIndex;

            } */


            coloursforevent = new ListHelper("COLOURS", -1, "");

            // pListType, int pCurrentId, string pCurrentCode

            //Task_colour.ItemsSource = coloursforevent.CodeList;
            Task_colour.ItemsSource = coloursforevent.DisplayList;

            Task_colour.SelectedIndex = coloursforevent.CurrentIndex;
            string colorName2 = Task_colour.Items[Task_colour.SelectedIndex];
            //Task_colour.TextColor(getColor(colorName2));
            
           // Task_colour.BackgroundColor = Color.FromHex(coloursforevent.CurrentDesc);

            Task_colour.SelectedIndexChanged += (sender, args) =>
            {
                if (Task_colour.SelectedIndex == -1)
                {
                    Task_colour.BackgroundColor = Color.Default;
                }
                else
                {

                    string colorName = Task_colour.Items[Task_colour.SelectedIndex];
                    /* string colorName = Task_colour.SelectedIndex;
                     //boxView.Color = nameToColor[colorName];
                     Task_colour.BackgroundColor = Color.FromHex(colorName);
                     //ColorTranslator 

                     //Task_colour.BackgroundColor = ColorTranslator.FromHtml(Task_colour.Items[Task_colour.SelectedIndex]);
                     var converter = new ColorTypeConverter();
                     var test = converter.ConvertFromInvariantString(colorName);
                     Task_colour.BackgroundColor = (Color) test;

                     //Task_colour.BackgroundColor = (Color)(Task_colour.Items[Task_colour.SelectedIndex]); */
                    Task_colour.BackgroundColor = getColor(colorName);

                }
            };



            timeconsuminglevel = new ListHelper("TASK_COMPLEXITIES", -1, "");

            Task_consuming.ItemsSource = timeconsuminglevel.DisplayList;

            Task_consuming.SelectedIndex = timeconsuminglevel.CurrentIndex;


        }

        async void OnButtonClicked(object sender, EventArgs args)

        {

            var TaskCategory = ListEntry.getEntryfromTypeAndCode("TASK_CATEGORIES", "PERSONAL");
            if(school)
            {
                TaskCategory = ListEntry.getEntryfromTypeAndCode("TASK_CATEGORIES", "SCHOOL");
            }
            //eventype.ListEntryList[Task_type.SelectedIndex]
            SchoolTask.InsertSchoolTask(MyUser.me, TaskCategory,

                coloursforevent.ListEntryList[Task_colour.SelectedIndex], timeconsuminglevel.ListEntryList[Task_consuming.SelectedIndex],

                eventsoutype.ListEntryList[Task_subtype.SelectedIndex], Desc.Text, SubDesc.Text, false, test);



        }


        async void OnPersonClicked(object sender, EventArgs args)

        {
            pers = true;
            school = false;
            Pers.Text = "Adding personal Task or Event";
            Sch.Text = "For School";
            eventsoutype = new ListHelper("TASK_SUBTYPE_PERS", -1, "");

            Task_subtype.ItemsSource = eventsoutype.DisplayList;

            Task_subtype.SelectedIndex = eventsoutype.CurrentIndex;


        }
        async void OnWordClicked(object sender, EventArgs args)

        {
            pers = false;
            school = true;
            Sch.Text = "Adding a work task";
            Pers.Text = "Personal";
            eventsoutype = new ListHelper("TASK_SUBTYPE_SC", -1, "");

            Task_subtype.ItemsSource = eventsoutype.DisplayList;

            Task_subtype.SelectedIndex = eventsoutype.CurrentIndex;

        }


        private DateTime test = DateTime.Now;

        private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)

        {

            DateTime? selectedDate1 = dp.Date;

            if (selectedDate1.HasValue)

            {



                test = (DateTime)selectedDate1;



            }



        }

        public static Color getColor(string col)
        {
            Color res = Color.White;
            switch (col)
            {
                case "Blue":
                    res = Color.Beige;
                    break;
                case "Green":
                    res = Color.Green;
                    break;
                case "Red":
                    res = Color.Red;
                    break;
                case "Purple":
                    res = Color.Purple;
                    break;
                case "Beige":
                    res = Color.Purple;
                    break;
                case "Blue Violet":
                    res = Color.BlueViolet;
                    break;
                case "Brown":
                    res = Color.Brown;
                    break;
                case "Coral":
                    res = Color.Beige;
                    break;
                case "Dark blue":
                    res = Color.DarkBlue;
                    break;
                case "Dark Magenta":
                    res = Color.DarkMagenta;
                    break;
                case "Forest Green":
                    res = Color.ForestGreen;
                    break;
                case "Fuchsia":
                    res = Color.Fuchsia;
                    break;
                case "Gold":
                    res = Color.Gold;
                    break;
                case "Gray":
                    res = Color.Gray;
                    break;

            }


            return res;
        }







    }

}