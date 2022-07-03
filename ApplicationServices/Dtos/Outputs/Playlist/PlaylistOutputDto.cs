using System;

namespace ApplicationServices.Dtos.Outputs
{
    public class PlaylistOutputDto
    {
        public Guid Id { get; set; }
        public string PlaylistName { get; set; }
        public bool IsOpen { get; set; } = false;
        public Guid? PlaylistPreviewId { get; set; }
        public int CountVideos { get; set; }
        public Guid? ChannelIdCreated { get; set; }
        public Guid? UserIdCreated { get; set; }
    }
}
