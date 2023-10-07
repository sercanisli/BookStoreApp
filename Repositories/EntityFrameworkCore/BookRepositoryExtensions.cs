﻿using Entities.Models;

namespace Repositories.EntityFrameworkCore
{
    public static class BookRepositoryExtensions
    {
        public static IQueryable<Book> FilterBooks(this IQueryable<Book> books, uint minPrice, uint maxPrice) =>
            books.Where(b => (b.Price >= minPrice) && (b.Price <= maxPrice));
    }
}
