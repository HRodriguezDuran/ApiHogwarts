using DTO;
using System.Threading.Tasks;

namespace Interface.Bussines
{
    public interface IStudentService
    {
        public RequestDTO Create(RequestDTO dto);

        public Task<int> DeleteAsync(int id);

        public RequestDTO Get(int id);

        public RequestDTO Update(RequestDTO dto);
    }
}
