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
    public class GetBookQueryHandler : IRequestHandler<GetBookQuery, BookDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBooksDxos _dxos;

        public GetBookQueryHandler(IUnitOfWork unitOfWork, IBooksDxos dxos)
        {
            _unitOfWork = unitOfWork;
            _dxos = dxos;
        }
        public async Task<BookDto> Handle(GetBookQuery request, CancellationToken cancellationToken)
        {
            var book = await _unitOfWork.BookRepository.GetAsync(s => s.Id == request.Id);
            return _dxos.MapBookDto(book);
        }
    }
}
