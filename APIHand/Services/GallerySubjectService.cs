using APIHand.Data;
using APIHand.Entities;
using APIHand.Entities.DTO.GalerySubject;
using Microsoft.EntityFrameworkCore;

namespace APIHand.Services
{
    public class GallerySubjectService
    {
        private static readonly DataContext context = new DataContext();

        public static async Task<List<GalerySubject>> GetAllGalerySubjects()
        {
            try
            {
                return await context.GalerySubjects.ToListAsync<GalerySubject>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static async Task<GalerySubject> GetOneGalerySubjects(int galery_pk)
        {
            try
            {
                return await context.GalerySubjects.FindAsync(galery_pk);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static async Task AddGalerySubject(GalerySubject subject)
        {
            try
            {
                context.GalerySubjects.AddAsync(subject);
                context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public static async Task<bool> UpdateGalerySubject(GalerySubject subject)
        {

            try
            {
                GalerySubject Dbsubject = await context.GalerySubjects.FindAsync(subject.Id);
                if (Dbsubject == null)
                {
                    return false;
                }
                Dbsubject.Desc = subject.Desc;
                Dbsubject.Name = subject.Name;
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static async Task<bool> DeleteGalerySubject(int subject_pk)
        {
            try
            {
                GalerySubject Dbsubject = await context.GalerySubjects.FindAsync(subject_pk);
                if (Dbsubject == null)
                {
                    return false;
                }
                context.GalerySubjects.Remove(Dbsubject);
                context.SaveChanges();
                await GaleryPictureService.DeleteGaleryPicturesOfSubject(subject_pk);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
