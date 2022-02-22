using ArtGallery.Providers;
using Microsoft.AspNetCore.Mvc;

namespace ArtGallery.Controllers
{
    [ApiController]
    [Route("arts")]
    public class ArtsController: ControllerBase
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

    }
}

