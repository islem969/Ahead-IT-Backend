using Microsoft.EntityFrameworkCore;
using Register.Context;
using Register.Models;

namespace Register.Service
{
    public class CareerService : ICareerService
    {
        private readonly AppDbContext _context;
        public CareerService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Carrier> AddCarrierAsync(Carrier carrier)
        {
            carrier.CreatedAt = DateTime.Now;
            carrier.UpdatedAt = DateTime.Now;

            _context.Carrieres.Add(carrier);
         
            carrier.User.QualificationId = carrier.QualificationId;
            carrier.User.Qualification  = carrier.Qualification ;

            carrier.User.Civil_StatusId = carrier.Civil_StatusId;


            Console.WriteLine("ID Civil");
            Console.WriteLine(carrier.Civil_StatusId);
            carrier.User.Civil_Status = carrier.Civil_Status;
            await _context.SaveChangesAsync();

            return carrier;
        }

        public async Task DeleteCarrierAsync(int id)
        {
            var carrier = await _context.Carrieres.FindAsync(id);
            if (carrier != null)
            {
                _context.Carrieres.Remove(carrier);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Carrier>> GetAllCarriersAsync()
        {
            
             return await _context.Carrieres.ToListAsync();
            
        }

        public async Task<Carrier> GetCarrierByIdAsync(int id)
        {
           
                return await _context.Carrieres.FindAsync(id);
            
        }

        public async Task<IEnumerable<Carrier>> GetCarriersByUserIdAsync(int userId)
        {
            return await _context.Carrieres.Where(c => c.UserId == userId).ToListAsync();

        }

        public async Task<Carrier> UpdateCarrierAsync(int id, Carrier carrier)
        {
            var existingCarrier = await _context.Carrieres.FindAsync(id);
            if (existingCarrier == null)
            {
                return null;
            }

            existingCarrier.Salary = carrier.Salary;
            existingCarrier.Bban = carrier.Bban;
            existingCarrier.From = carrier.From;
            existingCarrier.To = carrier.To;
            existingCarrier.RIB = carrier.RIB;
            existingCarrier.Qualification = carrier.Qualification;
            existingCarrier.Civil_Status = carrier.Civil_Status;
            existingCarrier.UpdatedAt = DateTime.Now;

            _context.Carrieres.Update(existingCarrier);
           // User.qualification = Carrier.qualification;
            await _context.SaveChangesAsync();
            return existingCarrier;
        }
    }
}
