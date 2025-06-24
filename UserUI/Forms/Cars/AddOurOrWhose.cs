namespace UserUI;

public partial class AddOurOrWhose : Form
{
    private Button addOurCarButton;
    private Button addWhoseCarButton;
    
    public AddOurOrWhose()
    {
        InitializeComponent();
    }
    private async void AddOurCarButtonClick(object sender, EventArgs e)
    {
        var addForm = new CarAddForm();
        addForm.Show();
        
        Close();
    }
    
    private async void AddWhoseCarButtonClick(object sender, EventArgs e)
    {
        var transactionForm = new TransactionsForm();
        transactionForm.Show();
        
        Close();
    }
}