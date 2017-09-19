using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoManagerDAL;
using VideoManagerEntity;

namespace VideoManagerBLL.Services
{
    class VideoService : IVideoService
    {
        public Video Create(Video vid)
        {
            Video newVid;
            FakeDB.Videos.Add(newVid = new Video()
                     {
                       VideoName = vid.VideoName,
                       Genre = vid.Genre,
                       Year = vid.Year,
                       Id = FakeDB.Id++
                     });
            return newVid;
        }

        public Video Delete(int Id)
        {
            var vid = FakeDB.Videos.FirstOrDefault(x => x.Id == Id);
            foreach (var video in FakeDB.Videos)
            {
                if (video.Id == Id)
                {
                    FakeDB.Videos.Remove(video);
                    return video;
                }
                
            }
            return null;
        }

        public Video Get(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Video> GetAll()
        {
            throw new NotImplementedException();
        }

        public Video Update(Video vid)
        {
            throw new NotImplementedException();
        }
    }
}
