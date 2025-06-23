namespace CarRental.Core.Domain.Entities;

// Models/TgClient.cs
public class TgClient
{
    public string Id { get; set; }
    public string ClientId { get; set; }
    public string DialogStatus { get; set; }
    
    public TgClient() {}

    public TgClient(string id, string clientId, string dialogStatus)
    {
        Id = id;
        ClientId = clientId;
        DialogStatus = dialogStatus;
    }
}
