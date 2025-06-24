namespace UserUI;

public partial class ClientsForm : Form
{
    public ClientsForm()
    {
        InitializeComponent();
    }
    
    private void BackButtonClick(object sender, EventArgs e)
    {
        var mainForm = new MenuForm();
        mainForm.Show();
        
        Close();
    }
}