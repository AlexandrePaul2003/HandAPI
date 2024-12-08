using APIHand.Data;
using APIHand.Entities;
using APIHand.Entities.DTO.Member;
using Microsoft.EntityFrameworkCore;

namespace APIHand.Services
{
    public class MemberService
    {
        private static readonly DataContext context = new DataContext();
        public static async Task<List<Member>> GetAllMembers()
        {
            try
            {
                return await context.Members.OrderBy(m => m.Order).ToListAsync<Member>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static async Task<List<Member>> GetMembersByType(string type)
        {
            try
            {
                return await context.Members.Where(m => m.Type.Equals(type)).OrderBy(m => m.Order).ToListAsync<Member>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static async Task<Member> GetMember(int member_pk)
        {
            try
            {
                return await context.Members.FindAsync(member_pk);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static async Task AddMember(Member member)
        {
            try
            {
                
                if (context.Members.Count() > 0) member.Order = context.Members.Max(m => m.Order) + 1; else member.Order = 0;
                Console.WriteLine("membre " + member.Order);
                await context.Members.AddAsync(member);
                context.SaveChanges();
            }
            catch (Exception ex) { throw ex; }
        }
        public static async Task<bool> UpdateMember(Member member)
        {
            try
            {
                Member dbMember = await context.Members.FindAsync(member.Id);
                if (dbMember == null) return false;
                dbMember.Order = member.Order;
                dbMember.Name = member.Name;
                dbMember.Role = member.Role;
                dbMember.Type = member.Type;
                dbMember.Bio = member.Bio;
                if (dbMember.Picture.Length > 0)  dbMember.Picture = member.Picture;
                context.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public static async Task<bool> DeleteMember(int member_pk)
        {
            try
            {
                Member dbMember = await context.Members.FindAsync(member_pk);
                if (dbMember == null) return false;
                context.Members.Remove(dbMember);
                context.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
