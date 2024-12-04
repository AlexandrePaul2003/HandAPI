using APIHand.Entities.DTO.GalerySubject;
using APIHand.Entities;
using APIHand.Services;
using Microsoft.AspNetCore.Mvc;
using APIHand.Entities.DTO.GaleryPicture;

namespace APIHand.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class GaleryPictureController : Controller
    {
        [HttpGet]
        [ActionName("All")]
        public async Task<IActionResult> GetAllGaleryPictures()
        {
            try
            {
                List<GaleryPicture> commands = await GaleryPictureService.GetAllGaleryPictures();
                if (commands.Count == 0) return NoContent();
                else return Ok(commands);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPost]
        [ActionName("Create")]
        public async Task<IActionResult> AddGaleryPicture(CreateGaleryPictureDTO picture)
        {
            try
            {
                if (GallerySubjectService.GetOneGalerySubjects(picture.GallerySubject_PK) == null) return StatusCode(500, "La galerie correspondante n'a pas été trouvée.");
                await GaleryPictureService.AddGaleryPicture(new GaleryPicture(picture));
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut]
        [ActionName("Update")]
        public async Task<IActionResult> UpdateGaleryPicture(GaleryPicture picture)
        {
            try
            {
                if (await GaleryPictureService.UpdateGaleryPicture(picture)) return Ok();
                else return NotFound();

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteGalerySubject(int galeryPicture_pk)
        {
            try
            {
                if (await GaleryPictureService.DeleteGaleryPicture(galeryPicture_pk)) return Ok();
                else return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
