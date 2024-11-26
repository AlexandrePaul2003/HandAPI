namespace APIHand.Entities.DTO.Command
{
    public class CreateCommandDTO
    {
        public double price { get; set; }
        public string? communication { get; set; }
        public int sheet_pk { get; set; }
    }
}
