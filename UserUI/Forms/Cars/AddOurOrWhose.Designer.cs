using System.ComponentModel;

namespace UserUI;

partial class AddOurOrWhose
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
        Font titleFont = new Font("Segoe UI", 20 /*размер шрифта*/, FontStyle.Bold /*Bold -- жирный*/);
        Font littleTitleFont = new Font("Segoe UI", 10 /*размер шрифта*/, FontStyle.Bold /*Bold -- жирный*/);

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
            Text = "OUR OR WHOSE",
            ForeColor = Color.White,
            Font = titleFont,
            AutoSize = false, // Отключаем автоматический размер
            Size = new Size(300, 50), // Ширина = 300px, высота = 40px
            Location = new Point(270, 30)

        };
        panelTop.Controls.Add(lblTitle);
        
        addOurCarButton = new Button 
        {
            Text = "OUR",
            Size = new Size(200, 60),

            ForeColor = Color.White,
            BackColor = redColor,
        
            FlatStyle = FlatStyle.Flat,
            Font = littleTitleFont,
        
            Location = new Point(100, 150)
        };
        addOurCarButton.Click += new EventHandler(AddOurCarButtonClick);
        this.Controls.Add(addOurCarButton);
        
        addWhoseCarButton = new Button 
        {
            Text = "WHOSE",
            Size = new Size(200, 60),

            ForeColor = Color.White,
            BackColor = redColor,
        
            FlatStyle = FlatStyle.Flat,
            Font = littleTitleFont,
        
            Location = new Point(500, 150)
        };
        addWhoseCarButton.Click += new EventHandler(AddWhoseCarButtonClick);
        this.Controls.Add(addWhoseCarButton);
        this.Controls.Add(addWhoseCarButton);

    }
}