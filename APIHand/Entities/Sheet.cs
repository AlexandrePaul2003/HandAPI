using APIHand.Entities.DTO.Sheets;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APIHand.Entities
{
    public class Sheet
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public string? Communication {  get; set; }
        [NotMapped]
        public List<Command> Commands { get; set; }
        [NotMapped]
        public double Total { get; set; }
        public Sheet(CreateSheetDTO sheet)
        {
           this.Name = sheet.Name;
            this.Communication = sheet.Communication;
            this.Commands = new List<Command>();
            this.Id = 0;
        }
        public Sheet(UpdateSheetDTO sheet)
        {
            this.Id = sheet.Id;
            this.Name = sheet.Name;
            this.Communication = sheet.Communication;
            this.Commands = new List<Command>();
        }
        public Sheet()
        {
                
        }
    }
}
