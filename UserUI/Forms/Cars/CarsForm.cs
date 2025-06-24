using CarRental.Core.Applications;
using CarRental.Core.Domain.Entities;

namespace UserUI;

public partial class CarsForm : Form
{
    private Button backButton;
    private Button addCarButton;
    private Button deleteCarButton;
    private Button updateCarStatusButton;
    private DataGridView carGridView;

    public CarsForm()
    {
        InitializeComponent();
    }
    
    private void BackButtonClick(object sender, EventArgs e)
    {
        var mainForm = new MenuForm();
        mainForm.Show();
        
        Close();
    }
    
    private async void AddCarButtonClick(object sender, EventArgs e)
    {
        // using var form = new CarDetailsForm();
        // if (form.ShowDialog(this) == DialogResult.OK)
        // {
        //     Car newCar = form.ResultCar!;
        //     await UserApplication.AddCar(newCar);
        //
        //     carGridView.DataSource = await UserApplication.GetAllCars();
        // }
    }

    
    
    private async void DeleteCarButtonClick(object sender, EventArgs e)
    {
        var carTableForm = new CarsDeleteForm(await UserApplication.GetAllCars());
        carTableForm.Show();
        
        Close();
    }
    
    private void UpdateCarStatusButtonClick(object sender, EventArgs e)
    {
        var mainForm = new MenuForm();
        mainForm.Show();
        
        Close();
    }
}