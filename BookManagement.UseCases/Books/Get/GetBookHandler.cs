using BookManagement.Core.Interfaces;
using BookManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using BookManagement.Core.Specifications;

namespace BookManagement.UseCases.Books.Get
{
    public class GetBookHandler
    {
        private readonly IBookRepository _repository;

        public GetBookHandler(IBookRepository repository)
        {
            _repository = repository;
        }

        public async Task<Book?> Handle(GetBookQuery query)
        {
            var specification = new BookByIdSpec(query.Id);

            var books =  await _repository.ListAsync(specification);

            return books.FirstOrDefault();
        }

    }
}
