using DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Interface.Bussines
{
    public interface IStudentService
    {
        public Task<RequestDTO> CreateAsync(RequestDTO dto);

        public Task<int> DeleteAsync(int id);

        public RequestDTO Get(int id);

        public ICollection<RequestDTO> Get();

        public Task<RequestDTO> UpdateAsync(RequestDTO dto);
    }
}
