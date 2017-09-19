using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoManagerBLL.BusinessObjects;
using VideoManagerBLL.Converters;
using VideoManagerDAL;
using VideoManagerDAL.Entities;


namespace VideoManagerBLL.Services
{
    class VideoService : IVideoService
    {
        VideoConverter conv = new VideoConverter();
        DALFacade facade;
       public VideoService(DALFacade facade)
        {
            this.facade = facade;
        }

        public VideoBO Create(VideoBO vid)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newVid = uow.VideoRepository.Create(conv.Convert(vid));
                uow.Complete();
                return conv.Convert(newVid);
            }
            
        }

        public VideoBO Delete(int Id)
        {

            using (var uow = facade.UnitOfWork)
            {
                var newVid = uow.VideoRepository.Delete(Id);
                uow.Complete();
                return conv.Convert(newVid);
            }
        }

        public VideoBO Get(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                return conv.Convert(uow.VideoRepository.Get(Id));
            }
        }

        public List<VideoBO> GetAll()
        {
            using (var uow = facade.UnitOfWork)
            {

                //return uow.VideoRepository.GetAll();
                return uow.VideoRepository.GetAll().Select(c => conv.Convert(c)).ToList();
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
                return conv.Convert(videoFromDb);
            }
        }

    }
}
