using MediatR;
using NZSBH.Application.Dxos;
using NZSBH.Contracts.Commands;
using NZSBH.Contracts.Dtos;
using NZSBH.Models.Entities;
using NZSBH.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NZSBH.Application.CommandHandlers
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, BookDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBooksDxos _dxos;

        public UpdateBookCommandHandler(IUnitOfWork unitOfWork, IBooksDxos dxos)
        {
            _unitOfWork = unitOfWork;
            _dxos = dxos;
        }
        public async Task<BookDto> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _unitOfWork.BookRepository.GetAsync(b => b.Id == request.BookDto.Id && b.IsDelete == false);
            if (book == null) throw new ApplicationException("not Found");
            {
                book.Update(request.BookDto.Title, request.BookDto.Isbn, request.BookDto.IsHardCover, request.BookDto.PublisherId, request.BookDto.CategoryId);
                _unitOfWork.BookRepository.Update(book);
                _unitOfWork.Commit();
                return _dxos.MapBookDto(book);
            }
        }
    }
}
