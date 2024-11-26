using APIHand.Entities;
using APIHand.Entities.DTO.Sheets;
using APIHand.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace APIHand.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class SheetController : Controller
    {
        [HttpGet]
        [ActionName("All")]
        public async Task<IActionResult> GetAll(int numberPerPage, int offset)
        {
            try
            {
                List<Sheet> sheets = await SheetService.GetSheets(numberPerPage, offset);
                if (sheets.Count <= 0) return NoContent();
                else return Ok(sheets);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet]
        [ActionName("AllFiltered")]
        public async Task<IActionResult> GetAllFiltered(int numberPerPage, int offset, string search)
        {
            Console.WriteLine("search" +  search);
            try
            {
                List<Sheet> sheets = await SheetService.GetSheetsFiltered(numberPerPage, offset, search);
                if (sheets.Count <= 0) return NoContent();
                else return Ok(sheets);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet]
        [ActionName("One")]
        public async Task<IActionResult> GetAll(int sheet_pk)
        {
            try
            {
                Sheet sheet = await SheetService.GetSheet(sheet_pk);
                if (sheet == null) return NoContent();
                else return Ok(sheet);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet]
        [ActionName("Number")]
        public async Task<IActionResult> GetNumberSheet()
        {
            try
            {
                return Ok(await SheetService.GetNumberSheet());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet]
        [ActionName("NumberFiltered")]
        public async Task<IActionResult> GetNumberSheetFiltered(string search)
        {
            try
            {
                return Ok(await SheetService.GetNumberSheetFiltered(search));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost]
        [ActionName("Create")]
        public async Task<IActionResult> Create(CreateSheetDTO sheet)
        {
            try
            {
                await SheetService.CreateSheet(new Sheet(sheet));
                return Ok();
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut]
        [ActionName("Update")]
        public async Task<IActionResult> Update(UpdateSheetDTO sheet)
        {
            try
            {
                if (await SheetService.UpdateSheet(new Sheet(sheet))) return Ok();
                else return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete]
        [ActionName("Delete")]
        public async Task<IActionResult> Delete(int sheet_pk)
        {
            try
            {
                Console.WriteLine( "pk = " + sheet_pk);
                if (await SheetService.DeleteSheet(sheet_pk)) return Ok();
                else return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
