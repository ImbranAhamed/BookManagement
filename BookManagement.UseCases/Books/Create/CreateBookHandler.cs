using BookManagement.Core.Interfaces;
using BookManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookManagement.UseCases.Books.Create
{
    public class CreateBookHandler
    {
        private readonly IBookRepository _repository;

        public CreateBookHandler(IBookRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CreateBookCommand command)
        {
            Book book = new Book()
            {
                Title = command.Title,
                Author = command.Author,
                Isbn = command.ISBN,
                Price = command.Price,
                PublishedDate = command.PublishedDate,
            };

            await _repository.AddAsync(book);

            return book.BookId;
        }
    }
}
