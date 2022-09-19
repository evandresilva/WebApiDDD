using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiDDD.Domain.Entities;
using WebApiDDD.Domain.Interfaces;
using WebApiDDD.Infra.Data.Context;


namespace WebApiDDD.Infra.Data.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly MyContext _myContext;
        public BaseRepository(MyContext myContext)
        {
            _myContext = myContext;
        }
        public void Insert(TEntity entity)
        {
            _myContext.Set<TEntity>().Add(entity);
            _myContext.SaveChanges();
        }
        public void Update(TEntity entity)
        {
            _myContext.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _myContext.SaveChanges();
        }
        public void Delete(int id)
        {
            _myContext.Set<TEntity>().Remove(Select(id));
            _myContext.SaveChanges();
        }
        public IList<TEntity> Select() =>
            _myContext.Set<TEntity>().ToList();


        public TEntity Select(int id) =>
            _myContext.Set<TEntity>().Find(id);
    }
}
