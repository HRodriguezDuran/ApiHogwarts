using DTO;
using Interface.Manager;
using Interface.Repository;
using Repository.Entities;
using System.Threading.Tasks;

namespace Manager
{
    public class StudentManager : IStudentManager
    {
        private readonly IStudentRepository _studentRepository;

        public StudentManager(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<int> DeleteAsync(RequestDTO dto)
        {
            RequestEntity entity = ToEntity(dto);
            return await _studentRepository.DeleteAsync(entity);
        }

        public RequestDTO Create(RequestDTO dto)
        {
            RequestEntity entity = ToEntity(dto);
            entity.Id = 0;
            return ToDTO(_studentRepository.Create(entity));
        }

        public RequestDTO Get(RequestDTO dto)
        {
            RequestEntity result = _studentRepository.Get(ToEntity(dto));

            return result != null ? ToDTO(result) : null;
        }

        public RequestDTO Update(RequestDTO dto)
        {
            RequestEntity entity = ToEntity(dto);
            return ToDTO(_studentRepository.Update(entity));
        }

        private RequestDTO ToDTO(RequestEntity entity)
        {
            return new RequestDTO
            {
                Age = entity.Age,
                House = entity.House,
                Id = entity.Id,
                IdentificationNumber = entity.IdentificationNumber,
                LastName = entity.LastName,
                Name = entity.Name
            };
        }

        private RequestEntity ToEntity(RequestDTO dto)
        {
            return new RequestEntity
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
