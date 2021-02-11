using System.Collections.Generic;
using CleanArchitecture.Stsutsul.Application.Models;
using MediatR;

namespace CleanArchitecture.Stsutsul.Application.Commands.GetAllBooksByName
{
    public class GetAllBooksByNameQuery : IRequest<ICollection<BookModel>>
    {
        public GetAllBooksByNameQuery(string semenName)
        {
            SemenName = semenName;
        }

        public string SemenName { get; }
    }
}