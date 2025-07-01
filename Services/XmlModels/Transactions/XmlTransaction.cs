using System.Xml.Serialization;

namespace Services.XmlModels.Transactions;

public class XmlTransaction
{
    public string ExternalId { get; set; }

    public DateTime CreateDate { get; set; }

    [XmlElement("Amount")]
    public XmlAmount Amount { get; set; }

    [XmlElement("Status")]
    public int Status { get; set; }

    [XmlElement("Debtor")]
    public XmlIban Debtor { get; set; }

    [XmlElement("Beneficiary")]
    public XmlIban Beneficiary { get; set; }
}
