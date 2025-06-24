
using CarRental.Core.Applications;
using CarRental.Core.Domain.Entities;

namespace UserUI;

public partial class CarsDeleteForm : Form
{
    public CarsDeleteForm(IEnumerable<Car> cars)
    {
        InitializeComponent(cars);
        // FormClosing += CarsDeleteFormClosing;
    }
    
    private async void DataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0) return; // клик был не по заголовку
        
        var selectedRow = dataGridView.Rows[e.RowIndex];
        if (selectedRow.DataBoundItem is Car car)
        {
            MessageBox.Show($"Вы выбрали машину:\n{car.Brand} {car.Model} ({car.Id})");
            await UserApplication.DeleteCar(car.Id);
            var carForm = new CarsForm();
            carForm.Show();
            
            Close();
        }
    }
    
    // private void CarsDeleteFormClosing(object sender, FormClosingEventArgs e)
    // {
    //     var result = MessageBox.Show("Вы уверены, что хотите закрыть?", 
    //         "Закрытие формы", 
    //         MessageBoxButtons.YesNo, 
    //         MessageBoxIcon.Question);
    //
    //     if (result != DialogResult.No)
    //         e.Cancel = true;
    // }
}