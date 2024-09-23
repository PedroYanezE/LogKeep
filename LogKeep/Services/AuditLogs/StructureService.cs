using LogKeep.Models.AuditLogs;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;

namespace LogKeep.Services.AuditLogs
{
    public class StructureService : IStructureService
    {
        private readonly LogKeepDbContext _context;

        public StructureService(LogKeepDbContext context)
        {
            _context = context;
        }

        public async Task AddStructure(Structure structure)
        {
            await _context.Structures.AddAsync(structure);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStructure(Structure structure)
        {
            _context.Structures.Remove(structure);
            await _context.SaveChangesAsync();
        }

        public async Task EditStructure(Structure structure)
        {
            var structureToUpdate = await _context.Structures
                .FirstOrDefaultAsync(s => s.Id == structure.Id);

            if (structureToUpdate != null)
            {
                structureToUpdate.Name = structure.Name;
                structure.Fields = structure.Fields;

                _context.Structures.Update(structureToUpdate);

                await _context.SaveChangesAsync();
            } else
            {
                throw new ArgumentException("Structure not found");
            }
        }

        public IQueryable<Structure> GetAllStructures()
        {
            return _context.Structures
                .OrderByDescending(s => s.Id)
                .Take(20)
                .AsNoTracking();
        }

        public async Task<Structure?> GetStructureById(ObjectId id)
        {
            return await _context.Structures
                .FirstAsync(s => s.Id == id);
        }
    }
}
