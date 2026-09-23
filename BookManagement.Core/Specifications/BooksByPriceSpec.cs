using Ardalis.Specification;
using BookManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookManagement.Core.Specifications
{
    public class BooksByPriceSpec : Specification<Book>
    {
        public BooksByPriceSpec(decimal price)
        {
            Query.Where(book => book.Price < price);
        }
    }
}
