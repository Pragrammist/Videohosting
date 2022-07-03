using DomainLogic.Aggregates.Relations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DomainLogic.Specifications.Relations
{
    public class UserAndVideoExistsSpecification<TUserAndVideo> : ISpecification<TUserAndVideo, Guid> where TUserAndVideo : UserAndVideo
    {
        Guid _userId;
        Guid _videoId;
        public UserAndVideoExistsSpecification(Guid userId, Guid videoId) 
        {
            _userId = userId;
            _videoId = videoId;
        }

        public Expression<Func<TUserAndVideo, bool>> ToExpression()
        {
            return i => i.UserId == _userId && i.VideoId == _videoId;
        }

    }
}
