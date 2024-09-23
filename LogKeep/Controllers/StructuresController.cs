using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LogKeep.Models.AuditLogs;
using LogKeep.Services;
using MongoDB.Bson;
using LogKeep.Services.AuditLogs;

namespace LogKeep.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StructuresController : ControllerBase
    {
        private readonly LogKeepDbContext _context;
        private readonly IStructureService _structureService;

        public StructuresController(
            LogKeepDbContext context,
            IStructureService structureService
        )
        {
            _structureService = structureService;
            _context = context;
        }

        // GET: api/Structures
        [HttpGet]
        public async Task<ActionResult<IQueryable<StructureListDto>>> GetStructures()
        {
            var structures = await _structureService.GetAllStructures().ToListAsync();

            return Ok(structures.Select(StructureListDto.FromStructure));
        }

        // GET: api/Structures/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StructureDetailDto>> GetStructure(ObjectId id)
        {
            var structure = await _structureService.GetStructureById(id);

            if (structure == null)
            {
                return NotFound();
            }

            return StructureDetailDto.FromStructure(structure);
        }

        // PUT: api/Structures/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStructure(ObjectId id, Structure structure)
        {
            if (id != structure.Id)
            {
                return BadRequest();
            }

            _context.Entry(structure).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StructureExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Structures
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Structure>> PostStructure(CreateStructureDto structure)
        {
            Structure newStructure = new()
            {
                Name = structure.Name,
                Fields = structure.Fields
            };

            await _structureService.AddStructure(newStructure);

            return CreatedAtAction("GetStructure", new { id = newStructure.Id }, newStructure);
        }

        // DELETE: api/Structures/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStructure(ObjectId id)
        {
            var structure = await _context.Structures.FindAsync(id);
            if (structure == null)
            {
                return NotFound();
            }

            await _structureService.DeleteStructure(structure);

            return NoContent();
        }

        private bool StructureExists(ObjectId id)
        {
            return _context.Structures.Any(e => e.Id == id);
        }
    }
}
