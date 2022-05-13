using ArtGallery.Providers.InstitutionProvider;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ArtGallery.Controllers
{
    [ApiController]
    [Route("institutions")]
    public class InstitutionController : ControllerBase
    {
        private readonly IInstitutionProvider _institutionProvider;
        public InstitutionController(IInstitutionProvider institutionProvider)
        {
            _institutionProvider = institutionProvider;
        }

        [HttpGet]
        public IActionResult GetInstitutions()
        {
            var returnValue = _institutionProvider.GetInstitutions();
            return Ok(returnValue);
        }

        [HttpPost]
        public IActionResult AddInstitution(string name, string location)
        {
            var returnValue = _institutionProvider.AddInstitution(name, location);
            return Ok(returnValue);
        }

        [HttpPut]
        public IActionResult AddArtsToInstitution(int id, int[] ids)
        {
            var returnValue = _institutionProvider.AddArtsToInstitution(id, ids);
            return Ok(returnValue);
        }

        [HttpGet]
        [Route("arts")]
        public IActionResult GetArtsOfInstitution(int id)
        {
            var returnValue = _institutionProvider.GetArtsOfInstitution(id);
            return Ok(returnValue);
        }
    }
}
