namespace ServerPOSApplication.Models
{
    public class Discount
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; } // "Percentage" or "FixedAmount"
        public int Value { get; set; }
    }
}
