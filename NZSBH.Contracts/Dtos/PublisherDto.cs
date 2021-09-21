using NZSBH.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NZSBH.Contracts.Dtos
{
    public class PublisherDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Telephone { get; set; }
        //public bool IsActive { get; set; }

        //public IEnumerable<Book> Books { get; set; }

        public static PublisherDto MapToDto(Publisher p)
        {
            PublisherDto dto = new PublisherDto()
            {
                Id = p.Id,
                Title = p.Title,
                Description = p.Description,
                Telephone = p.Telephone
            };
            return dto;
        }

        public static IEnumerable<PublisherDto> MapToDtos(IEnumerable<Publisher> publishers)
        {
            List<PublisherDto> publisheDtos = new List<PublisherDto>();
            foreach (Publisher p in publishers)
            {
                publisheDtos.Add(MapToDto(p));
            }

            return publisheDtos;
        }
    }
}
