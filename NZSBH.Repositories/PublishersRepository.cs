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
    public class PublishersRepository : IPublishersRepository
    {
        private readonly NzsbhDbContext _dbContext;
        private readonly DbSet<Publisher> _modelDbSets;

        public PublishersRepository(NzsbhDbContext dbContext)
        {
            _dbContext = dbContext;
            _modelDbSets = _dbContext.Set<Publisher>();
        }


        public async Task<Publisher> GetPublisherAsync(Expression<Func<Publisher, bool>> predicate)
        {
            return await _modelDbSets.Where(predicate).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Publisher>> GetListOfPublishersAsync()
        {
            return await _modelDbSets.ToListAsync();

        }
        public async Task<IEnumerable<Publisher>> GetListOfPublishersAsync(Expression<Func<Publisher, bool>> predicate)
        {
            return await _modelDbSets.Where(predicate).ToListAsync();

        }

        public void Add(Publisher newPublisher)
        {
            _modelDbSets.Add(newPublisher);
        }

        public void Delete(Guid id)
        {
            var Publisher = _modelDbSets.Find(id);
            _dbContext.Remove(Publisher);
        }
        public void Update(Publisher thePublisher)
        {
            _modelDbSets.Attach(thePublisher);
            _dbContext.Entry(thePublisher).State = EntityState.Modified;
        }

        public async Task<int> SaveChangesAsync()
        {
            int i = await _dbContext.SaveChangesAsync();
            return i;
        }
    }
}
