using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulation.BUSINESS.Services.Interfaces;
using Simulation.BUSINESS.ViewModels;
using Simulation.CORE.Entities;
using Simulation.DAL.Repositories.Interfaces;

namespace Simulation.BUSINESS.Services.Implementations
{
    public class FeatureService : IFeatureService   
    {
        private readonly IFeatureRepository _repo;
        public async Task Create(CreateFeatureVM createFeatureVM)
        {
            Features feature = new Features();
            await _repo.Create(feature);   
            _repo.SaveChanges();
        }

        public async Task Delete(int id)
        {
            _repo.Delete(id);
        }

        public async Task<IQueryable<Features>> GetAllAsync()
        {
            var features = _repo.GetAllAsync();
            return await features;
        }

        public async Task<Features> GetById(int id)
        {
            if (id < 0) throw new Exception("Invalid Id");
            return await _repo.GetById(id);
        }

        public async Task Update(UpdateFeatureVM updateFeatureVM)
        {
            if (updateFeatureVM != null && _repo.Check(updateFeatureVM.Id)){

                var existingFeature = await _repo.GetById(updateFeatureVM.Id);
                existingFeature.Title = updateFeatureVM.Title;
                existingFeature.Description = updateFeatureVM.Description;
                existingFeature.Icon = updateFeatureVM.Icon;
                existingFeature = await _repo.GetById(updateFeatureVM.Id);
                existingFeature.IsDeleted = false;
                _repo.Update(existingFeature);
                _repo.SaveChanges();
            }
        }
    }
}
