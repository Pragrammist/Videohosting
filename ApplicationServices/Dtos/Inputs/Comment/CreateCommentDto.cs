using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Dtos.Inputs
{
    public class CreateCommentDto
    {
        public Guid VideoId { get; set; } 
        public Guid AuthorId { get; set; }
        public string Text { get; set; }
    }
}
