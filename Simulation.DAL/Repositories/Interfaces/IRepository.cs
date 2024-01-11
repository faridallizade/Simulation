using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Simulation.CORE.Entities;
using Simulation.CORE.Entities.Base;

namespace Simulation.DAL.Repositories.Interfaces
{
    public interface IRepository<T> where T : BaseAudiTableEntity, new()
    {
        DbSet<T> Table {  get; }
        Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>>? expression = null, params string[] includes);
        Task<T> GetById(int id);
        Task Create(T entity);
        void Update(T entity);
        void Delete(int id);
        bool Check(int id);
        void SaveChanges();


    }
}
