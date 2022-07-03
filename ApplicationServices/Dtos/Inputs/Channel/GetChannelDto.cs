using System;

namespace ApplicationServices.Dtos.Inputs
{
    public class GetChannelDto 
    {
        public Guid Id { get; set; }
        //public string Name { get; set; }
        public Guid UserId { get; set; } //TODO
    }

}
