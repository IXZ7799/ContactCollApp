namespace ContactCollApp;

public partial class App : Application
{
    public Customer selectedCustomer;
    private static CustomerSQLiteDatabase customerDB;
    public App()
    {
        InitializeComponent();

        MainPage = new AppShell();
    }

    public static CustomerSQLiteDatabase CustomerDatabase
    {
        get
        {
            if (customerDB == null)
            {
                customerDB = new CustomerSQLiteDatabase();
            }
            return customerDB;
        }
    }
}
