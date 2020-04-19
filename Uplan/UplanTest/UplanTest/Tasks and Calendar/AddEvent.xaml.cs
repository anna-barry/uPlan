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

        ListHelper coloursforevent;

        ListHelper timeconsuminglevel;
        //TaskSubType = ListEntry.getEntryfromTypeAndCode("TASK_SUBTYPE_SC", "BY_HEART");

        Boolean pers=false;
        Boolean school=false;
        public string subtype= "BY_HEART";

        public DateTime? FavoriteDay { get; set; }

        public AddEvent()



        {

            InitializeComponent();

            coloursforevent = new ListHelper("COLOURS", -1, "");
            Task_colour.ItemsSource = coloursforevent.DisplayList;
            Task_colour.SelectedIndex = coloursforevent.CurrentIndex;
            string colorName2 = Task_colour.Items[Task_colour.SelectedIndex];
         

            Task_colour.SelectedIndexChanged += (sender, args) =>
            {
                if (Task_colour.SelectedIndex == -1)
                {
                    Task_colour.BackgroundColor = Color.Default;
                }
                else
                {

                    string colorName = Task_colour.Items[Task_colour.SelectedIndex];
                    ListEntry test= coloursforevent.ListEntryList[Task_colour.SelectedIndex];
                    string lilcolour = test.Code;
                    Task_colour.BackgroundColor = getColor(lilcolour);

                }
            };



            timeconsuminglevel = new ListHelper("TASK_COMPLEXITIES", -1, "");

            Task_consuming.ItemsSource = timeconsuminglevel.DisplayList;

            Task_consuming.SelectedIndex = timeconsuminglevel.CurrentIndex;


        }

        async void OnButtonClicked(object sender, EventArgs args)

        {
            //ListEntry.getEntryfromTypeAndCode("TASK_CATEGORIES", "PERSONAL"),
            string subtyype = "TASK_SUBTYPE_PERS";
            string tyype = "PERSONAL";
            if (school)
            {
                subtyype = "TASK_SUBTYPE_SC";
                tyype = "SCHOOL";
            }

            //eventype.ListEntryList[Task_type.SelectedIndex]
            //TaskSubType = ListEntry.getEntryfromTypeAndCode("TASK_SUBTYPE_SC", "BY_HEART");
            SchoolTask.InsertSchoolTask(MyUser.me, ListEntry.getEntryfromTypeAndCode("TASK_CATEGORIES", tyype),

                coloursforevent.ListEntryList[Task_colour.SelectedIndex], timeconsuminglevel.ListEntryList[Task_consuming.SelectedIndex],

                ListEntry.getEntryfromTypeAndCode(subtyype, subtype), Desc.Text, SubDesc.Text, false, test.Date);

            SchoolTask.Intelligent(MyUser.me, ListEntry.getEntryfromTypeAndCode("TASK_CATEGORIES", tyype),

            coloursforevent.ListEntryList[Task_colour.SelectedIndex], timeconsuminglevel.ListEntryList[Task_consuming.SelectedIndex],

                ListEntry.getEntryfromTypeAndCode(subtyype, subtype), Desc.Text, SubDesc.Text, false, test.Date);



        }


        async void OnPersonClicked(object sender, EventArgs args)

        {
            pers = true;
            school = false;
            Pers.Text = "Adding personal Task or Event";
            Sch.Text = "For School";
            st1.Text = "Health appointment";
            st2.Text = "Sport";
            st3.Text = "Social life";
            st4.Text = "Hobies";

        }
        async void OnWordClicked(object sender, EventArgs args)

        {
            pers = false;
            school = true;
            Sch.Text = "Adding a work task";
            Pers.Text = "Personal";
            st1.Text = "By heart";
            st2.Text = "Small exercise";
            st3.Text = "Big project";
            st4.Text = "Other";

        }

        async void Onsub1Clicked(object sender, EventArgs args)

        {
           if(school)
            {
                subtype = "BY_HEART";
                st1.Text = "Subtype: By heart";
                st2.Text = "Small exercise";
                st3.Text = "Big project";
                st4.Text = "";
            }
           else
            {
                subtype = "HEALTH";
                st1.Text = "Subtype: Health appointment";
                st2.Text = "Sport";
                st3.Text = "Social life";
                st4.Text = "Hobies";
            }
        }

        async void Onsub2Clicked(object sender, EventArgs args)

        {
            if (school)
            {
                subtype = "EXERCICE";
                st1.Text = "By heart";
                st2.Text = "Subtype: Small exercise";
                st3.Text = "Big project";
                st4.Text = "";
            }
            else
            {
                subtype = "SPORT";
                st1.Text = "Health appointment";
                st2.Text = "Subtype: Sport";
                st3.Text = "Social life";
                st4.Text = "Hobies";
            }


        }
        async void Onsub3Clicked(object sender, EventArgs args)

        {
            if (school)
            {
                subtype = "PROJECT";
                st1.Text = "By heart";
                st2.Text = "Small exercise";
                st3.Text = "Subtype: Big project";
                st4.Text = "";
            }
            else
            {
                subtype = "SOCIAL_LIFE";
                st1.Text = "Health appointment";
                st2.Text = "Sport";
                st3.Text = "Subtype: Social life";
                st4.Text = "Hobies";
            }


        }
        async void Onsub4Clicked(object sender, EventArgs args)

        {
            if (school)
            {
                subtype = "";
                st1.Text = "By heart";
                st2.Text = "Small exercise";
                st3.Text = "Big project";
                st4.Text = "Click on a subtype";
            }
            else
            {
                subtype = "HOBIES";
                st1.Text = "Health appointment";
                st2.Text = "Sport";
                st3.Text = "Social life";
                st4.Text = "Subtype: Hobies";
            }


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
                case "BLUE":
                    res = Color.Blue;
                    break;
                case "GREEN":
                    res = Color.Green;
                    break;
                case "RED":
                    res = Color.Red;
                    break;
                case "PURPLE":
                    res = Color.Purple;
                    break;
                case "BEIGE":
                    res = Color.Beige;
                    break;
                case "BLUEVIOLET":
                    res = Color.BlueViolet;
                    break;
                case "BROWN":
                    res = Color.Brown;
                    break;
                case "CORAL":
                    res = Color.Coral;
                    break;
                case "DARKBLUE":
                    res = Color.DarkBlue;
                    break;
                case "DARKMAGERNTA":
                    res = Color.DarkMagenta;
                    break;
                case "FORESTGREEN":
                    res = Color.ForestGreen;
                    break;
                case "FUCHSIA":
                    res = Color.Fuchsia;
                    break;
                case "GOLD":
                    res = Color.Gold;
                    break;
                case "GRAY":
                    res = Color.Gray;
                    break;
                case "LIGHTBLUE":
                    res = Color.LightBlue;
                    break;
                case "LIGHTGREEN":
                    res = Color.LightGreen;
                    break;
                case "MEDIUMVIOLETRED":
                    res = Color.MediumVioletRed;
                    break;
                case "BISQUE":
                    res = Color.Bisque;
                    break;
                case "CADETBLUE":
                    res = Color.CadetBlue;
                    break;
                case "SANDYBROWN":
                    res = Color.SandyBrown;
                    break;
                case "LIGHTSALMON":
                    res = Color.LightSalmon;
                    break;
                case "MIDNIGHTBLUE":
                    res = Color.MidnightBlue;
                    break;
                case "MAGENTA":
                    res = Color.Magenta;
                    break;
                case "LAWNGREEN":
                    res = Color.LawnGreen;
                    break;
                case "LIGHTPRINK":
                    res = Color.LightPink;
                    break;
                case "PALEGOLDENROD":
                    res = Color.PaleGoldenrod;
                    break;
                case "LIGHTGRAY":
                    res = Color.LightGray;
                    break;

            }


            return res;
        }







    }

}