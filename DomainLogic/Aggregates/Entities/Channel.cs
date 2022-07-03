using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomainLogic.Aggregates
{
    public class Channel : AggregateRootGuid
    {
        public const int ticketSub = 1;
        protected Channel() { }
        public Channel(Guid id, string channelName, string description, Guid headId, Guid faceId, Guid createrId) : base(id) 
        {
            SetChannelName(channelName);
            SetDescription(description);
            SetHeadId(headId);
            SetFaceId(faceId);
            CreaterId = SetId(createrId);
        }
        public void SetChannelName(string channelName) => Name = channelName;

        public void SetDescription(string description) => Description = description;

        public void IncreaseSubscribers() => CountOfSubscribers++;

        public void DecreaseSubscribers() 
        {
            if (--CountOfSubscribers >= 0)
                --CountOfSubscribers;
        }


        public void IncreaseViews() => ViewsVideo++;

        public void DecreaseViews()
        {
            if(ViewsVideo > 0)
            {
                ViewsVideo--;
            }
        }
        public string Name { get; private set; }
        public int CountOfSubscribers { get; private set; } = 0;
        public string Description { get; private set; }
        public int ViewsVideo { get; private set; } = 0;
        
        public bool Ticket { get; private set; }

        public void SetTicket()
        {
            if (Ticket == false && CountOfSubscribers >= ticketSub)
            {
                Ticket = true;
            }
        }

        public void SetHeadId(Guid id)
        {
            HeadId = SetId(id);
        }
        public void SetFaceId(Guid id)
        {
            FaceId = SetId(id);
        }
        public Guid HeadId { get; protected set; }
        public Guid FaceId { get; protected set; }
        public Guid CreaterId { get; protected set; }
    }
}
