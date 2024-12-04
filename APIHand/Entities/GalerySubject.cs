using APIHand.Entities.DTO.GalerySubject;

namespace APIHand.Entities
{
    public class GalerySubject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Desc { get; set; }
        public GalerySubject(CreateGalerySubjectDTO subject)
        {
            this.Id = 0;
            this.Name = subject.Name;
            this.Desc = subject.Desc;
        }
        public GalerySubject()
        {
                
        }
    }
}
