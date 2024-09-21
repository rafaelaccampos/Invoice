namespace Invoice.Data.Dtos
{
    public class Payment
    {
        public Guid Id { get; set; }

        public Contract Contract { get; set; } = null!;

        public decimal Amount { get; set; }

        public DateTime Date { get; set; }
    }
}
