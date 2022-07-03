using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLogic.Aggregates;

namespace DomainLogic.Interfaces
{
    public interface IOrderByQuery<TEntity, TId> where TEntity : IAggregateRoot<TId>
    {
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> OrderBy();
    }
}
