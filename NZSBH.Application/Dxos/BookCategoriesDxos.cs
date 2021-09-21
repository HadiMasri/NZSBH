using AutoMapper;
using NZSBH.Contracts.Dtos;
using NZSBH.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NZSBH.Application.Dxos
{
    public class BookCategoriesDxos : IBookCategoriesDxos
    {
        private readonly IMapper _mapper;

        public BookCategoriesDxos()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<BookCategory, BookCategoryDto>();
            });
            _mapper = config.CreateMapper();
        }
        public BookCategoryDto MapBookCategoryDto(BookCategory BookCategory)
        {

            return _mapper.Map<BookCategory, BookCategoryDto>(BookCategory);

        }

        public List<BookCategoryDto> MapBookCategoryDtos(IEnumerable<BookCategory> BookCategorys)
        {
            return _mapper.Map<List<BookCategoryDto>>(BookCategorys);
        }
    }
}
