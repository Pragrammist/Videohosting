using System;

namespace VideoWebApp.ViewModels.Video
{
    public class DisplayedVideoViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DateUpload { get; set; }
        public int Views { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public string Description { get; set; }
        public string Tags { get; set; }
    }

}
