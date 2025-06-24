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
        // var addForm = new CarAddForm();
        
        var addForm = new AddOurOrWhose();
        addForm.Show();
        
        Close();
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