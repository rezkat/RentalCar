namespace UserUI;

public partial class MenuForm : Form
{
    public MenuForm()
    {
        InitializeComponent();
    }
    
    private void OpenTransactionsFormButtonClick(object sender, EventArgs e)
    {
        var carForm = new TransactionsForm();   
        carForm.Show();

        Hide();
    }
    
    private void OpenCarsFormButtonClick(object sender, EventArgs e)
    {
        var carForm = new CarsForm();  
        carForm.Show();               

        Hide();                  
    }
    
    private void OpenClientsFormButtonClick(object sender, EventArgs e)
    {
        var carForm = new ClientsForm();  
        carForm.Show();               

        Hide();                  // скрыть текущую форму (например, MainForm)
    }
}