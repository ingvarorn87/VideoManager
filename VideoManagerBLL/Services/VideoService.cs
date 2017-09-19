using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoManagerBLL.BusinessObjects;
using VideoManagerDAL;
using VideoManagerDAL.Entities;


namespace VideoManagerBLL.Services
{
    class VideoService : IVideoService
    {

        DALFacade facade;
       public VideoService(DALFacade facade)
        {
            this.facade = facade;
        }

        public VideoBO Create(VideoBO vid)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newVid = uow.VideoRepository.Create(Convert(vid));
                uow.Complete();
                return Convert(newVid);
            }
            
        }

        public VideoBO Delete(int Id)
        {

            using (var uow = facade.UnitOfWork)
            {
                var newVid = uow.VideoRepository.Delete(Id);
                uow.Complete();
                return Convert(newVid);
            }
        }

        public VideoBO Get(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                return Convert(uow.VideoRepository.Get(Id));
            }
        }

        public List<VideoBO> GetAll()
        {
            using (var uow = facade.UnitOfWork)
            {

                //return uow.VideoRepository.GetAll();
                return uow.VideoRepository.GetAll().Select(c => Convert(c)).ToList();
            }
        }

        public VideoBO Update(VideoBO vid)
        {
            using (var uow = facade.UnitOfWork)
            {
                var videoFromDb = uow.VideoRepository.Get(vid.Id);
                if (videoFromDb == null)
                {
                    throw new InvalidOperationException("Customer not Found");
                }
                videoFromDb.VideoName = vid.VideoName;
                videoFromDb.Genre = vid.Genre;
                videoFromDb.Year = vid.Year;
                uow.Complete();
                return Convert(videoFromDb);
            }
        }
        private Video Convert(VideoBO vid)
        {
            return new Video()
            {
                Id = vid.Id,
                VideoName = vid.VideoName,
                Year = vid.Year,
                Genre = vid.Genre

            };
        }
        private VideoBO Convert(Video vid)
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
