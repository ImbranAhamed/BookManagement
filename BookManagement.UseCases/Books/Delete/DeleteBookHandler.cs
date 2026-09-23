using BookManagement.Core.Interfaces;
using BookManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookManagement.UseCases.Books.Delete
{
    public class DeleteBookHandler
    {
        private readonly IBookRepository _repository;
        public DeleteBookHandler(IBookRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteBookCommand command)
        {
            Book book = await _repository.GetByIdAsyn(command.Id);

            if(book is null)
            {
                return false;
            }

            await _repository.DeleteAsync(book);

            return true;
        }
    }
}
