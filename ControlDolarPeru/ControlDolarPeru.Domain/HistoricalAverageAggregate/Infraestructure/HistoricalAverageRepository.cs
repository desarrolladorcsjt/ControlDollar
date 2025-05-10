using ControlDolarPeru.Domain.EF;
using ControlDolarPeru.Domain.HistoricalAverageAggregate.Application.Interface;
using ControlDolarPeru.Domain.HistoricalAverageAggregate.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDolarPeru.Domain.HistoricalAverageAggregate.Infraestructure
{
    public class HistoricalAverageRepository : IHistoricalAverageRepository
    {
        private readonly DollarContext _context; 
        public bool CompleteTransaction { get; set; } = false;
        public HistoricalAverageRepository(DollarContext context)
        {
            _context = context;
        }
        public void Create(HistoricalAverage command)
        {
            if(command != null)
            {
                _context.HistoricalAverages.Add(command);
                if (CompleteTransaction)
                {
                    _context.SaveChanges();
                }
            } 
        }

    }
}
