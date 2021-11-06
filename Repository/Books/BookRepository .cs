using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Repository.EF.UoW.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AzureFunction.DependyInjection.Sample.Repository.Books
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(DbContext context, ILogger logger) : base(context, logger)
        {
        }

        public override async Task<IEnumerable<Book>> All()
        {
            try
            {
                return await dbSet.Include(c=>c.Catalog).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All function error", typeof(BookRepository));
                return new List<Book>();
            }
        }
        public override async Task<bool> Upsert(Book entity)
        {
            try
            {
                var existingBook = await dbSet.Where(x => x.Id == entity.Id)
                                                    .FirstOrDefaultAsync();

                if (existingBook == null)
                    return await Add(entity);

                existingBook.Publisher = entity.Publisher;
                existingBook.Author = entity.Author ;
                existingBook.Genre = entity.Genre;
                existingBook.Price = entity.Price;
                existingBook.Title = entity.Title;
                existingBook.Catalog = entity.Catalog;

                

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Upsert function error", typeof(BookRepository));
                return false;
            }
        }

        public override async Task<bool> Delete(int id)
        {
            try
            {
                var exist = await dbSet.Where(x => x.Id == id)
                                        .FirstOrDefaultAsync();

                if (exist == null) return false;

                dbSet.Remove(exist);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Delete function error", typeof(BookRepository));
                return false;
            }
        }

        public override async Task<IEnumerable<Book>> Find(Expression<Func<Book, bool>> predicate)
        {
            return await dbSet.Include(c=>c.Catalog).Where(predicate).ToListAsync();
        }
    }
}
