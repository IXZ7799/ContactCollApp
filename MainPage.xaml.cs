using System.Collections.ObjectModel;

namespace ContactCollApp;

public partial class MainPage : ContentPage
{
    public CustomerCollection currentCustomers;

    public MainPage()
    {
        InitializeComponent();

        currentCustomers = CustomerCollection.MakeTestCustomers();
        collectionView.ItemsSource = currentCustomers.CustomerList;
    }

}

