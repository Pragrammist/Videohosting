using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLogic.Aggregates.Relations
{
    public class UserAndVideoLike : UserAndVideo
    {

        protected UserAndVideoLike() { }

        public UserAndVideoLike(Guid id, Guid videoId, Guid userId) : base(id, videoId, userId)
        {

        }
    }
    
}
