using NZSBH.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NZSBH.Contracts.Commands
{
    public class DeleteBookCommand : CommandBase<BookDto>
    {
        public Guid Id { get; set; }
    }
}
