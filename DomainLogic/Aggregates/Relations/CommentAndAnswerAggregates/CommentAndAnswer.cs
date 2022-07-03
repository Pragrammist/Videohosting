using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLogic.Aggregates.Relations
{
    public class CommentAndAnswer : AggregateRootGuid
    {
        protected CommentAndAnswer() { }
        public CommentAndAnswer(Guid id, Guid commentId, Guid answerId) : base(id)
        {
            CommentId = commentId;
            AnswerId = answerId;
        }
        public Guid CommentId { get; set; }
        public Guid AnswerId { get; set; }
    }
}
