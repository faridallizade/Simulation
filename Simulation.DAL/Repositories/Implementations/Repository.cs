using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Simulation.CORE.Entities;
using Simulation.CORE.Entities.Base;
using Simulation.DAL.Context;
using Simulation.DAL.Repositories.Interfaces;

namespace Simulation.DAL.Repositories.Implementations
{
    public class Repository<T> : IRepository<T> where T : BaseAudiTableEntity, new()
    {
        private readonly AppDbContext _context;
        public Repository(AppDbContext context)
        {
            _context = context;
        }
        public DbSet<T> Table => _context.Set<T>(); 
        public bool Check(int id)
        {
            if (Table.Any(x => x.Id == id && x.IsDeleted == false)) return true; return false;
        }

        public async Task Create(T entity)
        {
            await Table.AddAsync(entity);
        }

        public void Delete(int id)
        {
            if(Table.Any(x=>x.Id == id && x.IsDeleted == false)){
                var entity = Table.FirstOrDefault(x => x.Id == id);
                if(entity != null)
                {
                    entity.IsDeleted = true;
                }
                SaveChanges();
            }
            throw new Exception("Not found");
        }

        public async Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>>? expression = null, params string[] includes)
        {
            IQueryable<T> query = Table.Where(b => !b.IsDeleted);
            if(includes is not null)
            {
                for(int i = 0; i<includes.Length; i++)
                {
                    query = query.Include(includes[i]);
                }
            }
            if(expression is not null)
            {
                query = query.Where(expression);
            }
            return query;
        }

        public async Task<T> GetById(int id)
        {
            if (Check(id))
            {
                return await Table.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            }
            throw new Exception("Not found");
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            Table.Update(entity); 
        }
    }
}
