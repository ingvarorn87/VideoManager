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
            this.repo = repo;
        }

        public Video Create(Video vid)
        {
            
            return repo.Create(vid);
        }

        public Video Delete(int Id)
        {

            return repo.Delete(Id);
        }

        public Video Get(int Id)
        {
            return repo.Get(Id);
        }

        public List<Video> GetAll()
        {
            return repo.GetAll();
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
