using NZSBH.Application.Dxos;
using NZSBH.Contracts.Dtos;
using NZSBH.Models.Entities;
using NZSBH.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NZSBH.Services
{
    public class BooksService : IBooksService
    {
        private readonly IRepository<Book> _repo;
        private readonly IBooksDxos _dxos;

        public BooksService(IRepository<Book> repo, IBooksDxos dxos)
        {
            _repo = repo;
            _dxos = dxos;
        }
        public async Task<IEnumerable<BookDto>> GetAll(int pageNumber, int pageSize)
        {
            var data = await _repo.GetListAsync(b => b.IsDelete == false);
      
            return _dxos.MapBookDtos(data);
        }

        public async Task<BookDto> GetOneById(Guid id)
        {
            var book = await _repo.GetAsync(s => s.Id == id);
            return _dxos.MapBookDto(book);
        }

        public async Task<bool> DeleteById(Guid id)
        {
            var book = await _repo.GetAsync(b => b.Id == id && b.IsDelete == false);
            if (book == null) throw new Exception("Not Found");
            book.Delete();

            _repo.Update(book);

            int i = await _repo.SaveChangesAsync();

            return i > 0;
            //_repo.Delete(id);
            //_repo.SaveChangesAsync();
        }

        public async Task<BookDto> Add(BookDto newBook)
        {
            Book b = new Book();
            b.Title = newBook.Title;
            b.Isbn = newBook.Isbn;
            b.IsHardCover = newBook.IsHardCover;
            _repo.Add(b);
            await _repo.SaveChangesAsync();
            return _dxos.MapBookDto(b);
        }

        public async Task<BookDto> Update(BookDto bookDto)
        {
            var book = await _repo.GetAsync(b => b.Id == bookDto.Id && b.IsDelete == false);
            if (book == null) throw new ApplicationException("not Found");
            {
                book.Update(bookDto.Title, bookDto.Isbn, bookDto.IsHardCover, book.PublisherId, bookDto.CategoryId);
                _repo.Update(book);
                int i = await _repo.SaveChangesAsync();
                return _dxos.MapBookDto(book);
            }
        }


    }
}
