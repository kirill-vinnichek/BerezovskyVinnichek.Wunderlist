using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wunderlist.Models
{
    public class Picture
    {
        public int PictureId { get; set; }

        public byte[] PictureData { get; set; }

        public string PictureMimeType { get; set; }
    }
}
