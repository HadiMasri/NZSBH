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
    public class PublishersDxos : IPublishersDxos
    {
        private readonly IMapper _mapper;

        public PublishersDxos()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Publisher, PublisherDto>();
            });
            _mapper = config.CreateMapper();
        }
        public PublisherDto MapPublisherDto(Publisher Publisher)
        {

            return _mapper.Map<Publisher, PublisherDto>(Publisher);

        }

        public List<PublisherDto> MapPublisherDtos(IEnumerable<Publisher> Publishers)
        {
            return _mapper.Map<List<PublisherDto>>(Publishers);
        }
    }
}
