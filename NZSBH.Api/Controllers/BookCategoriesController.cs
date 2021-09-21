using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZSBH.Application.Dxos;
using NZSBH.Contracts.Dtos;
using NZSBH.Contracts.Queries;
using NZSBH.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NZSBH.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookCategoriesController : ApiControllerBase
    {
        //private readonly IBookCategoriesService _BookCategoriesService;
        //private readonly IBookCategoriesDxos _BookCategoriesDxos;


        public BookCategoriesController(IMediator mediator)
            :base(mediator)
        {
            //_BookCategoriesService = BookCategoriesService;
            //_BookCategoriesDxos = BookCategoriesDxos;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return await ExcuteRequest(new GetAllBookCategoriesQuery());
        }
        //[HttpGet]
        //public async Task<IActionResult> Get()
        //{
        //    var BookCategorys = await _BookCategoriesService.GetAll();
        //    return Ok(BookCategorys);
        //}

        //[HttpGet("{id}")]
        //public async Task<IActionResult> Get(Guid id)
        //{
        //    var BookCategory = await _BookCategoriesService.GetOneById(id);
        //    return Ok(BookCategory);
        //}
        //[HttpPost]
        //public async Task<BookCategoryDto> Post(BookCategoryDto BookCategoryDto)
        //{
        //    return await _BookCategoriesService.Add(BookCategoryDto);

        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(Guid id)
        //{
        //    try
        //    {
        //        bool isDeleted = await _BookCategoriesService.DeleteById(id);
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
