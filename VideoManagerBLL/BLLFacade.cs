﻿using System;
using System.Collections.Generic;
using System.Text;
using VideoManagerBLL.Services;

namespace VideoManagerBLL
{
   public class BLLFacade
    {
        public IVideoService VideoService
        {
            get { return new VideoService(); }
        }
    }
}