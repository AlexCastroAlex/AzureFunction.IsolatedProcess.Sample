using AzureFunction.DependyInjection.Sample.Repository;
using Repository.EF.UoW.Core.Models;

namespace AzureFunction.DependyInjection.Sample.Repository.Catalogs;

public interface ICatalogRepository:  IGenericRepository<Catalog>
{
    
}