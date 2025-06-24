using System.ComponentModel;

namespace UserUI;

partial class CarAddForm
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
        
        // - - кнопка бек - - 
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
        this.Controls.Add(this.backButton);

        // - - текстовые поля - -
        var lblId = new Label
        {
            Text = "Car number:",
            Location = new Point(60, 180),
            Size = new Size(60, 20)
        };

        txtId = new TextBox
        {
            Location = new Point(150, 180),             
            Size = new Size(200, 20)        
        };

        this.Controls.Add(lblId);
        this.Controls.Add(txtId);
        
        var lblBrand = new Label
        {
            Text = "Brand:",
            Location = new Point(60, 240),
            Size = new Size(60, 20)
        };

        txtBrand = new TextBox
        {
            Location = new Point(150, 240),             
            Size = new Size(200, 20)        
        };

        this.Controls.Add(lblBrand);
        this.Controls.Add(txtBrand);
        
        var lblModel = new Label
        {
            Text = "Model:",
            Location = new Point(60, 300),
            Size = new Size(60, 20)
        };

        txtModel = new TextBox
        {
            Location = new Point(150, 300),             
            Size = new Size(200, 20)        
        };
        
        this.Controls.Add(lblModel);
        this.Controls.Add(txtModel);
        
        var lblColor = new Label
        {
            Text = "Color:",
            Location = new Point(60, 360),
            Size = new Size(60, 20)
        };

        txtColor = new TextBox
        {
            Location = new Point(150, 360),             
            Size = new Size(200, 20)        
        };
        
        this.Controls.Add(lblColor);
        this.Controls.Add(txtColor);
        
        var buttonOk = new Button
        {
            Text = "OK",
            Size = new Size(100, 40),
            Location = new Point(600, 420),       // подгоните координаты под свой дизайн
            BackColor = Color.Green,
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
        };
        buttonOk.Click += new EventHandler(ButtonOkClick);

        this.Controls.Add(buttonOk);
    }
}