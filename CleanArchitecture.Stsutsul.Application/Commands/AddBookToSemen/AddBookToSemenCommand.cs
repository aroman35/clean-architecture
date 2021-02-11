using MediatR;

namespace CleanArchitecture.Stsutsul.Application.Commands.AddBookToSemen
{
    public class AddBookToSemenCommand : IRequest
    {
        public AddBookToSemenCommand(string semenName, string bookName)
        {
            SemenName = semenName;
            BookName = bookName;
        }

        public string SemenName { get; }
        public string BookName { get; }
    }
}