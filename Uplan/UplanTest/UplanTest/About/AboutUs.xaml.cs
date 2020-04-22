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
    public partial class AboutUs : ContentPage
    {
        public AboutUs()
        {
            InitializeComponent();


        }

        private void HeraClicked(object sender, EventArgs args)
        {
            DisplayAlert("Hera", "Known as the leader of empires and daughter of Chronos, Hera is the perfect group leader. Just like her father, she knows how to manage deadlines and obligations. As the goddess of fertility and being unable to bear any mortal offsprings, she plans to make Uplan an extraordinary project. With her well-known ambition, Héra is highly ambitious and has many ideas and will work tirelessly for her group. Driven by an immense computer curiosity from the second that she entered the cradle of computing via python, she intends to fuel this desire to learn during this project. In conflict with her brother Zeus, she loves persecuting his children and will not hesitate to punish them if they do not obey. In other words, Anna is the perfect goddess of this situation.", "ok wow!");

        }
        private void HadesClicked(object sender, EventArgs args)
        {
            DisplayAlert("Hades", "Hades, the god that codes away in an underground world is sometimes named by his mortal name, Thomas. Although his shield made the world of computing invisible in the life of Hardés before meeting Epita, he fights invalid args on the daily and stack overflows to get out of the darkness of this world of giants. Not having a place of worship, Hades comes to this group so that his work may be venerated. His role is to ensure a perfect code, he ensures the passage towards the success of the project and reassures the group as he will send off to the Cerberus anyone or anything that could disrupt the well-being of the group.", "ok wow!");
        }
        private void ApollonClicked(object sender, EventArgs args)
        {
            DisplayAlert("Apollon", "In the Chronos team there also is Apollo, nicknamed by his friends Rémi, god of arts, music, light. His passion for everything around him, his ability to take all tasks that are entrusted to him seriously. He helps the group thanks to his knowledge acquired during a year and a half of computer training for the advancement of the Uplan project. He is also able to show a good sense of teamwork in order to be able to overcome the various obstacles that will arise as the project continues to grow.", "ok wow!");
        }
        private void AthenaClicked(object sender, EventArgs args)
        {
            DisplayAlert("Athena", "A true warrior at heart, Athena is a strategist and can easily conquer the world that is made of applications and the ideas of the other groups. Marine, better known as Athena, is a real asset for our team. She has a creative mind that visualises the ideas put forward by the group, her brush is her sword that kills any ideas that are anywhere as clear as AFIT instructions. In a past life, she was a student at Notre Dame High School in Belleguard and discovered that her destiny was to face the computer problems she encountered in computer it and develop tools to make her new visions come to life. This project is like her shield with Medusa’s head to fight the judgments around women in computer science. Goddess of wisdom, Marine knows how to listen to the group and collaborate every step of the way of this project.", "ok wow");
        }

        private void DisplaySite(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("https://ijg8h0bvrymprrzkpcfm6q-on.drv.tw/SiteUplan/SiteUPLAN/"));


        }
    }
}