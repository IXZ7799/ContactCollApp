namespace ContactCollApp;

public partial class CustomerDetails : ContentPage
{
    private bool isUpdated;
    public CustomerDetails(Customer cust, bool isUpdated)
    {
        InitializeComponent();
        this.isUpdated = isUpdated;

        this.pckImage.Items.Clear();
        this.pckImage.ItemsSource = CustomerCollection.imageNames;

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

    private async void btnSave_Clicked(object sender, EventArgs e)
    {
        string selectedImage = CustomerCollection.DEFAULT_IMAGE;
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

            int pos = MainPage.currentCustomers.CustomerList.IndexOf(thisApp.selectedCustomer);
            MainPage.currentCustomers.CustomerList.RemoveAt(pos);

            MainPage.currentCustomers.CustomerList.Insert(pos, thisApp.selectedCustomer);
        }
        else
        {
            Customer newCust = new Customer(name, address, CustomerCollection.IdCustomer++, selectedImage);
            MainPage.currentCustomers.CustomerList.Add(newCust);
        }
        await Navigation.PopAsync();
    }
}