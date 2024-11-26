using APIHand.Entities.DTO.Member;

namespace APIHand.Entities
{
    public class Member
    {
        public Member(){}
        public int Id { get; set; }
        public int Order {  get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public string Type { get; set; }
        public string Bio { get; set; }
        public Byte[] Picture { get; set; }
        public Member(CreateMemberDTO member)
        {
            this.Order = member.Order;
            this.Name = member.Name;
            this.Type = member.Type;
            this.Role = member.Role;
            this.Bio = member.Bio;
            this.Picture = member.Picture;
        }
    }
}
