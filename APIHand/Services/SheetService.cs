using APIHand.Data;
using APIHand.Entities;
using Microsoft.EntityFrameworkCore;

namespace APIHand.Services
{
    public class SheetService
    {
        private static readonly DataContext context = new DataContext();
        public static async Task<List<Sheet>> GetSheets(int numberPerPage, int offset)
        {
            try
            {
                List<Sheet> sheets = await context.Sheets.Skip(offset).Take(numberPerPage).OrderBy(c => c.Name).ToListAsync();
                double total;
                foreach (Sheet sheet in sheets)
                {
                    sheet.Commands = await CommandService.GetSheetCommand(sheet.Id, 12);
                    sheet.Total = await CommandService.GetPersonTotalCommand(sheet.Id);
                    Console.WriteLine(  sheet.Total);
                }
                return sheets;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static async Task<int> GetNumberSheet()
        {
            try
            {
                DataContext _context = new DataContext();
                return await _context.Sheets.CountAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public static async Task<List<Sheet>> GetSheetsFiltered(int numberPerPage, int offset, string search)
        {
            try
            {
                List<Sheet> sheets = await context.Sheets.Where(a => a.Name.ToLower().Contains(search.ToLower())).Skip(offset).Take(numberPerPage).OrderBy(c => c.Name).ToListAsync();
                double total;
                foreach (Sheet sheet in sheets)
                {
                    sheet.Commands = await CommandService.GetSheetCommand(sheet.Id, 12);
                    sheet.Total = await CommandService.GetPersonTotalCommand(sheet.Id);
                    Console.WriteLine(sheet.Total);
                }
                return sheets;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static async Task<int> GetNumberSheetFiltered(string search)
        {
            try
            {
                DataContext _context = new DataContext();
                return await _context.Sheets.Where(a => a.Name.ToLower().Contains(search.ToLower())).CountAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static async Task<Sheet> GetSheet(int sheet_pk)
        {
            try
            {
                Sheet sheet = await context.Sheets.FindAsync(sheet_pk);
                if (sheet == null) return null;
                sheet.Commands = await CommandService.GetSheetCommand(sheet.Id, 1000000);
                sheet.Total = await CommandService.GetPersonTotalCommand(sheet.Id);
                return sheet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static async Task CreateSheet(Sheet sheet)
        {
            try
            {
                await context.Sheets.AddAsync(sheet);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static async Task<bool> UpdateSheet(Sheet sheet)
        {
            try
            {
                Sheet dbSheet = await context.Sheets.FindAsync(sheet.Id);
                if (dbSheet == null) return false;
                dbSheet.Name = sheet.Name;
                dbSheet.Communication = sheet.Communication;
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static async Task<bool> DeleteSheet(int sheet_pk)
        {
            //Todo : delete commands relative to the deleted sheet
            try
            {
                Sheet sheet = await context.Sheets.FindAsync(sheet_pk);
                if (sheet == null) return false;
                context.Sheets.Remove(sheet);
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
