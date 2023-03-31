using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace ContactCollApp;

[Table("Customer")]
public class Customer
{
    [MaxLength(250)]
    public string Name { get; set; }
    public string Address { get; set; }

    [PrimaryKey, AutoIncrement]
    public int ID { get; set; }
    public string ImageName { get; set; }
    public Customer()
    {
        ID = 0;
        ImageName = CustomerSQLiteDatabase.DEFAULT_IMAGE;
    }

    public Customer(string inName, string inAddress, int inID)
    {
        Name = inName;
        Address = inAddress;
        ID = inID;
        ImageName = CustomerSQLiteDatabase.DEFAULT_IMAGE;
    }

    public Customer(string inName, string inAddress, int inID, string inImageName)
    {
        Name = inName;
        Address = inAddress;
        ID = inID;
        ImageName = inImageName;
    }
}
