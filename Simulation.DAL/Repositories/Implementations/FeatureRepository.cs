using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulation.CORE.Entities;
using Simulation.DAL.Context;
using Simulation.DAL.Repositories.Interfaces;

namespace Simulation.DAL.Repositories.Implementations
{
    public class FeatureRepository : Repository<Features>, IFeatureRepository
    {
        public FeatureRepository(AppDbContext context) : base(context)
        { }
    }
}
