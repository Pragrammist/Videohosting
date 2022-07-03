using ApplicationServices.Dtos.Inputs;
using ApplicationServices.Dtos.Outputs;
using System;
using System.Threading.Tasks;

namespace ApplicationServices
{
    public interface IChannelAppService
    {
        public Task<ChannelOutputDto> CreateChannel(CreateChannelDto channelCreationData);
        public Task<ChannelOutputDto> DeleteChannel(Guid id);
        public Task<ChannelOutputDto> SetTick(Guid id);
        //public Task<ChannelOutputDto> DeleteTick(Guid id);
        public Task<ChannelOutputDto> Get(GetChannelDto channelGetCriteries);
        public Task<ChannelOutputDto> Subscribe(Guid userId, Guid channelId);
        public Task<ChannelOutputDto> UnSubscribe(Guid userId, Guid channelId);
        public Task<ChannelOutputDto> ChangeName(Guid channelId, string newName);
        public Task<ChannelOutputDto> ChangeIcon(Guid channelId, Guid iconId);
        public Task<ChannelOutputDto> ChangeHeader(Guid channelId, Guid headerId);
    }
}
