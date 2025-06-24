using System.ComponentModel;
using CarRental.Core.Domain.Entities;

namespace UserUI;

partial class CarsDeleteForm
{
    private DataGridView dataGridView;

    public void InitializeComponent(IEnumerable<Car> cars)
    {
        this.Text = "Список машин";
        this.Size = new Size(700, 400);
        this.StartPosition = FormStartPosition.CenterScreen;

        dataGridView = new DataGridView
        {
            Dock = DockStyle.Fill,
            ReadOnly = true,
            AutoGenerateColumns = true,
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        };

        dataGridView.DataSource = cars;
        
        dataGridView.CellDoubleClick += DataGridView_CellDoubleClick;

        this.Controls.Add(dataGridView);
    }
}