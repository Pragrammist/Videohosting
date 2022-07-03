using System;

namespace ApplicationServices.Dtos.Outputs
{
    public class VideoOutputDto 
    {
        public DateTime DateUpload { get; set; }
        public string VideoName { get; set; }
        public string Tags { get; set; }
        public string Description { get; set; }
        public int Dislikes { get; set; } = 0;
        public int Likes { get; set; } = 0;
        public int Views { get; set; } = 0;
        public int Shared { get; set; } = 0;
        public int Comments { get; set; } = 0;
        public Guid? ChannelId { get; set; }
        public Guid? PreviewId { get; set; }
        public Guid? VideoFileId { get; set; }
    }
}
