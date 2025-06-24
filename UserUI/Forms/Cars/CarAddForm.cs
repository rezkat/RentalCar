using CarRental.Core.Applications;
using CarRental.Core.Domain.Entities;

namespace UserUI;

public partial class CarAddForm : Form
{
    private Button backButton;
    private TextBox txtId;
    private TextBox txtBrand;
    private TextBox txtModel;
    private TextBox txtColor;
    private string Whose { set; get; }

    public CarAddForm(string whose = null)
    {
        InitializeComponent();
        Whose = whose;
    }
    
    private void BackButtonClick(object sender, EventArgs e)
    {
        var backForm = new CarsForm();
        backForm.Show();
        
        Close();
    }
    
    private async void ButtonOkClick(object sender, EventArgs e)
    {
        var id    = txtId.Text.Trim();
        var brand = txtBrand.Text.Trim();
        var model = txtModel.Text.Trim();
        var color = txtColor.Text.Trim();
        
        if (string.IsNullOrWhiteSpace(id) ||
            string.IsNullOrWhiteSpace(brand) ||
            string.IsNullOrWhiteSpace(model) || 
            string.IsNullOrWhiteSpace(color))
        {
            MessageBox.Show("Please fill in all required fields", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var car = new Car(id, brand, model, color, null, Whose);
        await UserApplication.AddCar(car);
        
        var carForm = new CarsForm();
        carForm.Show();
        
        Close();
    }

}