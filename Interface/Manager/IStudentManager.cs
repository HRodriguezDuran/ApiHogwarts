using DTO;

namespace Interface.Manager
{
    public interface IStudentManager
    {
        public StudentDTO Create(StudentDTO dto);

        public StudentDTO Update(StudentDTO dto);
        public StudentDTO Get(StudentDTO dto);
    }
}
