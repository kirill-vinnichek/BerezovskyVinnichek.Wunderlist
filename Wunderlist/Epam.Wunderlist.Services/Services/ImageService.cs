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
        private readonly ILoggerService _loggerService;
        public ImageService(IUnitOfWork uow, ICloudStorage cloudStorage, IPictureRepository pictureRepository,IUserService userService, ILoggerService logger)
        {
            _uow = uow;
            _cloudStorage = cloudStorage;
            _pictureRepository = pictureRepository;
            _userService = userService;
            _loggerService = logger;
        }
        public void Add(Picture entity)
        {
            try
            {
                _loggerService.Trace("Add Picture started");
                _pictureRepository.Add(entity);
                _uow.Commit();
                _loggerService.Trace("Add Picture finished");
            }
            catch (Exception exeption)
            {
                _loggerService.Error(exeption.Message);
                throw;
            }
        }


        public void DeleteImage(int id)
        {
            throw new NotImplementedException();
        }

        public Image GetImage(int id)
        {
            try
            {
                _loggerService.Trace("GetImage Picture started");
                var picture = _pictureRepository.GetById(id);
                if (picture != null)
                {
                    var url = _cloudStorage.GetUrl(picture.Name);
                    return new Image() { Url = url };
                }
                return null;
            }
            catch (Exception exeption)
            {
                _loggerService.Error(exeption.Message);
                throw;
            }
        }

        public Image GetImage(string imgName)
        {
            try
            {
                _loggerService.Trace("GetImage Picture started");
                var url = _cloudStorage.GetUrl(imgName);
                return new Image() { Url = url };
            }
            catch (Exception exeption)
            {
                _loggerService.Error(exeption.Message);
                throw;
            }
        }

        public Image GetImage(int id, int width, int height)
        {
            try
            {
                _loggerService.Trace("GetImage Picture started");
                var picture = _pictureRepository.GetById(id);
                if (picture != null)
                {
                    var url = _cloudStorage.GetUrl(picture.Name, width, height);
                    return new Image() { Url = url, Id = id };
                }
                return null;
            }
            catch (Exception exeption)
            {
                _loggerService.Error(exeption.Message);
                throw;
            }
        }

        public bool StoreImage(Stream File)
        {
            try
            {
                _loggerService.Trace("StoreImage Picture started");
                var imgName = Guid.NewGuid().ToString();
                return StoreImage(imgName, File);
            }
            catch (Exception exeption)
            {
                _loggerService.Error(exeption.Message);
                throw;
            }
        }

        public bool StoreImage(string imgName, Stream File)
        {
            try
            {
                _loggerService.Trace("StoreImage Picture started");
                return _cloudStorage.UploadImage(imgName, File);
            }
            catch (Exception exeption)
            {
                _loggerService.Error(exeption.Message);
                throw;
            }
        }

        public void SetAvatar(int userId, Image image)
        {
            try
            {
                _loggerService.Trace("StoreImage Picture started");
                var picture = _pictureRepository.GetById(_userService.GetById(userId).UserPhotoId);
                picture.Name = image.Name;
                _pictureRepository.Update(picture);
                _uow.Commit();
                _loggerService.Trace("StoreImage Picture finished");
            }
            catch (Exception exeption)
            {
                _loggerService.Error(exeption.Message);
                throw;
            }
        }
    }
}
