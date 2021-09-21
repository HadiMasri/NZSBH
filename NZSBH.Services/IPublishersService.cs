using NZSBH.Contracts.Dtos;
using NZSBH.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NZSBH.Services
{
    public interface IPublishersService
    {
        Task<IEnumerable<PublisherDto>> GetAll();
        Task<PublisherDto> Add(PublisherDto newPublisher);
        Task<PublisherDto> GetOneById(Guid id);
        Task<bool> DeleteById(Guid id);
    }
}
