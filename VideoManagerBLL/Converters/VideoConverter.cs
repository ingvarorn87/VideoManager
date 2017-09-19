using System;
using System.Collections.Generic;
using System.Text;
using VideoManagerBLL.BusinessObjects;
using VideoManagerDAL.Entities;

namespace VideoManagerBLL.Converters
{
    class VideoConverter
    {
        internal Video Convert(VideoBO vid)
        {
            return new Video()
            {
                Id = vid.Id,
                VideoName = vid.VideoName,
                Year = vid.Year,
                Genre = vid.Genre

            };
        }
        internal VideoBO Convert(Video vid)
        {
            return new VideoBO()
            {
                Id = vid.Id,
                VideoName = vid.VideoName,
                Year = vid.Year,
                Genre = vid.Genre

            };
        }
    }
}
