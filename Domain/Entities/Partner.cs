namespace Domain.Entities;

public class Partner
{
    public int Id { get; set; }

    public string Name { get; set; }

    public ICollection<Merchant> Merchants { get; set; } = new List<Merchant>();
}
