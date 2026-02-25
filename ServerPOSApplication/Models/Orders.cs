namespace ServerPOSApplication.Models
{
    public class Orders
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int MenuItemId { get; set; }
        public int DiscountId { get; set; }
        public int TaxId { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
