namespace ContactCollApp;

public partial class App : Application
{
    public Customer selectedCustomer;
    public App()
    {
        InitializeComponent();

        MainPage = new AppShell();
    }
}
