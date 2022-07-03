using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DomainLogic.Aggregates;

namespace DomainLogic.Specifications
{
    public interface ISpecification<TEntity, TId> where TEntity : IAggregateRoot<TId>
    {
        public Expression<Func<TEntity, bool>> ToExpression();
    }
    public class BaseSpecification<TEntity, TId> : ISpecification<TEntity, TId> where TEntity : IAggregateRoot<TId> // if lazy to make new class
    {
        Expression<Func<TEntity, bool>> _expression;
        public BaseSpecification(Expression<Func<TEntity, bool>> expression)
        {
            _expression = expression;
        }

        public Expression<Func<TEntity, bool>> ToExpression() => _expression;
        
    }
}
