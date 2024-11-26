using APIHand.Entities.DTO.Command;

namespace APIHand.Entities
{
    public class Command
    {
        public int Id {  get; set; }
        public double price { get; set; }
        public string? communication {  get; set; }
        public int sheet_pk { get; set; }

        public Command()
        {
                
        }
        public Command(CreateCommandDTO command)
        {
            this.communication = command.communication;
            this.price = command.price;
            this.sheet_pk = command.sheet_pk;
            this.Id = 0;
        }



    }
}
