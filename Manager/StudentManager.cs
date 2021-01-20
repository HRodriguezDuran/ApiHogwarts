using DTO;
using Interface.Manager;
using Interface.Repository;
using Repository.Entities;

namespace Manager
{
    public class StudentManager : IStudentManager
    {
        private readonly IStudentRepository _studentRepository;

        public StudentManager(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public StudentDTO Create(StudentDTO dto)
        {
            StudentEntity entity = ToEntity(dto);
            entity.Id = 0;
            return ToDTO(_studentRepository.Create(entity));
        }

        public StudentDTO Update(StudentDTO dto)
        {
            StudentEntity entity = ToEntity(dto);
            return ToDTO(_studentRepository.Update(entity));
        }

        public StudentDTO Get(StudentDTO dto)
        {
            StudentEntity result = _studentRepository.Get(ToEntity(dto));

            return result != null ? ToDTO(result) : null;
        }

        private StudentDTO ToDTO(StudentEntity entity)
        {
            return new StudentDTO
            {
                Age = entity.Age,
                House = entity.House,
                Id = entity.Id,
                IdentificationNumber = entity.IdentificationNumber,
                LastName = entity.LastName,
                Name = entity.Name
            };
        }

        private StudentEntity ToEntity(StudentDTO dto)
        {
            return new StudentEntity
            {
                Age = dto.Age,
                House = dto.House,
                Id = dto.Id,
                IdentificationNumber = dto.IdentificationNumber,
                LastName = dto.LastName,
                Name = dto.Name
            };
        }
    }
}
