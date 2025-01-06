namespace Invoice.Domain;

public class ContractInput
{
    public int Month { get; set; }

    public int Year { get; set; }

    public required string Type { get; set; }
}
