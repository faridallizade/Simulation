using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulation.BUSINESS.ViewModels;
using Simulation.CORE.Entities;

namespace Simulation.BUSINESS.Services.Interfaces
{
    public interface IFeatureService
    {
        Task<IQueryable<Features>> GetAllAsync();
        Task<Features> GetById(int id);
        Task Create(CreateFeatureVM createFeatureVM);
        Task Update(UpdateFeatureVM updateFeatureVM);
        Task Delete(int id);
    }
}
