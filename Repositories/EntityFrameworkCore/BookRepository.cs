﻿using Entities.Models;
using Repositories.Contracts;

namespace Repositories.EntityFrameworkCore
{
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateOneBook(Book book) => Create(book);

        public void DeleteOneBook(Book book) => Delete(book);

        public IQueryable<Book> GetAllBooks(bool trackChanges) => FindAll(trackChanges);

        public Book GetOneBookById(int id, bool trackChanges) => FindByCondition(b => b.Id == id, trackChanges).OrderBy(b=>b.Id).SingleOrDefault();

        public void UpdateOneBook(Book book) => Update(book);
    }
}
