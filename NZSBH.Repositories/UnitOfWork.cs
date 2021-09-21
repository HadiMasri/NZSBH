using NZSBH.Data;
using NZSBH.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NZSBH.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly NzsbhDbContext _dbContext;
        private IRepository<Book> _bookRepository;
        public IRepository<Book> BookRepository
        {
            get
            {
                return _bookRepository = _bookRepository ?? new Repository<Book>(_dbContext);
            }
        }
        private IRepository<Publisher> _publisherRepository;
        public IRepository<Publisher> PublisherRepository
        {
            get
            {
                return _publisherRepository = _publisherRepository ?? new Repository<Publisher>(_dbContext);
            }
        }
        private IRepository<BookCategory> __bookCategoryRepository;

        public IRepository<BookCategory> BookCategoryRepository
        {
            get
            {
                return __bookCategoryRepository = __bookCategoryRepository ?? new Repository<BookCategory>(_dbContext);
            }
        }

        public UnitOfWork(NzsbhDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Commit()
        { 
            try
            {
                _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                string exf = ex.Message;
                throw;
            }
        }

  

        public void Rollback()
        {
            _dbContext.Dispose();
        }
    }
}
