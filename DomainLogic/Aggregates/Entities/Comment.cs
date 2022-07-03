using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomainLogic.Aggregates
{
    public class Comment : AggregateRootGuid
    {
        public Comment(Guid id, Guid videoId, Guid authorId, string text) : base(id)
        {
            VideoId = SetId(videoId);
            AuthorId = SetId(authorId);
            SetText(text);
        }
        public void SetText(string text) => CommentText = text;

        private int Increase(int num) => num++;
        private int Decrease(int num)
        {
            if (num > 0)
               return --num;
            return num;
        }

        public bool Fix()
        {
            if (!IsFixed)
            {
                IsFixed = true;
                return true;
            }
            return false;
        }

        public bool UnFix()
        {
            if (IsFixed)
            {
                IsFixed = false;
                return true;
            }
            return false;
        }
        public string CommentText { get; protected set; }

        public bool IsFixed { get; protected set; } = false;

        public void IncreaseLikes() => Likes = Increase(Likes);
        public void DecreaseLikes() => Likes = Decrease(Likes);

        public void IncreaseShared() => Shared = Increase(Shared);

        public void IncreaseAnswer() => Answers = Increase(Answers);
        public void DecreaseAnswer() => Answers = Decrease(Answers);

        public void IncreaseDislikes() => Dislikes = Increase(Dislikes);
        public void DecreaseDislikes() => Dislikes = Decrease(Dislikes);

        public int Likes { get; protected set; } = 0;
        public int Dislikes { get; protected set; } = 0;
        public int Shared { get; protected set; } = 0;
        public int Answers { get; protected set; } = 0;
        public Guid VideoId { get; protected set; } 
        public Guid AuthorId { get; protected set; }
    }
}
