using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace LogKeep.Models.AuditLogs
{
    public class CreateStructureDto
    {
        [Required(ErrorMessage = "You must provide a name")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "You must provide at least one field")]
        public List<Field>? Fields { get; set; }
    }

    public class CreateFieldDto
    {
        [Required(ErrorMessage = "You must provide a field name")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "You must provide a field datatype")]
        public string? DataType { get; set; }
    }
}
