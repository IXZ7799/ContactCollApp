using Microsoft.Maui.Storage;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ContactCollApp
{
    public class CustomerSQLiteDatabase
    {
        static SQLiteConnection databaseConnection;
        public const string DbFileName = "CustomerDB.db3";
        public const SQLite.SQLiteOpenFlags Flags =
            SQLite.SQLiteOpenFlags.ReadWrite | SQLite.SQLiteOpenFlags.Create | SQLite.SQLiteOpenFlags.SharedCache;
        public static string DatabasePath = "";
        public string CurrentState;

        public const string CUSTOMER_TABLE = "Customer";
        public const string ID_COLUMN = "ID";
        public const string NAME_COLUMN = "Name";
        public const string ImageName_COLUMN = "ImageName";
        public const string ADDRESS_COLUMN = "Address";

        public const string DEFAULT_IMAGE = "no_image.png";
        public static string[] imageNames = new string[]
        {
            "user_astronaut.svg", "user_businessman.svg", "user_detective.svg", "user_doctor.svg", "user_graduate.svg", "user_ninja.svg", "user_nurse.svg", "user_police.svg", "user_robot.svg"
        };

        public CustomerSQLiteDatabase()
        {
            Init();
        }

        private void Init()
        {
            try
            {
                if (databaseConnection != null)
                {
                    CurrentState = "Database exists";
                    return;
                }
                DatabasePath = System.IO.Path.Combine(FileSystem.AppDataDirectory, DbFileName);
                databaseConnection = new SQLiteConnection(DatabasePath);
                databaseConnection.CreateTable<Customer>();
                CurrentState = "Database created";
            }
            catch (SQLiteException ex)
            {
                CurrentState = ex.Message;
            }
        }

        public void resetDatabase()
        {
            try
            {
                databaseConnection.DropTable<Customer>();
                databaseConnection.CreateTable<Customer>();
            }
            catch (SQLiteException ex)
            {
                CurrentState = ex.Message;
            }
        }
        
        public int SaveCustomer(Customer person)
        {
            if (person.ID > 0)
            {
                return databaseConnection.Update(person);
            }
            else
            {
                return databaseConnection.Insert(person);
            }
        }

        public List<Customer> GetCustomerList()
        {
            try
            {
                return databaseConnection.Table<Customer>().ToList();
            }
            catch (Exception ex)
            {
                CurrentState = string.Format("Failed to retrieve data. {0}", ex.Message);
            }
            return new List<Customer>();
        }

        public List<Customer> SearchCustomerByName(string name)
        {
            try
            {
                return databaseConnection.Query<Customer>("SELECT * FROM " + CUSTOMER_TABLE + " WHERE " + NAME_COLUMN + " LIKE '%' || ? || '%' OR " + ADDRESS_COLUMN + " LIKE '%' || ? || '%';", new string[] { name, name });
            }
            catch (Exception ex)
            {
                CurrentState = string.Format("Failed to retrieve data {0}", ex.Message);
            }
            return new List<Customer>();
        }

        public int DeleteCustomer(Customer person)
        {
            try
            {
                return databaseConnection.Delete(person);
            }
            catch (Exception ex)
            {
                CurrentState = string.Format("Failed to retrieve data. {0}", ex.Message);
            }
            return 0;
        }

        public int DeleteAllCustomers()
        {
            try
            {
                return databaseConnection.DeleteAll<Customer>();
            }
            catch (Exception ex)
            {
                CurrentState = string.Format("Failed to retrieve data {0}", ex.Message);
            }
            return 0;
        }
    }
}
