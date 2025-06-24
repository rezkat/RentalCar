using System.ComponentModel;
using CarRental.Core.Applications;
using CarRental.Core.Domain.Interfaces;
using CarRental.Core.Infrastructure.Database;
using CarRental.Core.Infrastructure.Repositories;

namespace UserUI;

partial class CarsForm
{
    public async void InitializeComponent()
    {
        // - - оформление - -
        // настройка размера, названия, фона
        this.ClientSize = new System.Drawing.Size(800, 500);
        this.Text = "Car Rental System";
        this.BackColor = Color.White;
        
        // цвет и текст для панелей
        Color redColor = Color.FromArgb(255, 0, 0);
        Font titleFont = new Font("Segoe UI", 20 /*размер шрифта*/, FontStyle.Bold /*Bold -- жирный*/ );
        Font littleTitleFont = new Font("Segoe UI", 10 /*размер шрифта*/, FontStyle.Bold /*Bold -- жирный*/ );

        // верхняя красная панель
        var panelTop = new Panel
        {
            Dock = DockStyle.Top,
            Height = 100,
            BackColor = redColor
        };
        this.Controls.Add(panelTop);
        
        var lblTitle = new Label
        {
            Text = "CAR RENTAL SYSTEM",
            ForeColor = Color.White,
            Font = titleFont,
            AutoSize = false,                           // Отключаем автоматический размер
            Size = new Size(300, 50),        // Ширина = 300px, высота = 40px
            Location = new Point(270, 30)

        };
        panelTop.Controls.Add(lblTitle);
        
        
        // 1я кнопка (бэк)
        backButton = new Button 
        {
            Text = "Back",
            Size = new Size(100, 30),

            ForeColor = Color.White,
            BackColor = redColor,
        
            FlatStyle = FlatStyle.Flat,
            Font = littleTitleFont,
        
            Location = new Point(20, 450)
        };
        backButton.Click += new EventHandler(BackButtonClick);
        
        // 2я кнопка
        addCarButton = new Button 
        {
            Text = "Add Car",
            Size = new Size(200, 60),

            ForeColor = Color.White,
            BackColor = redColor,
        
            FlatStyle = FlatStyle.Flat,
            Font = littleTitleFont,
        
            Location = new Point(30, 150)
        };
        addCarButton.Click += new EventHandler(AddCarButtonClick);
        
        // 3 кнопка
        deleteCarButton = new Button 
        {
            Text = "Delete Car",
            Size = new Size(200, 60),

            ForeColor = Color.White,
            BackColor = redColor,
        
            FlatStyle = FlatStyle.Flat,
            Font = littleTitleFont,
        
            Location = new Point(300, 150)
        };
        deleteCarButton.Click += new EventHandler(DeleteCarButtonClick);
        
        // 4 кнопка
        updateCarStatusButton = new Button 
        {
            Text = "Update status",
            Size = new Size(200, 60),

            ForeColor = Color.White,
            BackColor = redColor,
        
            FlatStyle = FlatStyle.Flat,
            Font = littleTitleFont,
        
            Location = new Point(570, 150)
        };
        updateCarStatusButton.Click += new EventHandler(UpdateCarStatusButtonClick);
        
        this.Controls.Add(this.backButton);
        this.Controls.Add(this.addCarButton);
        this.Controls.Add(this.deleteCarButton);
        this.Controls.Add(this.updateCarStatusButton);
        
        carGridView = new DataGridView
        {
            Dock = DockStyle.Fill,
            ReadOnly = true,
            AutoGenerateColumns = true,
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
            SelectionMode = DataGridViewSelectionMode.FullRowSelect
        };
        
        // Загрузка данных
        carGridView.DataSource = await UserApplication.GetAllCars();
        
        var gridPanel = new Panel
        {
            Location = new Point(30, 250),
            Size = new Size(740, 200),
            Padding = new Padding(10),
            BackColor = Color.White
        };
        gridPanel.Controls.Add(carGridView);
        this.Controls.Add(gridPanel);
    }
}