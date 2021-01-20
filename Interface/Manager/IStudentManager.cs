using DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Interface.Manager
{
    public interface IStudentManager
    {
        public Task<RequestDTO> CreateAsync(RequestDTO dto);

        public Task<int> DeleteAsync(RequestDTO dto);

        public ICollection<RequestDTO> Get();

        public RequestDTO Get(RequestDTO dto);

        public Task<RequestDTO> UpdateAsync(RequestDTO dto);
    }
}
