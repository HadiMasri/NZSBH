using NZSBH.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NZSBH.Services
{
    public interface IBookCategoriesService
    {
        Task<BookCategoryDto> Add(BookCategoryDto newBookCategory);
        Task<IEnumerable<BookCategoryDto>> GetAll();
        Task<BookCategoryDto> GetOneById(Guid id);
        Task<bool> DeleteById(Guid id);
    }
}
