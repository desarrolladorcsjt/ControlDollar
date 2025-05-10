using ControlDolarPeru.Domain.ConfigurationLinksAggregate.Application.DTO;
using ControlDolarPeru.Domain.ConfigurationLinksAggregate.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDolarPeru.Domain.ConfigurationLinksAggregate.Application.Interface
{
    public interface IConfigurationLinksAggregate
    {
        List<ConfigurationLinksResponseDTO> Get();
    }
}
