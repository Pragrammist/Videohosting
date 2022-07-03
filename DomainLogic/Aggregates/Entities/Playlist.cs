using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainLogic.Shared;

namespace DomainLogic.Aggregates
{
    public class Playlist : AggregateRootGuid
    {
        protected Playlist() { }
        public Playlist(Guid id, Guid userCreated, string name, Guid? channelCreatedId = null ) : base(id)
        {
            UserIdCreated = SetId(userCreated);
            ChannelIdCreated = channelCreatedId;
            SetPlaylistName(name);
        }

        public void SetPlaylistName(string name) => PlaylistName = name;
        

        protected bool SetOpenProp(bool value)
        {
            if(IsOpen != value) 
            {
                IsOpen = value;
                return true;
            }
            return false;
        }

        public bool OpenPlaylist() => SetOpenProp(true);
        public bool ClosePlaylist() => SetOpenProp(false);

        public string PlaylistName { get; protected set; }
        public bool IsOpen { get; protected set; } = false;
        public Guid? ChannelIdCreated { get; protected set; }
        public Guid UserIdCreated { get; protected set; }

        

    }
}
