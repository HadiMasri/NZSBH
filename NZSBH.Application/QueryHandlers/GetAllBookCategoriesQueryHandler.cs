using MediatR;
using NZSBH.Application.Dxos;
using NZSBH.Contracts.Dtos;
using NZSBH.Contracts.Queries;
using NZSBH.Models.Entities;
using NZSBH.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NZSBH.Application.QueryHandlers
{
    public class GetAllBookCategoriesQueryHandler : IRequestHandler<GetAllBookCategoriesQuery, IEnumerable<BookCategoryDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBookCategoriesDxos _dxos;

        public GetAllBookCategoriesQueryHandler(IUnitOfWork unitOfWork, IBookCategoriesDxos dxos)
        {
            _unitOfWork = unitOfWork;
            _dxos = dxos;
        }
        public async Task<IEnumerable<BookCategoryDto>> Handle(GetAllBookCategoriesQuery request, CancellationToken cancellationToken)
        {
            var data = await _unitOfWork.BookCategoryRepository.GetListAsync();
            return _dxos.MapBookCategoryDtos(data);
        }
    }
}
