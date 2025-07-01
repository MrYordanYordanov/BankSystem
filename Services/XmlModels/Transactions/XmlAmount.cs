using System.Xml.Serialization;

namespace Services.XmlModels.Transactions;

public class XmlAmount
{
    public string Direction { get; set; }


    [XmlElement("Value")]
    public decimal Value { get; set; }

    public string Currency { get; set; }
}