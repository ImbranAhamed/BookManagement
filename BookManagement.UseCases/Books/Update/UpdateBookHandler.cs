using BookManagement.Core.Interfaces;
using BookManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookManagement.UseCases.Books.Update
{
    public class UpdateBookHandler
    {
        private readonly IBookRepository _repository;

        public UpdateBookHandler(IBookRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(UpdateBookCommand command)
        {
            Book book = await _repository.GetByIdAsyn(command.Id);

            if(book is null)
            {
                return false;
            }

            book.Title = command.Title;
            book.Author = command.Author;
            book.Isbn = command.ISBN;
            book.Price = command.Price;
            book.PublishedDate = command.PublishedDate;

            await _repository.UpdateAsync(book);

            return true;
        }
    }
}
