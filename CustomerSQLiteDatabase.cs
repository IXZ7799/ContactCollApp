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
	}
}