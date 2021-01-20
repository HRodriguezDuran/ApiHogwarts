using DTO;
using Interface.Bussines;
using Interface.Manager;

namespace Business
{
    public class StudentService : IStudentService
    {
        private readonly IStudentManager _studentManager;

        public StudentService(IStudentManager studentManager)
        {
            _studentManager = studentManager;
        }

        public StudentDTO Create(StudentDTO dto)
        {
            return _studentManager.Create(dto);
        }

        public StudentDTO Update(StudentDTO dto)
        {
            StudentDTO studentExists = Get(dto.Id);

            if (studentExists == null)
            {
                return null;
            }

            return _studentManager.Update(dto);
        }

        public StudentDTO Get(int id)
        {
            return _studentManager.Get(new StudentDTO { Id = id});
        }
    }
}
