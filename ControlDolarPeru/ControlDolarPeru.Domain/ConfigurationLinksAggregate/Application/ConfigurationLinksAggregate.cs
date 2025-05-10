using ControlDolarPeru.Domain.ConfigurationLinksAggregate.Application.DTO;
using ControlDolarPeru.Domain.ConfigurationLinksAggregate.Application.Interface;
using ControlDolarPeru.Domain.ConfigurationLinksAggregate.Domain;
using ControlDolarPeru.Domain.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDolarPeru.Domain.ConfigurationLinksAggregate.Application
{
    public  class ConfigurationLinksAggregate : IConfigurationLinksAggregate
    {
        private readonly IConfigurationLinksRepository _repository;
        public ConfigurationLinksAggregate(IConfigurationLinksRepository repository) {
        _repository= repository;
        }
        public List<ConfigurationLinksResponseDTO> Get()
        {
            var response = _repository.Get();
            return response;
        }
    }
}
