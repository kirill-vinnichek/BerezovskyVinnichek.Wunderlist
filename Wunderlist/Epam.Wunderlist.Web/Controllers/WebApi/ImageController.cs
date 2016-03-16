using Epam.Wunderlist.Services.Interfaces;
using Epam.Wunderlist.Services.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Epam.Wunderlist.Web.Controllers.WebApi
{
    [Authorize]
    public class ImageController : ApiController
    {
        private IImageService _imageService;
        private IUserService _userService;
        public ImageController(IImageService imageService, IUserService userService)
        {
            _imageService = imageService;
            _userService = userService;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return _imageService.GetImage(id).Url;
        }

        [HttpPost]
        public IHttpActionResult Add()
        {
            //TODO: Проверка на ImageType и удалять старую
            if (!Request.Content.IsMimeMultipartContent("form-data"))
            {

                return BadRequest("Unsupported media type");
            }
            try
            {
                var file = HttpContext.Current.Request.Files[0];
                if (file!=null)
                {
                    var imgName = Guid.NewGuid().ToString();
                    _imageService.StoreImage(imgName,file.InputStream);
                    _imageService.SetAvatar(User.Identity.GetUserId<int>(), new Image() { Name = imgName });
                    var url = _imageService.GetImage(imgName).Url;
                    return Ok(new { mess="Photos uploaded ok",url = url });
                }
                return BadRequest("File is not supported");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.GetBaseException().Message);
            }
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}