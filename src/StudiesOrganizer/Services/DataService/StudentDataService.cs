using Microsoft.EntityFrameworkCore;
using StudiesOrganizer.Database;
using StudiesOrganizer.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudiesOrganizer.Services.DataService
{
    public class StudentDataService : IDataService<Student>
    {
        private readonly StudiesOrganizerDbContext _dbCotext;

        public StudentDataService(StudiesOrganizerDbContext dbCotext)
        {
            _dbCotext = dbCotext;
        }
        public async Task Create(Student entity)
        {
            entity.CreationDate = DateTime.Now;

            await _dbCotext.Students.AddAsync(entity)
                .ConfigureAwait(true);

            await _dbCotext.SaveChangesAsync()
                .ConfigureAwait(true);
        }

        public async Task Delete(Student entity)
        {
            _dbCotext.Students.Remove(entity);

            await _dbCotext.SaveChangesAsync()
                .ConfigureAwait(true);
        }

        public async Task<Student> Get(int id)
        {
            return await _dbCotext.Students
                .Include(s => s.StudentSubjects)
                .ThenInclude(ss => ss.Subject)
                .FirstOrDefaultAsync(s => s.Id == id)
                .ConfigureAwait(true);
        }

        public async Task<IEnumerable<Student>> GetAll()
        {
            return await _dbCotext.Students
                .Include(s => s.StudentSubjects)
                .ThenInclude(ss => ss.Subject)
                .ToListAsync()
                .ConfigureAwait(true);
        }

        public async Task Update(Student entity)
        {
            _dbCotext.Students.Update(entity);

            await _dbCotext.SaveChangesAsync()
                .ConfigureAwait(true);
        }
    }
}
