using Microsoft.Maui.Controls;

namespace ContactCollApp;

public partial class CustomerDetails : ContentPage
{
    private bool isUpdated;
    public CustomerDetails(Customer cust, bool isUpdated)
    {
        InitializeComponent();
        this.isUpdated = isUpdated;

        this.pckImage.Items.Clear();
        this.pckImage.ItemsSource = CustomerSQLiteDatabase.imageNames;

        App thisApp = Application.Current as App;
        thisApp.selectedCustomer = cust;
        this.gridCustomer.BindingContext = thisApp.selectedCustomer;

        if (cust != null)
            this.pckImage.SelectedItem = cust.ImageName;
    }

    private void pckImage_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.imgPic.Source = this.pckImage.SelectedItem as string;
    }

    private void btnSave_Clicked(object sender, EventArgs e)
    {
        string selectedImage = CustomerSQLiteDatabase.DEFAULT_IMAGE;
        string name = this.txtName.Text;
        string address = this.txtAddress.Text;

        if (this.pckImage.SelectedItem != null)
            selectedImage = this.pckImage.SelectedItem as string;

        if (isUpdated)
        {
            App thisApp = Application.Current as App;

            thisApp.selectedCustomer.Name = name;
            thisApp.selectedCustomer.Address = address;
            thisApp.selectedCustomer.ImageName = selectedImage;

            App.CustomerDatabase.SaveCustomer(thisApp.selectedCustomer);
        }
        else
        {
            Customer newCust = new Customer(name, address, 0, selectedImage);
            App.CustomerDatabase.SaveCustomer(newCust);
            Navigation.PopModalAsync();
        }
    }

    private void btnDelete_Clicked(object sender, EventArgs e)
    {
        App thisApp = Application.Current as App;
        App.CustomerDatabase.DeleteCustomer(thisApp.selectedCustomer);
        Navigation.PopModalAsync();
    }

    private void btnBack_Clicked(object sender, EventArgs e)
    {
        Navigation.PopModalAsync();
    }
}