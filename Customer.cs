using System;
using System.Collections.Generic;
using System.Text;

namespace ContactCollApp
{
    public class Customer
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int ID { get; set; }
        public string ImageName { get; set; }

        public Customer(string inName, string inAddress, int inID)
        {
            Name = inName;
            Address = inAddress;
            ID = inID;
            ImageName = CustomerCollection.DEFAULT_IMAGE;
        }
        public Customer(string inName, string inAddress, int inID, string inImageName)
        {
            Name = inName;
            Address = inAddress;
            ID = inID;
            ImageName = inImageName;
        }
    }
}
