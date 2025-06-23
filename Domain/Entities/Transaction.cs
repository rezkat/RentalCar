namespace CarRental.Core.Domain.Entities;

// Models/Transaction.cs
public class Transaction
{
    public string Id { get; set; }
    public string ClientId { get; set; }
    public string OperationName { get; set; } // 0 или 1
    public DateTime SigningDate { get; set; }
    public DateTime EndDate { get; set; }
    
    public Transaction() {}

    public Transaction(string id, string clientId, string operationName, DateTime signingDate, DateTime endDate)
    {
        Id = clientId;
        ClientId = clientId;
        OperationName = operationName;
        SigningDate = signingDate;
        EndDate = endDate;
    }
}

