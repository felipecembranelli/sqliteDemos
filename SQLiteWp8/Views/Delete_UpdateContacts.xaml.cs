﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using SQLiteWp8.Model;
using SQLiteWp8.ViewModel;

namespace SQLiteWp8.Views
{
    public partial class Delete_UpdateContacts : PhoneApplicationPage
    {
        int Selected_ContactId = 0;
        DatabaseHelperClass Db_Helper = new DatabaseHelperClass();
        Contacts currentcontact = new Contacts();
        public Delete_UpdateContacts()
        {
            InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Selected_ContactId = int.Parse(NavigationContext.QueryString["SelectedContactID"]);
            currentcontact = Db_Helper.ReadContact(Selected_ContactId);//Read selected DB contact
            NametxtBx.Text = currentcontact.Name;//get contact Name
            PhonetxtBx.Text = currentcontact.PhoneNumber;//get contact PhoneNumber
        }
        
        private void UpdateContact_Click(object sender, RoutedEventArgs e)
        {
            currentcontact.Name = NametxtBx.Text;
            currentcontact.PhoneNumber = PhonetxtBx.Text;
            Db_Helper.UpdateContact(currentcontact);//Update selected DB contact Id
            NavigationService.Navigate(new Uri("/Views/ReadContactList.xaml", UriKind.Relative)); 
        }
        private void DeleteContact_Click(object sender, RoutedEventArgs e)
        {
            Db_Helper.DeleteContact(Selected_ContactId);//Delete selected DB contact Id.
            NavigationService.Navigate(new Uri("/Views/ReadContactList.xaml", UriKind.Relative)); 
        }
    }
}