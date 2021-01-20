using Repository.Entities;
using System.Threading.Tasks;

namespace Interface.Repository
{
    public interface IStudentRepository
    {
        public RequestEntity Create(RequestEntity entity);

        public Task<int> DeleteAsync(RequestEntity entity);

        public RequestEntity Update(RequestEntity entity);

        public RequestEntity Get(RequestEntity entity);
    }
}
