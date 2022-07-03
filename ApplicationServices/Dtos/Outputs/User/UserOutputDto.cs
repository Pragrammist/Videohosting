using System;

namespace ApplicationServices.Dtos.Outputs
{
    public class UserOutputDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int CountOfSubscribes { get; set; } = 0;
        public string Gender { get; set; }
        public Guid? ChannelId { get; set; }
        public Guid? AvatarId { get; set; }
    }
}
