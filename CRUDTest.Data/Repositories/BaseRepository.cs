using CRUDTest.Domain.DBContext;
using CRUDTest.Domain.Models;
using CRUDTest.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDTest.Data.Repositories
{
    public class BaseRepository<TModel> : IBaseRepository<TModel> where TModel : BaseModel
    {
        private MyDBContext _dBContext;
        private DbSet<TModel> _dbSet;

        public BaseRepository(MyDBContext dBContext)
        {
            _dBContext = dBContext;
            _dbSet = _dBContext.Set<TModel>();
        }

        public async Task Save()
        {
            await _dBContext.SaveChangesAsync();
        }

        public IQueryable<TModel> All => _dbSet.AsQueryable();

        public async Task<TModel> Create(TModel model)
        {
            await _dbSet.AddAsync(model);
            await Save();
            return model;
        }

        public async Task<TModel> Update(TModel model)
        {
            _dbSet.Update(model);
            await Save();
            return model;
        }

        public async Task Delete(TModel model)
        {
            _dbSet.Remove(model);
            await Save();
        }

    }
}
