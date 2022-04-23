using CurrenciesProject.Data;
using System.Xml.Serialization;


[Serializable()]
[System.ComponentModel.DesignerCategory("code")]
[XmlType(AnonymousType = true, TypeName = "Tarih_Date")]
[XmlRoot(Namespace = "", IsNullable = false, ElementName = "Tarih_Date")]
public class Dates
{
    [XmlElement("Currency")]
    public List<Currency> Currency { get; set; }

    [XmlAttribute()]
    public string Date { get; set; }

}


