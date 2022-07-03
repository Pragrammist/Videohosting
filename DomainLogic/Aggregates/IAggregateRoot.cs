using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLogic.Aggregates
{
    public interface IAggregateRoot<T>
    {
        T Id { get; }
    }
}
