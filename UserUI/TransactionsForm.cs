using CarRental.Core.Applications;
using CarRental.Core.Domain.Entities;

namespace UserUI;

public partial class TransactionsForm : Form
{
    private TextBox txtId;
    private TextBox txtClientId;
    private TextBox txtOperationName;
    private TextBox txtSigningDate;
    private TextBox txtEndDate;
    
    public TransactionsForm()
    {
        InitializeComponent();
    }
    
    private async void ButtonOkClick(object sender, EventArgs e)
    {
        var Id = txtId.Text.Trim();
        var clientId    = txtClientId.Text.Trim();
        var operationName = txtOperationName.Text.Trim();
        var signingDate = txtSigningDate.Text.Trim();
        var endDate = txtEndDate.Text.Trim();
        
        if (string.IsNullOrWhiteSpace(clientId) ||
            string.IsNullOrWhiteSpace(operationName) ||
            string.IsNullOrWhiteSpace(signingDate) || 
            string.IsNullOrWhiteSpace(endDate))
        {
            MessageBox.Show("Please fill in all required fields", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        
        var transaction = new Transaction(Id, clientId, operationName, DateTime.Parse(signingDate), DateTime.Parse(endDate));
        await UserApplication.AddTransaction(transaction);
        
        var carAddForm = new CarAddForm(transaction.Id);
        
        // if (transaction.OperationName == "Whose") 
        //     carAddForm = new CarAddForm(transaction.Id);
        // if (transaction.OperationName == "Rent")
        //     carAddForm = new CarAddForm(transaction.Id);
        
        carAddForm.Show();
        
        Close();
    }
}