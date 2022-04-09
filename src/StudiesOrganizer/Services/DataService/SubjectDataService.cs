using Microsoft.EntityFrameworkCore;
using StudiesOrganizer.Database;
using StudiesOrganizer.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudiesOrganizer.Services.DataService
{
    public class SubjectDataService : IDataService<Subject>
    {
        private readonly StudiesOrganizerDbContext _dbCotext;

        public SubjectDataService(StudiesOrganizerDbContext dbCotext)
        {
            _dbCotext = dbCotext;
        }
        public async Task Create(Subject entity)
        {
            entity.CreationDate = DateTime.Now;

            await _dbCotext.Subjects.AddAsync(entity)
                .ConfigureAwait(true);

            await _dbCotext.SaveChangesAsync()
                .ConfigureAwait(true);
        }

        public async Task Delete(Subject entity)
        {
            _dbCotext.Subjects.Remove(entity);

            await _dbCotext.SaveChangesAsync()
                .ConfigureAwait(true);
        }

        public async Task<Subject> Get(int id)
        {
            return await _dbCotext.Subjects
                .Include(s => s.StudentSubjects)
                .ThenInclude(ss => ss.Student)
                .FirstOrDefaultAsync(s => s.Id == id)
                .ConfigureAwait(true);
        }

        public async Task<IEnumerable<Subject>> GetAll()
        {
            return await _dbCotext.Subjects
                .Include(s => s.StudentSubjects)
                .ThenInclude(ss => ss.Student)
                .ToListAsync()
                .ConfigureAwait(true);
        }

        public async Task Update(Subject entity)
        {
            _dbCotext.Subjects.Update(entity);

            await _dbCotext.SaveChangesAsync()
                .ConfigureAwait(true);
        }
    }
}
