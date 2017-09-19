using System;
using System.Collections.Generic;
using System.Text;

namespace VideoManagerDAL
{
    public interface IUnitOfWork : IDisposable
    {
        IVideoRepository VideoRepository { get; }

        int Complete();
    }
}
