using System.Collections.ObjectModel;

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
}