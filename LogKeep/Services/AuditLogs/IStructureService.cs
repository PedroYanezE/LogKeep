using LogKeep.Models.AuditLogs;
using MongoDB.Bson;

namespace LogKeep.Services.AuditLogs
{
    public interface IStructureService
    {
        IQueryable<Structure> GetAllStructures();
        Task<Structure?> GetStructureById(ObjectId id);
        Task AddStructure(Structure newStructure);
        Task EditStructure(Structure updatedStructure);
        Task DeleteStructure(Structure structureToDelete);
    }
}
