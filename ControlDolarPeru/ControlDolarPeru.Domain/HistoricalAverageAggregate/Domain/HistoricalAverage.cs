using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDolarPeru.Domain.HistoricalAverageAggregate.Domain
{
    public class HistoricalAverage
    {
        public Guid Id { get; private set; }
        public int IdProvider { get; private set; }
        public decimal PurchasePrice { get; private set; }
        public decimal SalePrice { get;private set; }
        public decimal Average { get;private set; }
        public DateTime CreateDateTime { get; private set; }
        public HistoricalAverage() { }
        public HistoricalAverage(int idprovider,decimal purchasePrice,decimal salePrice,decimal average)
        {
            Id = Guid.NewGuid();
            IdProvider = idprovider;
            PurchasePrice = purchasePrice;
            SalePrice = salePrice;
            Average = average;
            CreateDateTime = DateTime.Now;
        }

    }
}
