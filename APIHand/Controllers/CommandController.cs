using Command = APIHand.Entities.Command;
using APIHand.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using APIHand.Entities.DTO.Command;

namespace APIHand.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CommandController : Controller
    {
        [HttpGet]
        [ActionName("All")]
        public async Task<IActionResult> GetCommands()
        {
            try
            {
                List<Command> commands = await CommandService.GetCommands();
                if (commands.Count == 0) return NoContent(); 
                else return Ok(commands);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet]
        [ActionName("One")]
        public async Task<IActionResult> GetCommand(int command_pk)
        {
            try
            {
                Console.WriteLine(  command_pk);
                Command command = await CommandService.GetCommand(command_pk);
                if (command == null) return NoContent();
                else return Ok(command);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet]
        [ActionName("TotalGlobal")]
        public async Task<IActionResult> GetGlobalTotalCommand()
        {
            try
            {
                return Ok(await CommandService.GetGlobalTotalCommand());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost]
        [ActionName("Create")]
        public async Task<IActionResult> AddCommand(CreateCommandDTO command)
        {
            try
            {
                await CommandService.AddCommand(new Command(command));
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut]
        [ActionName("Update")]
        public async Task<IActionResult> UpdateCommand(Command command)
        {
            try
            {
                if (await CommandService.UpdateCommand(command)) return Ok();
                else return NotFound();

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteCommand(int command_pk)
        {
            try
            {
                if (await CommandService.DeleteCommand(command_pk)) return Ok();
                else return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
