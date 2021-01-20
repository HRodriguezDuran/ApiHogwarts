using DTO;
using System.Threading.Tasks;

namespace Interface.Manager
{
    public interface IStudentManager
    {
        public RequestDTO Create(RequestDTO dto);

        public Task<int> DeleteAsync(RequestDTO dto);

        public RequestDTO Get(RequestDTO dto);

        public RequestDTO Update(RequestDTO dto);
    }
}
