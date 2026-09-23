using System;
using System.Collections.Generic;
using System.Text;

namespace BookManagement.UseCases.Books.Update
{
    public record UpdateBookCommand(
        int Id,
        string Title,
        string Author,
        string ISBN,
        decimal Price,
        DateTime PublishedDate);
    
}
