using MediatR;
using NZSBH.Application.Dxos;
using NZSBH.Contracts;
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
    public class AddBookCommandHandler : IRequestHandler<AddBookCommand, BookDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBooksDxos _dxos;

        public AddBookCommandHandler(IUnitOfWork unitOfWork, IBooksDxos dxos)
        {
            _unitOfWork = unitOfWork;
            _dxos = dxos;
        }

        public async Task<BookDto> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            Book b = new Book();
            b.Title = request.Title;
            b.Isbn = request.Isbn;
            b.IsHardCover = request.IsHardCover;
            _unitOfWork.BookRepository.Add(b);
            _unitOfWork.Commit();
            return  _dxos.MapBookDto(b);
        }


    }
}
