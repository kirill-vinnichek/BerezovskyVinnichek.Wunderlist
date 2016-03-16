using Epam.Wunderlist.DataAccess.Interfaces.Infrastructure;
using System.IO;
using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using System.Configuration;

namespace Epam.Wunderlist.CloudStorage.Cloudinary
{
    public class CloudinaryStorage : ICloudStorage
    {
        private readonly CloudinaryDotNet.Cloudinary cloudinary;
        private readonly string cloudName = ConfigurationManager.AppSettings["CloudName"];
        private readonly string apiKey = ConfigurationManager.AppSettings["apiKey"];
        private readonly string apiSecret = ConfigurationManager.AppSettings["apiSecret"];



        public CloudinaryStorage()
        {
            Account account = new Account(cloudName, apiKey, apiSecret);
            cloudinary = new CloudinaryDotNet.Cloudinary(account);
        }

        public bool UploadImage(string imgName, Stream img)
        {
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(imgName, img),
                PublicId = imgName
            };
            var uploadResult = cloudinary.Upload(uploadParams);
            //TODO: Дописать проверку на ошибку(не сохранилось ихображение)
            return true;

        }

        public string GetUrl(string imgName, int width, int height)
        {
            return cloudinary.Api.UrlImgUp.Transform(new Transformation().Width(width).Height(height).Crop("scale")).BuildUrl(imgName);
        }

        public string GetUrl(string imgName)
        {
            return cloudinary.Api.UrlImgUp.BuildUrl(imgName);
        }
    }
}

