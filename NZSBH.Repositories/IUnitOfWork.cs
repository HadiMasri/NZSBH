using NZSBH.Models.Entities;
using System.Threading.Tasks;

namespace NZSBH.Repositories
{
    public interface IUnitOfWork
    {
        IRepository<BookCategory> BookCategoryRepository { get; }
        IRepository<Book> BookRepository { get; }
        IRepository<Publisher> PublisherRepository { get; }

        void Commit();
        void Rollback();
    }
}