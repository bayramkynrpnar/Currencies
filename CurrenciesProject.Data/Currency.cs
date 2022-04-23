using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CurrenciesProject.Data
{
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, TypeName = "Tarih_DateCurrency")]
    public partial class Currency
    {
        public int CurrencyId { get; set; }
        public string ForexSelling { get; set; }
        [XmlAttribute()]
        public string? CurrencyCode { get; set; }
        public Dates DatesModel { get; set; }
        public string Date { get; set; }
    }

}
