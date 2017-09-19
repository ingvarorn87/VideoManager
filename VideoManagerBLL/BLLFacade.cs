using System;
using System.Collections.Generic;
using System.Text;
using VideoManagerBLL.Services;
using VideoManagerDAL;

namespace VideoManagerBLL
{
   public class BLLFacade
    {
        public IVideoService VideoService
        {
            get { return new VideoService(new DALFacade()); }
        }
    }
}
