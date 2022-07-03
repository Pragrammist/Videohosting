﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Dtos.Inputs
{
    public class CreateChannelDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid HeadId { get; set; }
        public Guid FaceId { get; set; }
        public Guid CreaterId { get; set; }
    }

}
