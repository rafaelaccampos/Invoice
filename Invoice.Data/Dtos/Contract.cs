namespace Invoice.Data.Dtos
{
    public class Contract
    {
        public Guid Id { get; set; }

        public string Description { get; set; } = null!;
        
        public decimal Amount { get; set; }
        
        public int Periods { get; set; }
        
        public DateTime Date { get; set; }

        public ICollection<Payment> Payments { get; set; } = null!;
    }
}