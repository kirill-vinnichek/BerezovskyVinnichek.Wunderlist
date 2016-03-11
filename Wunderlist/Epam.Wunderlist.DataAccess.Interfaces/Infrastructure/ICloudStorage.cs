using System.IO;

namespace Epam.Wunderlist.DataAccess.Interfaces.Infrastructure
{
    public interface ICloudStorage
    {
        bool UploadImage(string imgNane, Stream img);
        string GetUrl(string imgName, int width, int height);
        string GetUrl(string imgName);
    }
}
