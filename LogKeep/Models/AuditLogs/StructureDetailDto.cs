namespace LogKeep.Models.AuditLogs
{
    public class StructureDetailDto
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public List<Field>? Fields { get; set; }

        public static StructureDetailDto FromStructure(Structure structure)
        {
            return new StructureDetailDto
            {
                Id = structure.Id.ToString(),
                Name = structure.Name,
                Fields = structure.Fields
            };
        }
    }
}
