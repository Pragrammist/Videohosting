using System;

namespace ApplicationServices.Dtos.Inputs
{
    public class AnswerCommentDto
    {
        public Guid VideoId { get; set; }
        public Guid AuthorId { get; set; }
        public Guid CommentId { get; set; }
        public string Text { get; set; }
    }
}
