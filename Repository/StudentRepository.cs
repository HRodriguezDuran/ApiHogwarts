using Interface.Repository;
using Microsoft.Extensions.Logging;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    public class StudentRepository : IStudentRepository
    {
        private const string SQL_ERROR = "Conection to data base failed.";

        private readonly ApplicationDbContext _context;
        private readonly ILogger<StudentRepository> _logger;

        public StudentRepository(ApplicationDbContext context,
            ILogger<StudentRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<RequestEntity> CreateAsync(RequestEntity entity)
        {
            try
            {
                await _context.AddAsync(entity);
                await _context.SaveChangesAsync();

                return entity;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);

                throw new Exception(SQL_ERROR);
            }
        }

        public async Task<int> DeleteAsync(RequestEntity entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();

            return entity.Id;
        }

        public ICollection<RequestEntity> Get()
        {
            try
            {
                return _context.Students.OrderBy(s => s.LastName).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public RequestEntity Get(RequestEntity entity)
        {
            return _context.Students.Where(e => e.Id == entity.Id).FirstOrDefault();
        }

        public async Task<RequestEntity> UpdateAsync(RequestEntity entity)
        {
            try
            {
                if (Exists(entity.Id))
                {
                    _context.Update(entity);
                    await _context.SaveChangesAsync();
                    
                    return entity;
                }

                return null;

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);

                throw new Exception(SQL_ERROR);
            }
        }


        private bool Exists(int id)
        {
            return _context.Students.Any(s => s.Id == id);
        }
    }
}
