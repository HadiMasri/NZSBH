using NZSBH.Application.Dxos;
using NZSBH.Contracts.Dtos;
using NZSBH.Models.Entities;
using NZSBH.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NZSBH.Services
{
    public class PublishersService : IPublishersService
    {
        private readonly IPublishersRepository _repo;
        private readonly IPublishersDxos _dxos;

        public PublishersService(IPublishersRepository repo, IPublishersDxos dxos)
        {
            _repo = repo;
            _dxos = dxos;
        }

        public async Task<PublisherDto> GetOneById(Guid id)
        {
            var Publisher = await _repo.GetPublisherAsync(s => s.Id == id);
            return _dxos.MapPublisherDto(Publisher);
        }

        public async Task<bool> DeleteById(Guid id)
        {
            var book = await _repo.GetPublisherAsync(b => b.Id == id && b.IsDelete == false);
            if (book == null) throw new Exception("Not Found");
            book.Delete();

            _repo.Update(book);

            int i = await _repo.SaveChangesAsync();

            return i > 0;
            //_repo.Delete(id);
            //_repo.SaveChangesAsync();
        }

        public async Task<PublisherDto> Add(PublisherDto newPublisher)
        {
            Publisher b = new Publisher();
            b.Title = newPublisher.Title;
            b.Description = newPublisher.Description;
            b.Telephone = newPublisher.Telephone;

            _repo.Add(b);
            await _repo.SaveChangesAsync();
            return _dxos.MapPublisherDto(b);
        }

        public async Task<IEnumerable<PublisherDto>> GetAll()
        {
            var data = await _repo.GetListOfPublishersAsync(b => b.IsDelete == false);
            return _dxos.MapPublisherDtos(data);
        }
    }
}
