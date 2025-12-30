using EMS.API.Entities.DB4_Entities;

namespace EMS.API.Services.TeacherService
{
    public interface ITeacherService
    {
        Task<Teacher> AddTeacherAsync(Teacher teacher);
        //Task<Teacher> UpdateTeacherAsync(Guid id, Teacher teacher);
        //Task<bool> DeleteTeacherAsync(Guid id);
        //Task<Teacher> GetTeacherbyid(Guid id);
        //Task<List<Teacher>> GetTeachersAsync();
    }
}
