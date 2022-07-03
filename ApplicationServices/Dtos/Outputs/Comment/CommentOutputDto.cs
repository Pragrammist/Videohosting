using System;

namespace ApplicationServices.Dtos.Outputs
{
    public class CommentOutputDto
    {
        public int Likes { get; set; } = 0;
        public int Dislikes { get; set; } = 0;
        public int Shared { get; set; } = 0;
        public int Answers { get; set; } = 0;
        public Guid? VideoId { get; set; }
        public Guid? AuthorId { get; set; }
    }
}
