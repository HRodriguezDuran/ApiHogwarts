using DTO;

namespace Interface.Bussines
{
    public interface IStudentService
    {
        public StudentDTO Create(StudentDTO dto);


        public StudentDTO Update(StudentDTO dto);

        public StudentDTO Get(int id);
    }
}
