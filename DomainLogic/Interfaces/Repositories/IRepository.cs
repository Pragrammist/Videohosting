using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DomainLogic.Aggregates;
using DomainLogic.Specifications;

namespace DomainLogic.Interfaces.Repositories
{
    public interface IRepository<TEntity, TId> : IEnumerable<TEntity> where TEntity : IAggregateRoot<TId> 
    {
        public Task<IEnumerable<TEntity>> Get(ISpecification<TEntity, TId> specification = null, IOrderByQuery<TEntity, TId> orderByQuery = null, string includeProp = "", int page = 0);
        public Task<TEntity> GetByID(TId TId);
        public Task Insert(TEntity entity);
        public Task Delete(TId TId);
        public Task Delete(TEntity entityToDelete);
        public Task Update(TEntity entityToUpdate);
    }
}
