using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Repository.EF.UoW.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureFunction.DependyInjection.Sample.Repository.Catalogs;

public class CatalogRepository : GenericRepository<Catalog>, ICatalogRepository
{
    public CatalogRepository(DbContext context, ILogger logger) : base(context, logger)
    {
    }

    public override async Task<IEnumerable<Catalog>> All()
    {
        try
        {
            return await dbSet.ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{Repo} All function error", typeof(CatalogRepository));
            return new List<Catalog>();
        }
    }
    public override async Task<bool> Upsert(Catalog entity)
    {
        try
        {
            var existingTask = await dbSet.Where(x => x.CatalogueId == entity.CatalogueId)
                .FirstOrDefaultAsync();
            if (existingTask == null)
                return await Add(entity);

            existingTask.Description = entity.Description;
            existingTask.Name = entity.Name;

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{Repo} Upsert function error", typeof(CatalogRepository));
            return false;
        }
    }

    public override async Task<bool> Delete(int id)
    {
        try
        {
            var exist = await dbSet.Where(x => x.CatalogueId == id)
                .FirstOrDefaultAsync();

            if (exist == null) return false;

            dbSet.Remove(exist);

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{Repo} Delete function error", typeof(CatalogRepository));
            return false;
        }
    }
}
