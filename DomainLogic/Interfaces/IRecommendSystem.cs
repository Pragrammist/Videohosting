using DomainLogic.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLogic.Interfaces
{
    public interface IRecommendSystem
    {
        IEnumerable<Video> GetMostPopularVideo(int page = 0);
    }
}
