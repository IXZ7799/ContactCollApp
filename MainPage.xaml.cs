using System.Collections.ObjectModel;

namespace ContactCollApp;

public partial class MainPage : ContentPage
{
    public static CustomerCollection currentCustomers;

    public MainPage()
    {
        InitializeComponent();

        currentCustomers = CustomerCollection.MakeTestCustomers();
        collectionView.ItemsSource = currentCustomers.CustomerList;
    }

    private void collectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        Customer selectedCust = (e.CurrentSelection.FirstOrDefault() as Customer);
        Navigation.PushModalAsync(new CustomerDetails(selectedCust, true), true);
    }

    private void btnAdd_Clicked(object sender, EventArgs e)
    {
        Customer newCust = new Customer("", "", 0, CustomerCollection.DEFAULT_IMAGE);
        Navigation.PushModalAsync(new CustomerDetails(newCust, false), true);
    }
}

