using BookManagement.Core.Interfaces;
using BookManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using BookManagement.Core.Specifications;

namespace BookManagement.UseCases.Books.List
{
    public class ListBooksHandler
    {
        private readonly IBookRepository _repository;

        public ListBooksHandler(IBookRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Book>> Handle(ListBooksQuery query)
        {
            var specification = new BooksPublishedAfterSpec(query.PublishedDate);

            return await _repository.ListAsync(specification);
        }
    }
}
