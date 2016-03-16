using Epam.Wunderlist.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Wunderlist.Services.Models;
using System.IO;
using Epam.Wunderlist.DataAccess.Interfaces.Infrastructure;
using Epam.Wunderlist.DataAccess.Interfaces;
using Epam.Wunderlist.Models;

namespace Epam.Wunderlist.Services.Services
{
    public class ImageService : IImageService
    {
        private IUnitOfWork _uow;
        private ICloudStorage _cloudStorage;
        private IPictureRepository _pictureRepository;
        private IUserService _userService;
        public ImageService(IUnitOfWork uow, ICloudStorage cloudStorage, IPictureRepository pictureRepository,IUserService userService)
        {
            _uow = uow;
            _cloudStorage = cloudStorage;
            _pictureRepository = pictureRepository;
            _userService = userService;
        }
        public void Add(Picture entity)
        {
            _pictureRepository.Add(entity);
            _uow.Commit();
        }


        public void DeleteImage(int id)
        {
            throw new NotImplementedException();
        }

        public Image GetImage(int id)
        {
            var picture = _pictureRepository.GetById(id);
            if (picture != null)
            {
                var url = _cloudStorage.GetUrl(picture.Name);
                return new Image() { Url = url };
            }
            return null;
        }

        public Image GetImage(string imgName)
        {
            var url = _cloudStorage.GetUrl(imgName);
            return new Image() { Url = url };
        }

        public Image GetImage(int id, int width, int height)
        {
            var picture = _pictureRepository.GetById(id);
            if (picture != null)
            {
                var url = _cloudStorage.GetUrl(picture.Name, width, height);
                return new Image() { Url = url,Id = id };
            }
            return null;
        }

        public bool StoreImage(Stream File)
        {
            var imgName = Guid.NewGuid().ToString();
            return StoreImage(imgName, File);
        }

        public bool StoreImage(string imgName, Stream File)
        {
            return _cloudStorage.UploadImage(imgName, File);
        }

        public void SetAvatar(int userId, Image image)
        {
            var picture = _pictureRepository.GetById(_userService.GetById(userId).UserPhotoId);
            picture.Name = image.Name;
            _pictureRepository.Update(picture);
            _uow.Commit();
        }
    }
}
