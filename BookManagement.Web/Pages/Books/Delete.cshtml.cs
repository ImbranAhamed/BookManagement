using BookManagement.UseCases.Books.Delete;
using BookManagement.UseCases.Books.Get;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookManagement.Web.Pages.Books;

public class DeleteModel : PageModel
{
    private readonly GetBookHandler _getHandler;
    private readonly DeleteBookHandler _deleteHandler;

    public DeleteModel(
        GetBookHandler getHandler,
        DeleteBookHandler deleteHandler)
    {
        _getHandler = getHandler;
        _deleteHandler = deleteHandler;
    }

    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

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

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int id)
    {
        var deleted = await _deleteHandler.Handle(
            new DeleteBookCommand(id));

        if (!deleted)
        {
            return NotFound();
        }

        return RedirectToPage("Index");
    }
}