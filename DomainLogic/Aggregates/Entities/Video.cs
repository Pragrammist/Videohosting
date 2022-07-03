using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomainLogic.Aggregates
{
    public class Video : AggregateRootGuid
    {
        protected Video() { }
        public Video(Guid id, string name, string tags, string description, Guid channelId, Guid previewId, Guid videoFileId): base(id) 
        {
            SetName(name);
            SetDescription(description);
            SetTags(tags);
            ChannelId = SetId(channelId);
            PreviewId = SetId(previewId);
            VideoFileId = SetId(videoFileId);
        }
        public string VideoName { get; protected set; }
        public string Tags { get; protected set; }
        public string Description { get; protected set; }
        public int Dislikes { get; protected set; } = 0;
        public int Likes { get; protected set; } = 0;
        public int Views { get; protected set; } = 0;
        public int Shared { get; protected set; } = 0;
        public int Comments { get; protected set; } = 0;
        public Guid ChannelId { get; protected set; }
        public Guid PreviewId { get;  protected set; }
        public Guid VideoFileId { get; protected set; }



        

        public void SetName(string name) => VideoName = name;
        public void SetTags(string tags) => Tags = tags;
        public void SetDescription(string description) => Description = description;

        private int Increase(int num) => num++;
        private int Decrease(int num)
        {
            if (num > 0)
                return --num;
            return num;
        }

        public void IncreaseLikes() => Likes = Increase(Likes);
        public void DecreaseLikes() => Likes = Decrease(Likes);

        public void IncreaseDislikes() => Dislikes = Increase(Dislikes);
        public void DecreaseDislikes() => Dislikes = Decrease(Dislikes);

        public void IncreaseShared() => Shared = Increase(Shared);

        public void IncreaseComments() => Comments = Increase(Comments);
        public void DecreaseComments() => Comments = Decrease(Comments);


    }
}
