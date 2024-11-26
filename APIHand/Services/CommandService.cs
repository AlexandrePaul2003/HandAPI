using APIHand.Data;
using Command = APIHand.Entities.Command;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace APIHand.Services
{
    public class CommandService
    {
        private static readonly DataContext context = new DataContext();

        public static async Task<List<Command>> GetCommands()
        {
            try
            {
                return await context.Commands.ToListAsync<Command>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static async Task<Command> GetCommand(int command_pk)
        {
            try
            {
                return await context.Commands.FindAsync(command_pk);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static async Task AddCommand(Command command)
        {
            //TODO : verify is the sheet_pk exist 
            try
            {
                if (await SheetService.GetSheet(command.sheet_pk) == null) throw new Exception("Corresponding sheet was not found");
                await context.Commands.AddAsync(command);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static async Task<bool> UpdateCommand(Command command)
        {
            try
            {

                Command dbCommand = await context.Commands.FindAsync(command.Id);
                if (dbCommand == null) return false;
                dbCommand.price = command.price;
                dbCommand.communication = command.communication;
                //dbCommand.sheet_pk = command.sheet_pk;
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static async Task<bool> DeleteCommand(int command_pk)
        {
            try
            {

                Command dbCommand = await context.Commands.FindAsync(command_pk);
                if (dbCommand == null) return false;
                context.Commands.Remove(dbCommand);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static async Task<List<Command>> GetSheetCommand(int sheet_pk, int limit)
        {
            try
            {
                return await context.Commands.Where(a => a.sheet_pk == sheet_pk).OrderByDescending(c => c.Id).Take(limit).ToListAsync<Command>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static async Task<double> GetPersonTotalCommand(int sheet_pk)
        {
            try
            {
                return await context.Commands.Where(a => a.sheet_pk == sheet_pk).SumAsync(c => c.price);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static async Task<double> GetGlobalTotalCommand()
        {
            DataContext _context = new DataContext();
            try
            {
                return await _context.Commands.SumAsync(c => c.price);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
