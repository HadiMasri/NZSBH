using MediatR;
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
    class GetAllPublishersQueryHandlers : IRequestHandler<GetAllPublishersQuery, IEnumerable<PublisherDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPublishersDxos _dxos;

        public GetAllPublishersQueryHandlers(IUnitOfWork unitOfWork, IPublishersDxos dxos)
        {
            _unitOfWork = unitOfWork;
            _dxos = dxos;
        }
        public async Task<IEnumerable<PublisherDto>> Handle(GetAllPublishersQuery request, CancellationToken cancellationToken)
        {
            var data = await _unitOfWork.PublisherRepository.GetListAsync(b => b.IsDelete == false);
            return _dxos.MapPublisherDtos(data);
        }
    }
}
