using System;
using System.Collections.Generic;
using System.Text;
using VideoManagerEntity;

namespace VideoManagerDAL
{
    public class FakeDB
    {
        #region Fake DB
        public static int Id = 1;
        public static List<Video> Videos = new List<Video>();
        #endregion
    }
}
