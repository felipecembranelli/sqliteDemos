using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using SQLiteWp8.ViewModel;
using SQLiteWp8.Model;
using SQLite;

namespace SQLiteWp8.Views
{
    public partial class AddConatct : PhoneApplicationPage
    {
        
        public AddConatct()
        {
            InitializeComponent();
        }

        private async void AddContact_Click(object sender, RoutedEventArgs e)
        {
            DatabaseHelperClass Db_Helper = new DatabaseHelperClass();//Creating object for DatabaseHelperClass.cs from ViewModel/DatabaseHelperClass.cs
            if (NametxtBx.Text != "" & PhonetxtBx.Text != "")
            {
                Db_Helper.Insert(new Contacts(NametxtBx.Text, PhonetxtBx.Text));//
                NavigationService.Navigate(new Uri("/Views/ReadContactList.xaml", UriKind.Relative));//after add contact redirect to contact listbox page
            }
            else
            {
                MessageBox.Show("Please fill two fields");//Text should not be empty
            }
        }
    }
}