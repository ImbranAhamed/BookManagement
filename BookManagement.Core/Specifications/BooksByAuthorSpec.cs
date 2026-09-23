using System;
using System.Collections.Generic;
using System.Text;
using BookManagement.Core.Entities;
using Ardalis.Specification;

namespace BookManagement.Core.Specifications
{
    public class BooksByAuthorSpec : Specification<Book>
    {
        public BooksByAuthorSpec(string? author)
        {
            Query.Where(book => book.Author == author, !string.IsNullOrWhiteSpace(author))
                .OrderBy(book => book.Title);
        }
    }
}
