using NZSBH.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NZSBH.Repositories
{
    public interface IPublishersRepository
    {
        void Add(Publisher newPublisher);
        Task<Publisher> GetPublisherAsync(Expression<Func<Publisher, bool>> predicate);
        Task<IEnumerable<Publisher>> GetListOfPublishersAsync();

        Task<IEnumerable<Publisher>> GetListOfPublishersAsync(Expression<Func<Publisher, bool>> predicate = null);
        void Delete(Guid id);
        Task<int> SaveChangesAsync();
        void Update(Publisher thePublisher);
    }
}
