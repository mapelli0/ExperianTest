using System.Collections.Generic;
using System.Threading.Tasks;
using Experian.BLL;
using Experian.Interface;
using Experian.Models;
using Moq;
using NUnit.Framework;

namespace ExperianTest
{
    public class Tests
    {
        private Mock<IPlaceHolderClient> _apiMoq;

        [SetUp]
        public void Setup() {
            _apiMoq = new Mock<IPlaceHolderClient>();
            _apiMoq.Setup(a => a.GetAlbums()).ReturnsAsync(new List<Album>()
            {
                new Album()
                {
                    UserId = 1,
                    Id = 1,
                    Title = "Test"
                }
            });
            _apiMoq.Setup(a => a.GetAlbumByUserId(It.IsAny<int>())).ReturnsAsync(new List<Album>()
            {
                new Album()
                {
                    UserId = 1,
                    Id = 1,
                    Title = "Test"
                }
            });
        }

        [Test]
        public async Task PhotoManager_GetAlbum_ShouldCallAlbumAndPhotoApi_OnlyOnce() {
            var manager = new PhotoManager(_apiMoq.Object);
            await manager.GetAlbums();
            _apiMoq.Verify(s => s.GetAlbums(), Times.Once);
            _apiMoq.Verify(s => s.GetPhotos(), Times.Once);
        }

        [Test]
        public async Task PhotoManage_GetAlbumByUser_ShouldCallPhotoApi_AtLeastOnce_IfAnyAlbum() {
            var manager = new PhotoManager(_apiMoq.Object);
            await manager.GetAlbumByUserId(It.IsAny<int>());
            _apiMoq.Verify(s => s.GetAlbumByUserId(It.IsAny<int>()), Times.Once);
            _apiMoq.Verify(s => s.GetPhotosByAlbum(It.IsAny<int>()), Times.AtLeastOnce);
        }
    }
}