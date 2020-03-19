using System;

using Xamarin.Forms;

using Xamarin.Forms.Xaml;

using System.Linq;

using System.Text;



//using GalaSoft.MvvmLight.Views;

//using Windows.UI.Xaml

//using Windows.UI.Xaml.Input;

//using Windows.System;



//System.Windows.Controls;



using System.Threading.Tasks;

using LiteDB;



namespace UplanTest

{

    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class AddEvent : ContentPage

    {



        ListHelper eventype;

        ListHelper eventsoutype;

        ListHelper coloursforevent;

        ListHelper timeconsuminglevel;

        public DateTime? FavoriteDay { get; set; }

        public AddEvent()



        {

            InitializeComponent();





            //Database.Initiate();

            eventype = new ListHelper("TASK_CATEGORIES", -1, "");





            // pListType, int pCurrentId, string pCurrentCode

            Task_type.ItemsSource = eventype.DisplayList;

            Task_type.SelectedIndex = eventype.CurrentIndex;

            string sl = Convert.ToString(Task_type.SelectedItem);




           


            if ((Task_type.SelectedItem).Equals("Personal")) // trouver comment comparer

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



            coloursforevent = new ListHelper("COLOURS", -1, "");

            // pListType, int pCurrentId, string pCurrentCode

            Task_colour.ItemsSource = coloursforevent.DisplayList;

            Task_colour.SelectedIndex = coloursforevent.CurrentIndex;



            timeconsuminglevel = new ListHelper("TASK_COMPLEXITIES", -1, "");

            Task_consuming.ItemsSource = timeconsuminglevel.DisplayList;

            Task_consuming.SelectedIndex = timeconsuminglevel.CurrentIndex;


        }

        async void OnButtonClicked(object sender, EventArgs args)

        {


            SchoolTask.InsertSchoolTask(MyUser.me, eventype.ListEntryList[Task_type.SelectedIndex],

                coloursforevent.ListEntryList[Task_colour.SelectedIndex], timeconsuminglevel.ListEntryList[Task_consuming.SelectedIndex],

                eventsoutype.ListEntryList[Task_subtype.SelectedIndex], Desc.Text, SubDesc.Text, false, test);



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







    }

}