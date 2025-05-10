using ControlDolarPeru.Domain.ConfigurationLinksAggregate.Application.DTO;
using ControlDolarPeru.Domain.ConfigurationLinksAggregate.Application.Interface;
using ControlDolarPeru.Domain.ConfigurationLinksAggregate.Domain;
using ControlDolarPeru.Domain.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDolarPeru.Domain.ConfigurationLinksAggregate.Infraestructure.SQLServer
{
    public class ConfigurationLinksRepository: IConfigurationLinksRepository
    {
        private readonly DollarContext _context;
        public ConfigurationLinksRepository(DollarContext context) {
        _context= context;
        }
        public List<ConfigurationLinksResponseDTO> Get()
        {
            var response = (from c in _context.ConfigurationLinks.Where(x=>x.State).OrderBy(x=>x.IdProvider)
                           select new ConfigurationLinksResponseDTO
                           {
                               IdProvider = c.IdProvider,
                               Link = c.Link,
                               PurchaseValuePath = c.PurchaseValuePath.Replace(@"\", @""),
                               SaleValuePath= c.SaleValuePath.Replace(@"\", @"")
                           }).ToList();
            return response;
        }
    }
}
