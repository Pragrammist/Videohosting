using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLogic.Aggregates.Relations
{
    public abstract class UserAndComment : AggregateRootGuid
    {
        protected UserAndComment() { }
        protected UserAndComment(Guid id, Guid userId, Guid commentId) : base(id)
        {
            UserId = userId;
            CommentId = commentId;
        }
        public Guid UserId { get; set; }
        public Guid CommentId { get; set; }

        public void DeleteRelation()
        {
            UserId = Guid.Empty;
            CommentId = Guid.Empty;
        }
    }
}
