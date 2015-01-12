using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteWP8_Tinder4Jobs_POC.Model
{
    public class Contacts : INotifyPropertyChanged
    {
       
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int Id
        {
            get;
            set;
        }
        //The Id property is marked as the Primary Key
        private int idValue;
        private string NameValue = String.Empty;
        //private string companyNameValue = String.Empty;
        private string phoneNumberValue = String.Empty;
        public string Name
        {
            get { return this.NameValue; }

            set
            {
                if (value != this.NameValue)
                {
                    this.NameValue = value;
                    NotifyPropertyChanged("Name");
                }
            }
        }
        public string PhoneNumber
        {
            get { return this.phoneNumberValue; }

            set
            {
                if (value != this.phoneNumberValue)
                {
                    this.phoneNumberValue = value;
                    NotifyPropertyChanged("PhoneNumber");
                }
            }
        }
        
        public string CreationDate {
            get; set; 
        }
        public Contacts()
        {
        }
        public Contacts(string name,string phone_no)
        {
            Name = name;
            PhoneNumber = phone_no;
            CreationDate = DateTime.Now.ToString();
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    } 
}
