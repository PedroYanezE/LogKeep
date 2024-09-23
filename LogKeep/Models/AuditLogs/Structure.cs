using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace LogKeep.Models.AuditLogs
{
    [Collection("structures")]
    public class Structure
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [Required(ErrorMessage = "You must provide a name")]
        [Display(Name = "Name")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "You must provide at least one field")]
        [Display(Name = "Fields")]
        public List<Field>? Fields { get; set; }
    }

    public class Field
    {
        public string? Name { get; set; }
        public string? DataType { get; set; }
    }
}
