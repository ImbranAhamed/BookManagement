using BookManagement.UseCases.Books.Get;
using BookManagement.UseCases.Books.Update;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookManagement.Web.Pages.Books;

public class EditModel : PageModel
{
    private readonly GetBookHandler _getHandler;
    private readonly UpdateBookHandler _updateHandler;

    public EditModel(
        GetBookHandler getHandler,
        UpdateBookHandler updateHandler)
    {
        _getHandler = getHandler;
        _updateHandler = updateHandler;
    }

    [BindProperty]
    public int Id { get; set; }

    [BindProperty]
    public string Title { get; set; } = string.Empty;

    [BindProperty]
    public string Author { get; set; } = string.Empty;

    [BindProperty]
    public string ISBN { get; set; } = string.Empty;

    [BindProperty]
    public decimal Price { get; set; }

    [BindProperty]
    public DateTime PublishedDate { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var book = await _getHandler.Handle(
            new GetBookQuery(id));

        if (book is null)
        {
            return NotFound();
        }

        Id = book.BookId;
        Title = book.Title;
        Author = book.Author;
        ISBN = book.Isbn;
        Price = book.Price;
        PublishedDate = book.PublishedDate;

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var command = new UpdateBookCommand(
            Id,
            Title,
            Author,
            ISBN,
            Price,
            PublishedDate);

        var updated = await _updateHandler.Handle(command);

        if (!updated)
        {
            return NotFound();
        }

        return RedirectToPage("Index");
    }
}