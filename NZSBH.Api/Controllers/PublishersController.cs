using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using NZSBH.Models.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;
using NZSBH.Services;
using NZSBH.Contracts.Dtos;
using NZSBH.Application.Dxos;
using Microsoft.AspNetCore.Authorization;
using MediatR;
using NZSBH.Contracts.Queries;

namespace NZSBH.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ResponseCache(Duration = 120)]
    public class PublishersController : ApiControllerBase
    {
        //private readonly IPublishersService _PublishersService;
        //private readonly IPublishersDxos _PublishersDxos;


        public PublishersController(IMediator mediator)
            :base(mediator)
        {
          
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return await ExcuteRequest(new GetAllPublishersQuery());
        }

        //[HttpGet]
        //public async Task<IActionResult> Get()
        //{
        //    var Publishers = await _PublishersService.GetAll();
        //    return Ok(Publishers);
        //}

        //[HttpGet("{id}")]
        //public async Task<IActionResult> Get(Guid id)
        //{
        //    var Publisher = await _PublishersService.GetOneById(id);
        //    return Ok(Publisher);
        //}
        //[HttpPost]
        //public async Task<PublisherDto> Post(PublisherDto PublisherDto)
        //{
        //    return await _PublishersService.Add(PublisherDto);

        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(Guid id)
        //{
        //    try
        //    {
        //        bool isDeleted = await _PublishersService.DeleteById(id);
        //        if (isDeleted)
        //        {
        //            return NoContent();
        //        }
        //        else
        //        {
        //            return StatusCode(500);
        //        }
        //    }
        //    catch (ApplicationException)
        //    {

        //        return NotFound();
        //    }
        //}
    }
}
