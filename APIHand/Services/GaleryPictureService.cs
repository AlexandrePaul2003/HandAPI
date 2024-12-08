using APIHand.Data;
using APIHand.Entities;
using Microsoft.EntityFrameworkCore;

namespace APIHand.Services
{
    public class GaleryPictureService
    {
        private static readonly DataContext context = new DataContext();

        public static async Task<List<GaleryPicture>> GetAllGaleryPictures()
        {
            try
            {
                return await context.GaleryPicture.ToListAsync<GaleryPicture>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static async Task<List<GaleryPicture>> GetGaleryPicturesBySubjectPk(int subject_pk)
        {
            try
            {
                return await context.GaleryPicture.Where(p => p.GallerySubject_PK == subject_pk).ToListAsync<GaleryPicture>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /*public static async Task<GalerySubject> GetOneGaleryPictures(int galery_pk)
        {
            try
            {
                return await context.GalerySubjects.FindAsync(galery_pk);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }*/
        public static async Task AddGaleryPicture(GaleryPicture picture)
        {
            try
            {
                context.GaleryPicture.AddAsync(picture);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static async Task<bool> UpdateGaleryPicture(GaleryPicture picture)
        {

            try
            {
                GaleryPicture DbPicture = await context.GaleryPicture.FindAsync(picture.Id);
                if (DbPicture == null)
                {
                    return false;
                }
                DbPicture.Picture = picture.Picture;
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static async Task<bool> DeleteGaleryPicture(int picture_pk)
        {
            try
            {
                GaleryPicture DbPicture = await context.GaleryPicture.FindAsync(picture_pk);
                if (DbPicture == null)
                {
                    return false;
                }
                context.GaleryPicture.Remove(DbPicture);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static async Task<bool> DeleteGaleryPicturesOfSubject(int subject_pk)
        {
            try
            {
                GalerySubject DbSubject = await context.GalerySubjects.FindAsync(subject_pk);
                if (DbSubject == null)
                {
                    return false;
                }
                context.GaleryPicture.RemoveRange(context.GaleryPicture.Where(s => s.GallerySubject_PK == subject_pk));
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
