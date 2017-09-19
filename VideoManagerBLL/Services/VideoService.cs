﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoManagerDAL;
using VideoManagerEntity;

namespace VideoManagerBLL.Services
{
    class VideoService : IVideoService
    {

        DALFacade facade;
       public VideoService(DALFacade facade)
        {
            this.facade = facade;
        }

        public Video Create(Video vid)
        {
            using (var uow = facade.UnitOfWork)
            {
                var newVid = uow.VideoRepository.Create(vid);
                uow.Complete();
                return newVid;
            }
            
        }

        public Video Delete(int Id)
        {

            using (var uow = facade.UnitOfWork)
            {
                var newVid = uow.VideoRepository.Delete(Id);
                uow.Complete();
                return newVid;
            }
        }

        public Video Get(int Id)
        {
            using (var uow = facade.UnitOfWork)
            {
                return uow.VideoRepository.Get(Id);
            }
        }

        public List<Video> GetAll()
        {
            using (var uow = facade.UnitOfWork)
            {
                return uow.VideoRepository.GetAll();
            }
        }

        public Video Update(Video vid)
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
                return videoFromDb;
            }
        }
    }
}
