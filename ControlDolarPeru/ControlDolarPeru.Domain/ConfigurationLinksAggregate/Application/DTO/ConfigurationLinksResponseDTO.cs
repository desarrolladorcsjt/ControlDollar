using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDolarPeru.Domain.ConfigurationLinksAggregate.Application.DTO
{
    public record ConfigurationLinksResponseDTO
    {
        public int IdProvider { get; init; }
        public string Link { get; init; }
        public string PurchaseValuePath { get; set; }
        public string SaleValuePath { get; set; }


    } 
}
