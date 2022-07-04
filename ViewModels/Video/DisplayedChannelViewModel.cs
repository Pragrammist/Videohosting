using System;

namespace VideoWebApp.ViewModels.Video
{
    public class DisplayedChannelViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Subescribers { get; set; }
        public bool HaveTicket { get; set; }
        public string IconPath { get; set; }
    }

}
