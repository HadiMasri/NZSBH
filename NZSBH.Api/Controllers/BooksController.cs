using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZSBH.Application.Dxos;
using NZSBH.Contracts;
using NZSBH.Contracts.Commands;
using NZSBH.Contracts.Dtos;
using NZSBH.Contracts.Queries;
using NZSBH.Models.Entities;
using NZSBH.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NZSBH.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class BooksController : ApiControllerBase
    {
        //private readonly IBooksService _booksService;
        //private readonly IBooksDxos _booksDxos;


        public BooksController(IMediator mediator)
            :base(mediator)
        {
        
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return await ExcuteRequest(new GetAllBooksQuery());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return await ExcuteRequest(new GetBookQuery{ Id = id});

        }
        [HttpPost]
        public async Task<IActionResult> Post(AddBookCommand cmd)
        {
            if (cmd == null) return BadRequest();

            return await ExcuteRequest(cmd);
        }

        [HttpPut]
        public async Task<IActionResult> Update(BookDto bookDto)
        {
            return await ExcuteRequest(new UpdateBookCommand { BookDto = bookDto });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return await ExcuteRequest(new DeleteBookCommand { Id = id });

        }


        //[HttpGet]
        //public async Task<IActionResult> Get([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        //{
        //    var books = await _booksService.GetAll(pageNumber, pageSize);
        //    return Ok(books);
        //}

        //[HttpGet("{id}")]
        //public async Task<IActionResult> Get(Guid id)
        //{
        //    var book = await _booksService.GetOneById(id);
        //    return Ok(book);
        //}
        //[HttpPost] 
        //public async Task<IActionResult> Post(BookDto bookDto)
        //{
        //    var bto = await _booksService.Add(bookDto);
        //    return CreatedAtAction("post", bto);   
        //}

        //[HttpPut]
        //public async Task<IActionResult> Update(BookDto bookDto)
        //{
        //    var bto = await _booksService.Add(bookDto);
        //    return Ok(bto);

        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(Guid id)
        //{
        //    try
        //    {
        //        bool isDeleted =  await _booksService.DeleteById(id);
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