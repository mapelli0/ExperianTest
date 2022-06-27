using System.Collections.Generic;
using System.Threading.Tasks;
using Experian.Models;
using Refit;

namespace Experian.Interface
{
    public interface IPlaceHolderClient
    {
        [Get("/albums")]
        Task<List<Album>> GetAlbums();

        [Get("/photos")]
        Task<List<Photo>> GetPhotos();

        [Get("/photos?albumId={albumId}")]
        Task<List<Photo>> GetPhotosByAlbum(int albumId);
        
        [Get("/albums?userId={userId}")]
        Task<List<Album>> GetAlbumByUserId(int userid);

    }
}