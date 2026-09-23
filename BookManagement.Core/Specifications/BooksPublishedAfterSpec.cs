using System;
using System.Collections.Generic;
using System.Text;
using Ardalis.Specification;
using BookManagement.Core.Entities;

namespace BookManagement.Core.Specifications
{
    public class BooksPublishedAfterSpec : Specification<Book>
    {
        public BooksPublishedAfterSpec(DateTime publishedDate)
        {
            Query.Where(book => book.PublishedDate > publishedDate);
        }
    }
}
