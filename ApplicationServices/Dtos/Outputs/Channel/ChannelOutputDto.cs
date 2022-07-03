using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Dtos.Outputs
{
    public class ChannelOutputDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int CountOfSubscribers { get; set; } = 0;
        public string Description { get; set; }
        public bool HaveTicket { get; set; }
        public int ViewsVideo { get; set; } = 0;
        public Guid? HeadId { get; set; }
        public Guid? FaceId { get; set; }
        public Guid? CreaterId { get; set; }
    }
}
