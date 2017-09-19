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
        IVideoRepository repo;

       public VideoService(IVideoRepository repo)
        {
            this.repo
        }

        public Video Create(Video vid)
        {
            
            return null;
        }

        public Video Delete(int Id)
        {

            return null;
        }

        public Video Get(int Id)
        {
            return null;
        }

        public List<Video> GetAll()
        {
            return null;
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
