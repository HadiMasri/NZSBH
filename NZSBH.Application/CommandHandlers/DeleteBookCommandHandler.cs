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
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, BookDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBooksDxos _dxos;

        public DeleteBookCommandHandler(IUnitOfWork unitOfWork, IBooksDxos dxos)
        {
            IUnitOfWork unitOfWork1 = unitOfWork;
            _unitOfWork = unitOfWork1;
            _dxos = dxos;
        }


        public async Task<BookDto> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _unitOfWork.BookRepository.GetAsync(b => b.Id == request.Id && b.IsDelete == false);
            if (book == null) throw new Exception("Not Found");
            book.Delete();
            _unitOfWork.BookRepository.Update(book);
             _unitOfWork.Commit();
            return _dxos.MapBookDto(book);
        }
    }
}
