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
            var vid = Get(Id);
            FakeDB.Videos.Remove(vid);
            return vid;
        }

        public Video Get(int Id)
        {
            return FakeDB.Videos.FirstOrDefault(x => x.Id == Id);
        }

        public List<Video> GetAll()
        {
            return new List<Video>(FakeDB.Videos);
        }

        public Video Update(Video vid)
        {

            var videoFromDb = Get(vid.Id);
            if (videoFromDb == null)
            {
                throw new InvalidOperationException("Customer not Found");
            }

            videoFromDb.VideoName = vid.VideoName;
            videoFromDb.Genre = vid.Genre;
            videoFromDb.Year = vid.Year;
            return videoFromDb;

        }
    }
}
