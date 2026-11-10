namespace AzureProject.Models
{
    // Simple model used to demonstrate the MVC data flow (Model -> Controller -> View).
    public record Product(int Id, string Name, decimal Price);

    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
