using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Experian.BLL;
using Experian.Interface;
using Experian.Models;
using Microsoft.AspNetCore.Mvc;

namespace Experian.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PhotoAlbumController : ControllerBase
    {
        private readonly IPhotoManager _photoManager;
        //Todo: Add better exception handler to hide code exceptions from the user
        //Todo: Add logger        

        public PhotoAlbumController(IPhotoManager photoManager) {
            _photoManager = photoManager;
        }


        [HttpGet]
        public async Task<IEnumerable<Album>> Get() {
            return await _photoManager.GetAlbums();
        }

        [HttpGet("{userId}")]
        public async Task<IEnumerable<Album>> GetByUserId(int userId) {
            return await _photoManager.GetAlbumByUserId(userId);
        }
    }
}