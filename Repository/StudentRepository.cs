using Interface.Repository;
using Repository.Entities;
using System.Linq;

namespace Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;

        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public StudentEntity Create(StudentEntity entity)
        {
            _context.Add(entity);
            _context.SaveChanges();

            return entity;
        }

        public StudentEntity Update(StudentEntity entity)
        {
            _context.Update(entity);
            _context.SaveChanges();

            return entity;
        }

        public StudentEntity Get(StudentEntity entity)
        {
            return _context.Students.Where(e => e.Id == entity.Id).FirstOrDefault();
        }
    }
}
