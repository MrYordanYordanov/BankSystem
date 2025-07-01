namespace Domain.Entities;

public class Merchant
{
    public int Id { get; set; }

    public string Name { get; set; }

    public DateTime BoardingDate { get; set; }

    public string Url { get; set; }

    public string Country { get; set; }

    public string Address_1 { get; set; }

    public string Address_2 { get; set; }

    public int PartnerId { get; set; }

    public Partner Partner { get; set; }

    public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}