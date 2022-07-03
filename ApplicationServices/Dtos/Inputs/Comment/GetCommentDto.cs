using System;

namespace ApplicationServices.Dtos.Inputs
{
    public class GetCommentDto
    {
        public Guid VideoId { get; set; }
        public Guid AuthorId { get; set; }
        public Guid Id { get; set; }
    }
}
