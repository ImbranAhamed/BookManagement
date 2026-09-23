using BookManagement.Core.Interfaces;
using BookManagement.Infrastructure.Data;
using BookManagement.Infrastructure.Repositories;
using BookManagement.UseCases.Books.Create;
using BookManagement.UseCases.Books.Delete;
using BookManagement.UseCases.Books.Get;
using BookManagement.UseCases.Books.List;
using BookManagement.UseCases.Books.Update;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Configure Web
builder.Services.AddRazorPages();


//Configure Infrastructure
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IBookRepository, BookRepository>();

//Configure UseCase
builder.Services.AddScoped<CreateBookHandler>();
builder.Services.AddScoped<GetBookHandler>();
builder.Services.AddScoped<ListBooksHandler>();
builder.Services.AddScoped<UpdateBookHandler>();
builder.Services.AddScoped<DeleteBookHandler>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
