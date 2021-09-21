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
    public class BookCategoriesRepository : IBookCategoriesRepository
    {
        private readonly NzsbhDbContext _dbContext;
        private readonly DbSet<BookCategory> _modelDbSets;

        public BookCategoriesRepository(NzsbhDbContext dbContext)
        {
            _dbContext = dbContext;
            _modelDbSets = _dbContext.Set<BookCategory>();
        }


        public async Task<BookCategory> GetBookCategoryAsync(Expression<Func<BookCategory, bool>> predicate)
        {
            return await _modelDbSets.Where(predicate).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<BookCategory>> GetListOfBookCategorysAsync()
        {
            return await _modelDbSets.ToListAsync();
        }
        public async Task<IEnumerable<BookCategory>> GetListOfBookCategorysAsync(Expression<Func<BookCategory, bool>> predicate)
        {
            return await _modelDbSets.Where(predicate).ToListAsync();
        }

        public void Add(BookCategory newBookCategory)
        {
            _modelDbSets.Add(newBookCategory);
        }

        public void Delete(Guid id)
        {
            var BookCategory = _modelDbSets.Find(id);
            _dbContext.Remove(BookCategory);
        }
        public void Update(BookCategory theBookCategory)
        {
            _modelDbSets.Attach(theBookCategory);
            _dbContext.Entry(theBookCategory).State = EntityState.Modified;
        }

        public async Task<int> SaveChangesAsync()
        {
            int i = await _dbContext.SaveChangesAsync();
            return i;
        }
    }
}
