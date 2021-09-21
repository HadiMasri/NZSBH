using NZSBH.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NZSBH.Repositories
{
    public interface IBookCategoriesRepository
    {
        void Add(BookCategory newBookCategory);
        Task<BookCategory> GetBookCategoryAsync(Expression<Func<BookCategory, bool>> predicate);
        Task<IEnumerable<BookCategory>> GetListOfBookCategorysAsync();

        Task<IEnumerable<BookCategory>> GetListOfBookCategorysAsync(Expression<Func<BookCategory, bool>> predicate = null);
        void Delete(Guid id);
        Task<int> SaveChangesAsync();
        void Update(BookCategory theBookCategory);
    }
}
