using EMS.API.Entities.DB2_Entities;

namespace EMS.API.Services.UserServices
{
    public interface IUserService
    {
        public Task<User> AddUserAsync(User user);
        public Task<User> UpdateUserAsync(Guid id, User user);
        public Task<bool> DeleteUserAsync(Guid id);
        public Task<User> GetUserByIdAsync(Guid id);
        public Task<List<User>> GetAllUserAsync();
    }
}
