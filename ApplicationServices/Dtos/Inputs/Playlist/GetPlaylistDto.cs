using System;

namespace ApplicationServices.Dtos.Inputs
{
    public class GetPlaylistDto
    {
        public Guid UserId { get; set; }

        public Guid Id { get; set; }

        public Guid ChannelId { get; set; }
    }

}
