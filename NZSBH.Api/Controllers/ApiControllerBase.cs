using MediatR;
using Microsoft.AspNetCore.Mvc;
using NZSBH.Api.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace NZSBH.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ApiControllerBase:ControllerBase
    {
        private readonly IMediator _mediator;

        private IActionResult StatusCodeAndMessage(HttpStatusCode statusCode, string message)
        {
            return StatusCode((int)statusCode, new string[] { message });
        }
        private IActionResult StatusCodeAndMessage(HttpStatusCode statusCode,IEnumerable<string> messages)
        {
            var dto = new ErrorMessageDto(statusCode, messages);
            return StatusCode(dto.StatusCode, dto);
        }
        public ApiControllerBase(IMediator mediator)
        {
            _mediator = mediator;
        }
        protected async Task<IActionResult> ExcuteRequest<T>(IRequest<T> request)
        {
            try
            {
                var result = await _mediator.Send(request);
                return Ok(result);
            }
            catch (ValidationException vex)
            {

                return StatusCodeAndMessage(HttpStatusCode.BadRequest, vex.Message);
            }
            catch(Exception ex)
            {
                return StatusCodeAndMessage(HttpStatusCode.InternalServerError, ex.Message);
            }
           
        }

        protected async Task<IActionResult> ExcuteRequest<T>(IRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
