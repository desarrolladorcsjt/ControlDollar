using ControlDolarPeru.Domain.HistoricalAverageAggregate.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDolarPeru.Domain.HistoricalAverageAggregate.Application.Interface
{
    public interface IHistoricalAverageRepository
    {
        bool CompleteTransaction { get; set; } 
        void Create(HistoricalAverage command);
    }
}
