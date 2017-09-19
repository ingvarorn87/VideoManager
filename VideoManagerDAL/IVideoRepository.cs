using System;
using System.Collections.Generic;
using System.Text;
using VideoManagerDAL.Entities;

namespace VideoManagerDAL
{
    public interface IVideoRepository
    {
        //C
        Video Create(Video vid);
        //R
        List<Video> GetAll();
        // no U!
        Video Get(int Id);
        //D
        Video Delete(int Id);
    }
}
