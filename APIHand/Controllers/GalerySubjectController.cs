using APIHand.Entities;
using APIHand.Entities.DTO.Command;
using APIHand.Entities.DTO.GalerySubject;
using APIHand.Services;
using Microsoft.AspNetCore.Mvc;

namespace APIHand.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class GalerySubjectController : Controller
    {
        [HttpGet]
        [ActionName("All")]
        public async Task<IActionResult> GetGallerySubject()
        {
            try
            {
                List<GalerySubject> commands = await GallerySubjectService.GetAllGalerySubjects();
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
        public async Task<IActionResult> AddGalerySubject(CreateGalerySubjectDTO subject)
        {
            try
            {
                await GallerySubjectService.AddGalerySubject(new GalerySubject(subject));
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut]
        [ActionName("Update")]
        public async Task<IActionResult> UpdateGalerySubject(GalerySubject subject)
        {
            try
            {
                if (await GallerySubjectService.UpdateGalerySubject(subject)) return Ok();
                else return NotFound();

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteGalerySubject(int galerySubject_pk)
        {
            try
            {
                if (await GallerySubjectService.DeleteGalerySubject(galerySubject_pk)) return Ok();
                else return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
