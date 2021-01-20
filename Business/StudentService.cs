using DTO;
using Interface.Bussines;
using Interface.Manager;
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

        public RequestDTO Create(RequestDTO dto)
        {
            return _studentManager.Create(dto);
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _studentManager.DeleteAsync(new RequestDTO { Id = id });
        }

        public RequestDTO Get(int id)
        {
            return _studentManager.Get(new RequestDTO { Id = id});
        }

        public RequestDTO Update(RequestDTO dto)
        {
            RequestDTO studentExists = Get(dto.Id);

            if (studentExists == null)
            {
                return null;
            }

            return _studentManager.Update(dto);
        }
    }
}
