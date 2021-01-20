using Repository.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Interface.Repository
{
    public interface IStudentRepository
    {
        public Task<RequestEntity> CreateAsync(RequestEntity entity);

        public Task<int> DeleteAsync(RequestEntity entity);

        public ICollection<RequestEntity> Get();

        public RequestEntity Get(RequestEntity entity);

        public Task<RequestEntity> UpdateAsync(RequestEntity entity);


    }
}
