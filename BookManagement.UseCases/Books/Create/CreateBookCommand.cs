using System;
using System.Collections.Generic;
using System.Text;

namespace BookManagement.UseCases.Books.Create
{
    public record CreateBookCommand(
        string Title,
        string Author,
        string ISBN,
        decimal Price,
        DateTime PublishedDate);
    
    
}
