using DomainLogic.Aggregates.Relations;
using System;
using System.Linq.Expressions;

namespace DomainLogic.Specifications.Relations
{
    public class CommentAndAnswerExistsSpecification<TCommentAndAnswer> : ISpecification<TCommentAndAnswer, Guid> where TCommentAndAnswer : CommentAndAnswer
    {

        Guid _answerId = default;

        Guid _commentId = default;
        public CommentAndAnswerExistsSpecification(Guid answerId, Guid commentId)
        {
            _answerId = answerId;
            _commentId = commentId;
        }
        public CommentAndAnswerExistsSpecification(Guid commentId)
        {
            _commentId = commentId;
        }
        public Expression<Func<TCommentAndAnswer, bool>> ToExpression()
        {
            if (_answerId != default && _commentId != default) return AnswerAndComment();
            else return ByComment();

        }
        private Expression<Func<TCommentAndAnswer, bool>> AnswerAndComment() => i => i.CommentId == _commentId && i.AnswerId == _answerId;

        private Expression<Func<TCommentAndAnswer, bool>> ByComment() => i => i.CommentId == _commentId;
    }
    
}
