using System;
using System.Collections.Generic;
using System.Text;
using Ardalis.Specification;
using BookManagement.Core.Entities;
namespace BookManagement.Core.Interfaces
{
    public interface IBookRepository
    {
        Task<Book?> GetByIdAsyn(int id);
        Task<List<Book>> GetAllAsync();
        Task<List<Book>> ListAsync(ISpecification<Book> specification);
        Task AddAsync(Book book);
        Task UpdateAsync(Book book);
        Task DeleteAsync(Book book);
    }
}
