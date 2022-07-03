using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLogic.Aggregates
{
    public class AggregateRootGuid : IAggregateRoot<Guid>
    {
        public virtual Guid Id { get; protected set; }
        public virtual DateTime DateCreated { get; protected set; }
        protected AggregateRootGuid() { }
        public AggregateRootGuid(Guid id)
        {
            DateCreated = DateTime.Now;
            Id = SetId(id);
        }
        
        protected Guid SetId(Guid id)
        {
            if (id != Guid.Empty)
                return id;
            throw new Exception();
        }
    }
}
