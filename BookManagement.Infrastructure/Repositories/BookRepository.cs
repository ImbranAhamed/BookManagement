using BookManagement.Core.Interfaces;
using BookManagement.Infrastructure.Data;
using BookManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;

namespace BookManagement.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _context;

        public BookRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
        }

        public async Task<Book?> GetByIdAsyn(int id)
        {
            return await _context.Books.
                FirstOrDefaultAsync(b => b.BookId == id);
        }

        public async Task<List<Book>> GetAllAsync()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<List<Book>> ListAsync(ISpecification<Book> specification)
        {
            return await _context.Books
                         .WithSpecification(specification)
                         .ToListAsync();
        }

        public async Task UpdateAsync(Book book)
        {
            _context.Books.Update(book);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Book book)
        {
            _context.Books.Remove(book);

            await _context.SaveChangesAsync();
        }
    }

}
   
   

