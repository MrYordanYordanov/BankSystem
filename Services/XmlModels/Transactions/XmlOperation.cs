using System.Xml.Serialization;

namespace Services.XmlModels.Transactions;

[XmlRoot("Operation")]
public class XmlOperation
{
    [XmlArray("Transactions")]
    [XmlArrayItem("Transaction")]
    public List<XmlTransaction> Transactions { get; set; }
}