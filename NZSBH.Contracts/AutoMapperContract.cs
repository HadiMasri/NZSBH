using AutoMapper;
using NZSBH.Contracts.Dtos;
using NZSBH.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NZSBH.Contracts
{
    public class AutoMapperContract
    {
        public static Book MapToEntity(BookDto bookDTo)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<BookDto, Book>();
            });
            IMapper iMapper = config.CreateMapper();
            
            var destination = iMapper.Map<BookDto, Book>(bookDTo);

            return destination;
        }
    }
}
