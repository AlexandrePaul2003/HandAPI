namespace APIHand.Entities.DTO.Member
{
    public class CreateMemberDTO
    {
        public int Order { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public string Type { get; set; }
        public string Bio { get; set; }
        public Byte[] Picture { get; set; }
    }
}
