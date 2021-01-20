using Repository.Entities;

namespace Interface.Repository
{
    public interface IStudentRepository
    {
        public StudentEntity Create(StudentEntity entity);

        public StudentEntity Update(StudentEntity entity);

        public StudentEntity Get(StudentEntity entity);
    }
}
