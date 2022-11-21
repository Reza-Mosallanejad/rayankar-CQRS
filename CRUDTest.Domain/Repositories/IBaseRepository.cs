using CRUDTest.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDTest.Domain.Repositories
{
    public interface IBaseRepository<TModel> where TModel : BaseModel
    {
        IQueryable<TModel> All { get; }

        Task<TModel> Create(TModel model);

        Task<TModel> Update(TModel model);

        Task Delete(TModel model);

        Task Save();
    }
}
