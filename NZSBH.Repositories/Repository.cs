using Microsoft.EntityFrameworkCore;
using NZSBH.Data;
using NZSBH.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NZSBH.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly NzsbhDbContext _dbContext;
        private readonly DbSet<T> _modelDbSets;

        public Repository(NzsbhDbContext dbContext)
        {
            _dbContext = dbContext;
            _modelDbSets = dbContext.Set<T>();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _modelDbSets.Where(predicate).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetListAsync()
        {
            return await _modelDbSets.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> predicate)
        {
    
            return await _modelDbSets.Where(predicate).ToListAsync();
        }
        
        public void Add(T entity)
        {
             _modelDbSets.Add(entity);
        }

        public void Delete(Guid id)
        {
            var entity = _modelDbSets.Find(id);
            _dbContext.Remove(entity);
        }
        public void Update(T entity)
        {
            try
            {
                _modelDbSets.Attach(entity);
                _dbContext.Entry(entity).State = EntityState.Modified;
            }
            catch (Exception)
            {

                throw;
            }
   
        }

        public async Task<int> SaveChangesAsync()
        {
            
            int i = await _dbContext.SaveChangesAsync();
            return i;
        }
    }
}
