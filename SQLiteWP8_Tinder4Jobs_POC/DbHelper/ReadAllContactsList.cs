using SQLiteWP8_Tinder4Jobs_POC.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteWP8_Tinder4Jobs_POC.DbHelper
{
    public class ReadAllContactsList
    {
        DatabaseContactHelperClass Db_Helper = new DatabaseContactHelperClass();
        public  ObservableCollection<Contacts> GetAllContacts()
        {
            return Db_Helper.ReadContacts();
        }
    }
}
