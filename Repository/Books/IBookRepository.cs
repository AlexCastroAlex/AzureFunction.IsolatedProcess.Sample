using Repository.EF.UoW.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureFunction.DependyInjection.Sample.Repository.Books
{
    public interface IBookRepository : IGenericRepository<Book>
    {
    }
}
