using EMS.API.DbContexts;
using EMS.API.Entities.DB4_Entities;

namespace EMS.API.Services.TeacherService
{
    public class Teacherservice : ITeacherService
    {
        public readonly StudentDbContext _context;
        public Teacherservice(StudentDbContext context)
        {
            _context = context;
        }

        public async Task<Teacher> AddTeacherAsync(Teacher teacher)
        {
            _context.Teachers.Add(teacher);
            await  _context.SaveChangesAsync();
            return teacher;
        }
    }
}
