namespace E_PortfolioSystem.Web.ViewModels.Home
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        public string Message { get; set; }
    }
}
