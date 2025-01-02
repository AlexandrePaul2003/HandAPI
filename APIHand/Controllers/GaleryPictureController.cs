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
                List<GaleryPicture> pictures = await GaleryPictureService.GetAllGaleryPictures();
                if (pictures.Count == 0) return NoContent();
                else return Ok(pictures);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet]
        [ActionName("One")]
        public async Task<IActionResult> GetGaleryPictureById(int picture_pk)
        {
            try
            {
                GaleryPicture picture = await GaleryPictureService.GetOneGaleryPictures(picture_pk);
                if (picture == null) return NotFound();
                else return Ok(picture);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet]
        [ActionName("BySubject")]
        public async Task<IActionResult> GetGaleryPicturesBySubject(int subject_pk)
        {
            try
            {
                List<GaleryPicture> commands ;
                if (subject_pk > -1)
                {
                    if (GallerySubjectService.GetOneGalerySubjects(subject_pk) == null) return NotFound();
                    commands = await GaleryPictureService.GetGaleryPicturesBySubjectPk(subject_pk);

                }
                else
                {
                    commands = await GaleryPictureService.GetAllGaleryPictures();
                }
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
