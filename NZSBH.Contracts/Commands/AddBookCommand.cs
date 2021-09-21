using FluentValidation;
using NZSBH.Contracts.Dtos;
using NZSBH.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NZSBH.Contracts
{
    public class AddBookCommandValidator: AbstractValidator<AddBookCommand>
    {
        public AddBookCommandValidator()
        {
            //Include(baseRequestValidators);
            RuleFor(x => x.Title).NotEmpty();
        }
    }
    public class AddBookCommand : CommandBase<BookDto>
    {
        public string Title { get; set; }
        public string Isbn { get; set; }
        public bool IsHardCover { get; set; }
    }
}
