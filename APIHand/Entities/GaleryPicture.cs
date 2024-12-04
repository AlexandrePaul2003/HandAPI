using APIHand.Entities.DTO.GaleryPicture;

namespace APIHand.Entities
{
    public class GaleryPicture
    {
        public int Id { get; set; }
        public Byte[] Picture { get; set; }
        public int GallerySubject_PK { get; set; }
        public GaleryPicture()
        {
            
        }
        public GaleryPicture(CreateGaleryPictureDTO picture)
        {
            this.Id = 0;
            this.Picture = picture.Picture;
            this.GallerySubject_PK = picture.GallerySubject_PK;
        }
    }
}
