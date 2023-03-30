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
    public static string[] imageNames = new string[] { "user_astronaut.svg", "user_businessman.svg", "user_detective.svg", "user_doctor.svg", "user_graduate.svg", "user_ninja.svg", "user_nurse.svg", "user_police.svg", "user_robot.svg" };

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