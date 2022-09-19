using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiDDD.Domain.Entities;
using WebApiDDD.Domain.Interfaces;

namespace WebApiDDD.Service.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseEntity
    {
        private readonly IBaseRepository<TEntity> _baseRepository;

        public BaseService(IBaseRepository<TEntity> baseRepository)
        {
            _baseRepository = baseRepository;
        }
        public TEntity Add<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>
        {
            Validate(obj, Activator.CreateInstance<TValidator>());
            _baseRepository.Insert(obj);
            return obj;
        }

        public void Delete(int id) => _baseRepository.Delete(id);

        public IList<TEntity> Get()
        {
            throw new NotImplementedException();
        }

        public TEntity GetbyId(int id) => _baseRepository.Select(id);
        
        public TEntity Update<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>
        {
            Validate(obj, Activator.CreateInstance<TValidator>());
            _baseRepository.Update(obj);
            return obj;
        }
        private void Validate(TEntity entity, AbstractValidator<TEntity> validator)
        {
            if (entity == null)
                throw new NullReferenceException("Objecto nulo");
            validator.ValidateAndThrow(entity);
        }
    }
}
