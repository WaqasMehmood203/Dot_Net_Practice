using EMS.API.DbContexts;
using EMS.API.Entities.DB2_Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace EMS.API.Services.UserServices
{
    public class UserService : IUserService
    {
        public readonly LogsDbContext _context;
        public UserService(LogsDbContext context)
        {
            _context = context;
        }

        public async Task<User> AddUserAsync(User user)
        {
            if (user == null)
                return null;

            user.Id = Guid.NewGuid();
            if (user.Address != null)
            {
                user.Address.Id = Guid.NewGuid();
                user.Address.UserId = user.Id;
            }

            if (user.ContactInformation != null)
            {
                user.ContactInformation.Id = Guid.NewGuid();
                user.ContactInformation.UserId = user.Id;
            }

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            UserLogHistory userLogHistory1 = new UserLogHistory
            {
                Id = Guid.NewGuid(),
                UserId = user.Id,
                ActionTime = DateTime.UtcNow,
                ActionType = "Create",
                Description = $"User {user.Name} Added Successfully."
            };
            _context.UserLogHistories.Add(userLogHistory1);
            await _context.SaveChangesAsync();
            return user;
        }
        public async Task<User> UpdateUserAsync(Guid id, User user)
        {
            var existinguser = await _context.Users.FindAsync(id);
            if (existinguser == null)
                return null;

            existinguser.Name = user.Name;
            existinguser.DOB = user.DOB;
            if (user.Address != null)
            {
                var existingAddress = await _context.Addresses
                    .FirstOrDefaultAsync(a => a.UserId == id);

                if (existingAddress != null)
                {
                    existingAddress.HomeAddress = user.Address.HomeAddress;
                    existingAddress.CurrentAddress = user.Address.CurrentAddress;
                    //existingAddress.CityCode = user.Address.CityCode;
                    //existingAddress.CountyCode = user.Address.CountyCode;
                    existingAddress.City = user.Address.City;
                    existingAddress.Country = user.Address.Country;
                    existingAddress.State = user.Address.State;
                    existingAddress.StreetNumber = user.Address.StreetNumber;
                }
            }

            if (user.ContactInformation != null)
            {
                var existingContact = await _context.ContactInformations
                    .FirstOrDefaultAsync(c => c.UserId == id);

                if (existingContact != null)
                {
                    existingContact.PhoneNumber = user.ContactInformation.PhoneNumber;
                    existingContact.Email = user.ContactInformation.Email;
                    existingContact.Fax = user.ContactInformation.Fax;
                    existingContact.LinkedinId = user.ContactInformation.LinkedinId;
                }
            }

            await _context.SaveChangesAsync();

            UserLogHistory userLogHistory = new UserLogHistory
            {
                Id = Guid.NewGuid(),
                UserId = existinguser.Id,
                ActionTime = DateTime.UtcNow,
                ActionType = "Update",
                Description = $"User {existinguser.Name} updated successfully."
            };
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> DeleteUserAsync(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return false;
            }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            UserLogHistory userLogHistory = new UserLogHistory
            {
                Id = Guid.NewGuid(),
                UserId = user.Id,
                ActionTime = DateTime.UtcNow,
                ActionType = "Delete",
                Description = $"User {user.Name} deleted successfully."
            };

            _context.UserLogHistories.Add(userLogHistory);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<User> GetUserByIdAsync(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if(user != null)
            {
                user.Address = await _context.Addresses
               .FirstOrDefaultAsync(a => a.UserId == id);
               user.ContactInformation = await _context.ContactInformations
               .FirstOrDefaultAsync(c => c.UserId == id);
            }
            return user;
        }

        public async Task<List<User>> GetAllUserAsync()
        {
            var users = _context.Users.ToList();
            foreach (var user in users)
            {
                user.Address = await _context.Addresses
                    .FirstOrDefaultAsync(a => a.UserId == user.Id);

                user.ContactInformation = await _context.ContactInformations
                    .FirstOrDefaultAsync(c => c.UserId == user.Id);
            }
            return users;
        }
    }
}
