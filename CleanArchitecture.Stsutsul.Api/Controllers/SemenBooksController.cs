using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Stsutsul.Application.Commands.AddBookToSemen;
using CleanArchitecture.Stsutsul.Application.Commands.GetAllBooksByName;
using CleanArchitecture.Stsutsul.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Stsutsul.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SemenBooksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SemenBooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("books/{name}")]
        public async Task<ICollection<BookModel>> GetAllBooks(string name, CancellationToken cancellationToken)
        {
            var books = await _mediator.Send(new GetAllBooksByNameQuery(name), cancellationToken);

            return books;
        }

        /// <summary>
        /// Test comment
        /// </summary>
        /// <param name="semenName"></param>
        /// <param name="bookName"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("books/{semenName}")]
        public Task AddBookToSemen(string semenName, [FromQuery] string bookName, CancellationToken cancellationToken)
        {
            return _mediator.Send(new AddBookToSemenCommand(semenName, bookName), cancellationToken);
        }
    }
}