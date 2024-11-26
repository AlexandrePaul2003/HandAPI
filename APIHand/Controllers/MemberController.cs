using APIHand.Entities;
using APIHand.Entities.DTO.Member;
using APIHand.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIHand.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class MemberController : Controller
    {
        [HttpGet]
        [ActionName("All")]
        public async Task<IActionResult> GetAllMembers()
        {
            try
            {
                List<Member> members = await MemberService.GetAllMembers();
                if (members == null || members.Count <= 0) return NoContent();
                else return Ok(members);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet]
        [ActionName("ByType")]
        public async Task<IActionResult> GetMembersByType(string type)
        {
            try
            {
                List<Member> members = await MemberService.GetMembersByType(type);
                if (members != null && members.Count <= 0) return NoContent();
                else return Ok(members);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet]
        [ActionName("One")]
        public async Task<IActionResult> GetMemberById(int member_pk)
        {
            try
            {

                Member member = await MemberService.GetMember(member_pk);
                if (member == null) return NoContent(); else return Ok(member);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost]
        [ActionName("Create")]
        public async Task<IActionResult> CreateMember(CreateMemberDTO member)
        {
            try
            {
                await MemberService.AddMember(new Member(member));
                return Created();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut]
        [ActionName("Update")]
        public async Task<IActionResult> UpdateMember(Member member)
        {
            try
            {
                if (await MemberService.UpdateMember(member)) return Ok(); else return NotFound(); 
                
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteMember(int member_pk)
        {
            try
            {
                if (await MemberService.DeleteMember(member_pk)) return Ok(); else return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
