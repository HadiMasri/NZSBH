using MediatR;
using Microsoft.Extensions.Caching.Memory;
using NZSBH.Application.Dxos;
using NZSBH.Contracts.Dtos;
using NZSBH.Contracts.Queries;
using NZSBH.Models.Entities;
using NZSBH.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NZSBH.Application.QueryHandlers
{
    public class GetAllBooksQueryHandlers : IRequestHandler<GetAllBooksQuery, IEnumerable<BookDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBooksDxos _dxos;
        private readonly IMemoryCache _memoryCache;

        public GetAllBooksQueryHandlers(IUnitOfWork unitOfWork, IBooksDxos dxos, IMemoryCache memoryCache)
        {
            _unitOfWork = unitOfWork;
            _dxos = dxos;
            _memoryCache = memoryCache;
        }
        public async Task<IEnumerable<BookDto>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            var cacheEntry = _memoryCache.GetOrCreateAsync("books", async entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10);
                var data = await _unitOfWork.BookRepository.GetListAsync(b => b.IsDelete == false);
                var dxos = _dxos.MapBookDtos(data);
                return dxos;
            });
            return await cacheEntry;
        }
    }
}
