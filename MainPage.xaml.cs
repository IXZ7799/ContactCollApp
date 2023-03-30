using System.Collections.ObjectModel;

namespace ContactCollApp;

public partial class MainPage : ContentPage
{
    public static CustomerCollection currentCustomers;

    public MainPage()
    {
        InitializeComponent();
    }

    private void populateCustomerData()
    {
        collectionView.ItemSource = App.CustomerDatabase.GetCustomerList();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        populateCustomerData();
    }

    private void collecionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        Customer selectedCust = (e.CurrentSelection.FirstOrDefault() as Customer);
        Navigation.PushModalAsync(new CustomerDetails(selectedCust, true), true);
    }

    private void btnAdd_Clicked(object sender, EventArgs e)
    {
        Customer newCust = new Customer("", "", 0, CustomerCollection.DEFAULT_IMAGE);
        Navigation.PushModalAsync(new CustomerDetails(newCust, false), true);
    }

    private void btnDeleteAll_Clicked(object sender, EventArgs e)
    {
        App.CustomerDatabase.DeleteAllCustomers();
        populateCustomerData();
    }

    private void btnInitData_Clicked(object sender, EventArgs e)
    {
        App.CustomerDatabase.DeleteAllCustomers();
        App.CustomerDatabase.resetDatabase();
        App.CustomerDatabase.InsertTestData();
        populateCustomerData();
    }
}

