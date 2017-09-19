using System;
using System.Collections.Generic;
using System.Text;
using VideoManagerBLL.BusinessObjects;

namespace VideoManagerBLL
{
    public interface IVideoService
    {
        //C
        VideoBO Create(VideoBO vid);
        //R
        List<VideoBO> GetAll();
        VideoBO Get(int Id);
        //U
        VideoBO Update(VideoBO vid);
        //D
        VideoBO Delete(int Id);

    }
}
