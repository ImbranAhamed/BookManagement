using BookManagement.Core.Entities;
using BookManagement.UseCases.Books.List;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookManagement.Web.Pages.Books
{
    public class IndexModel : PageModel
    {

        private readonly ListBooksHandler _handler;


        public List<Book> Books {  get; set; }

        public IndexModel(ListBooksHandler handler)
        {
            _handler = handler;
        }
        public async Task OnGetAsync(DateTime publishedDate)
        {
            Books = await _handler.Handle(new ListBooksQuery(publishedDate));
        }
    }
}
