using BookManagement.UseCases.Books.Create;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookManagement.Web.Pages.Books;

public class CreateModel : PageModel
{
    private readonly CreateBookHandler _handler;

    public CreateModel(CreateBookHandler handler)
    {
        _handler = handler;
    }

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

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var command = new CreateBookCommand(
            Title,
            Author,
            ISBN,
            Price,
            PublishedDate);

        var id = await _handler.Handle(command);

        return RedirectToPage("Index");
    }
}