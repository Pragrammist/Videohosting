using System;

namespace ApplicationServices.Dtos.Inputs
{
    public class AddVideosToPlaylistDto
    {
        public Guid PlaylistId { get; set; }
        public Guid VideoId { get; set; }
    }

}
