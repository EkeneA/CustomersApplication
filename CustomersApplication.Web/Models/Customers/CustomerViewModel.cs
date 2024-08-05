namespace CustomersApplication.Web.Models.Customers
{
    public sealed class CustomerViewModel
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public string? Email { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public string? Address { get; set; }
    }
}
