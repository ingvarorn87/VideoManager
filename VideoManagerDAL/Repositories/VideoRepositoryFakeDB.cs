﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoManagerDAL.Entities;

namespace VideoManagerDAL.Repositories
{
    class VideoRepositoryFakeDB : IVideoRepository


    {
        #region Fake DB
        private static int Id = 1;
        private static List<Video> Videos = new List<Video>();
        #endregion

        public Video Create(Video vid)
        {
            Video newVid;
            Videos.Add(newVid = new Video()
            {
                VideoName = vid.VideoName,
                Genre = vid.Genre,
                Year = vid.Year,
                Id = Id++
            });
            return newVid;
        }

        public Video Delete(int Id)
        {
            var vid = Get(Id);
            Videos.Remove(vid);
            return vid;
        }

        public Video Get(int Id)
        {
            return Videos.FirstOrDefault(x => x.Id == Id);
        }

        public List<Video> GetAll()
        {
            return new List<Video>(Videos);
        }
    }
}
