using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDolarPeru.Domain.ConfigurationLinksAggregate.Domain
{
    public class ConfigurationLinks
    {
        public Guid IdConfiguration { get; set; }
        public int IdProvider { get; set; }
        public string Link { get; set; }
        public string PurchaseValuePath { get; set; }
        public string SaleValuePath { get; set; }
        public bool State { get; set; } = true;
    }
}
