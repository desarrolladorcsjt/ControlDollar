using ControlDolarPeru.Domain.HistoricalAverageAggregate.Application.Interface;
using ControlDolarPeru.Domain.HistoricalAverageAggregate.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDolarPeru.Domain.HistoricalAverageAggregate.Application
{
    public class HistoricalAverageAggregate: IHistoricalAverageAggregate
    {
        private readonly IHistoricalAverageRepository _repository;
        public HistoricalAverageAggregate(IHistoricalAverageRepository repository) { 
        _repository = repository;
        }
        public void Create(List<FinancialEntity> command)
        {
            if (command == null) { return; }
            foreach ( var item in command)
            {
                if(item == command.Last()) { _repository.CompleteTransaction = true; }
                var historicalDetail = new HistoricalAverage(item.IdProvider, item.PucharsePrice, item.SalePrice, 0);
                _repository.Create(historicalDetail);
            }
        }
    }
}
