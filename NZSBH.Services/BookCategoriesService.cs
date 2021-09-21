using NZSBH.Application.Dxos;
using NZSBH.Contracts.Dtos;
using NZSBH.Models.Entities;
using NZSBH.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NZSBH.Services
{
    public class BookCategoriesService : IBookCategoriesService
    {
        private readonly IBookCategoriesRepository _repo;
        private readonly IBookCategoriesDxos _dxos;

        public BookCategoriesService(IBookCategoriesRepository repo, IBookCategoriesDxos dxos)
        {
            _repo = repo;
            _dxos = dxos;
        }
        public async Task<IEnumerable<BookCategoryDto>> GetAll()
        {
            var data = await _repo.GetListOfBookCategorysAsync();
            return _dxos.MapBookCategoryDtos(data);
        }

        public async Task<BookCategoryDto> GetOneById(Guid id)
        {
            var BookCategory = await _repo.GetBookCategoryAsync(s => s.Id == id);
            return _dxos.MapBookCategoryDto(BookCategory);
        }

        public async Task<bool> DeleteById(Guid id)
        {
            var BookCategory = await _repo.GetBookCategoryAsync(b => b.Id == id);
            if (BookCategory == null) throw new Exception("Not Found");
           

            _repo.Update(BookCategory);

            int i = await _repo.SaveChangesAsync();

            return i > 0;
            //_repo.Delete(id);
            //_repo.SaveChangesAsync();
        }

        public async Task<BookCategoryDto> Add(BookCategoryDto newBookCategory)
        {
            BookCategory b = new BookCategory();
            b.Title = newBookCategory.Title;
            b.Description = newBookCategory.Description;

            _repo.Add(b);
            await _repo.SaveChangesAsync();
            return _dxos.MapBookCategoryDto(b);
        }

    }
}
