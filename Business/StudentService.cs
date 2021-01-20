using DTO;
using Interface.Bussines;
using Interface.Manager;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business
{
    public class StudentService : IStudentService
    {
        private readonly IStudentManager _studentManager;

        public StudentService(IStudentManager studentManager)
        {
            _studentManager = studentManager;
        }

        public async Task<RequestDTO> CreateAsync(RequestDTO dto)
        {
            return await _studentManager.CreateAsync(dto);
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _studentManager.DeleteAsync(new RequestDTO { Id = id });
        }

        public RequestDTO Get(int id)
        {
            return _studentManager.Get(new RequestDTO { Id = id});
        }

        public ICollection<RequestDTO>  Get()
        {
            return _studentManager.Get();
        }

        public async Task<RequestDTO> UpdateAsync(RequestDTO dto)
        {
            return await _studentManager.UpdateAsync(dto);
        }
    }
}
