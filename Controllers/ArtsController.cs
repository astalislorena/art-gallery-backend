using ArtGallery.Models;
using ArtGallery.Providers;
using Microsoft.AspNetCore.Mvc;

namespace ArtGallery.Controllers
{
    [ApiController]
    [Route("arts")]
    public class ArtsController : ControllerBase
    {
        private readonly IArtProvider _artProvider;
        public ArtsController(IArtProvider artProvider)
        {
            _artProvider = artProvider;
        }

        [HttpGet]
        public IActionResult GetArts()
        {
            var returnValue = _artProvider.QueryArt().ToArray();
            return Ok(returnValue);
        }

        [HttpPost]
        public IActionResult AddArt(string title, string artist, int year, string imageUrl, string type, ArtType artType, string? technique)
        {
            var returnValue = _artProvider.AddArt(title,artist, imageUrl, year, type, artType, technique);
            return Ok(returnValue);
        }

        [HttpPut]
        public IActionResult UpdateArt(int id, ArtType artType, string? title, string? artist, int? year, string? type, string? technique)
        {
            var returnValue = _artProvider.UpdateArt(id, artType, null, title, artist, year, type, technique) ;
            return Ok(returnValue);
        }
    }
}

