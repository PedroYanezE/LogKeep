namespace LogKeep.Models.AuditLogs
{
    public class StructureListDto
    {
        public string? Id { get; set; }
        public string? Name { get; set; }

        public static StructureListDto FromStructure(Structure structure)
        {
            return new StructureListDto
            {
                Id = structure.Id.ToString(),
                Name = structure.Name
            };
        }
    }
}
