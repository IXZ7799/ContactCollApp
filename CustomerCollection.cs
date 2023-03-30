using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ContactCollApp;

public class CustomerCollection
{
    public static int IdCustomer = 0;
    public ObservableCollection<Customer> CustomerList;
    public const string DEFAULT_IMAGE = "no_image.png";
    public static string[] imageNames = new string[] { "user-astronaut.svg", "user-businessman.svg", "user-detective.svg", "user-doctor.svg", "user-graduate.svg", "user-ninja.svg", "user-nurse.svg", "user-police.svg", "user-robot.svg" };

    public CustomerCollection()
    {
        CustomerList = new ObservableCollection<Customer>();
    }


    public static CustomerCollection MakeTestCustomers()
    {
        string[] firstNames = new string[] { "Rob", "Jim", "Joe", "Hugo", "Sally", "Tim", "Marty", "Liam", "Art" };
        string[] lastNames = new string[] { "Smith", "Jones", "Gold", "Boss", "Mile", "Brown", "Lint", "Novak" };

        CustomerCollection result = new CustomerCollection();
        int imgIndex = 0;
        Random sessionRand = new Random();

        foreach (string lastName in lastNames)
        {
            foreach (string firstName in firstNames)
            {
                string name = firstName + " " + lastName;

                Customer newCustomer = new Customer(name, name + "'s house", IdCustomer, imageNames[imgIndex]);
                imgIndex++;
                if (imgIndex == imageNames.Length)
                {
                    imgIndex = 0;
                }
                result.CustomerList.Add(newCustomer);
                IdCustomer++;
            }
        }
        return result;
    }
}