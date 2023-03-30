namespace ContactCollApp;

public partial class CustomerDetails : ContentPage
{
    private bool isUpdated;
    public CustomerDetails(Customer cust, bool isUpdated)
    {
        InitializeComponent();
        this.isUpdated = isUpdated;

        App thisApp = Application.Current as App;
        thisApp.selectedCustomer = cust;
        this.gridCustomer.BindingContext = thisApp.selectedCustomer;
    }

    private void pckImage_SelectedIndexChanged()
    {

    }
}