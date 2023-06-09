﻿using System.Collections.ObjectModel;

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
        collectionView.ItemsSource = App.CustomerDatabase.GetCustomerList();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        populateCustomerData();
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

    private void btnDeleteAll_Clicked(object sender, EventArgs e)
    {
        App.CustomerDatabase.DeleteAllCustomers();
        populateCustomerData();
    }

    private void searchCustomer_SearchButtonPressed(object sender, EventArgs e)
    {
        string keyword = this.searchCustomer.Text;

        if (keyword == null || keyword.Length == 0)
        {
            populateCustomerData();
        }
        else
        {
            collectionView.ItemsSource = App.CustomerDatabase.SearchCustomerByName(keyword);
        }
    }
}

