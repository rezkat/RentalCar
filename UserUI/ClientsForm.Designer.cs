using System.ComponentModel;

namespace UserUI;

partial class ClientsForm
{
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

    }
}