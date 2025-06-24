namespace UserUI;

partial class MenuForm
{
    private Button clientButton;
    private Button carButton;
    private Button transactionButton;
    
    private void InitializeComponent()
    {
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
        
        
        // Создание кнопок
        int x = 550;
    
        transactionButton = new Button
        {
            Text = "TRANSACTIONS",
            Size = new Size(200, 70),

            ForeColor = Color.White,
            BackColor = redColor,
            
            FlatStyle = FlatStyle.Flat,
            Font = littleTitleFont,
            
            Location = new Point(x, 400)
        };
        // btn.FlatAppearance.BorderSize = 0;
        transactionButton.Click += new EventHandler(OpenTransactionsFormButtonClick);
        x -= 250;

        
        carButton = new Button
        {
            Text = "CARS",
            Size = new Size(200, 70),

            ForeColor = Color.White,
            BackColor = redColor,
            
            FlatStyle = FlatStyle.Flat,
            Font = littleTitleFont,
            
            Location = new Point(x, 400)
        };
        carButton.Click += new EventHandler(OpenCarsFormButtonClick);
        x -= 250;

        clientButton = new Button 
        {
            Text = "CLIENTS",
            Size = new Size(200, 70),

            ForeColor = Color.White,
            BackColor = redColor,
        
            FlatStyle = FlatStyle.Flat,
            Font = littleTitleFont,
        
            Location = new Point(x, 400)
        };
        clientButton.Click += new EventHandler(OpenClientsFormButtonClick);
        
        
        // добавление кнопок
        this.Controls.Add(this.transactionButton);
        this.Controls.Add(this.carButton);
        this.Controls.Add(this.clientButton);
    }
}
