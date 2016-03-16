using Epam.Wunderlist.Models;
using Epam.Wunderlist.Services.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Wunderlist.Services.Interfaces
{
    public interface IImageService
    {
        void SetAvatar(int userId, Image image);
        void Add(Picture entity);
        bool StoreImage(string imgName, Stream File);
        Image GetImage(string imgName);
        Image GetImage(int id);
        Image GetImage(int id, int width, int height);
        void DeleteImage(int id);
    }
}
