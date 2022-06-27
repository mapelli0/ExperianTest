using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Experian.Interface;
using Experian.Models;

namespace Experian.BLL
{
    public class PhotoManager : IPhotoManager
    {
        private readonly IPlaceHolderClient _apiClient;

        public PhotoManager(IPlaceHolderClient apiClient) {
            _apiClient = apiClient;
        }
        
        
        public async Task<List<Album>> GetAlbums() {
            var albums = await _apiClient.GetAlbums();
            //for performance reasons get all photos from all albums and merge the list after
            //instead of calling the API multiple times for each album
            if (albums != null && albums.Any()) {
                var photos = await _apiClient.GetPhotos();
                if (photos != null && photos.Any()) {
                    foreach (var album in albums) {
                        var photoList = photos.Where(p => p.AlbumId == album.Id).ToList();
                        if (photoList.Any()) {
                            album.Photos = photoList;    
                        }
                    }    
                }
                return albums;
            }
            //Todo: Maybe throw an empty exception to reduce nesting?
            return Array.Empty<Album>().ToList();
        }

        public async Task<List<Album>> GetAlbumByUserId(int userId) {
            var albums = await _apiClient.GetAlbumByUserId(userId);
            if (albums != null && albums.Any()) {
                foreach (var album in albums) {
                    var photoList = await _apiClient.GetPhotosByAlbum(album.Id);
                    if (photoList != null && photoList.Any()) {
                        album.Photos = photoList;
                    }
                }
                return albums;
            }
            //Todo: Maybe throw an empty exception to reduce nesting?
            return Array.Empty<Album>().ToList();
        }
    }
}