using System.Collections.Generic;
using System.Threading.Tasks;
using Experian.Models;

namespace Experian.BLL
{
    public interface IPhotoManager
    {
        public Task<List<Album>> GetAlbums();
        public Task<List<Album>> GetAlbumByUserId(int userId);
    }
}