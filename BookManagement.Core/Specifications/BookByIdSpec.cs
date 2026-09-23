using System;
using System.Collections.Generic;
using System.Text;
using BookManagement.Core.Entities;
using Ardalis.Specification;

namespace BookManagement.Core.Specifications
{
    public class BookByIdSpec : SingleResultSpecification<Book>
    {
        public BookByIdSpec(int id)
        {
            Query.Where(book => book.BookId == id);
        }
    }
}
