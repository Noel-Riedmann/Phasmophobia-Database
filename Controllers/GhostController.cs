using PhasmophobiaDatabase.Data;

namespace PhasmophobiaDatabase.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using PhasmophobiaDatabase.Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [ApiController]
    [Route("api/[controller]")]
    public class GhostController : ControllerBase
    {
        private readonly AppDbContext _context;

        public GhostController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetGhosts()
        {
            var ghosts = await _context.Ghosts
                .Include(g => g.Evidence)
                .Include(g => g.Speed)
                .Include(g => g.SanityThreshold)
                .ToListAsync();

            return Ok(ghosts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Ghost>> GetGhostById(int id)
        {
            var ghost = await _context.Ghosts
                .Include(g => g.Evidence)
                .Include(g => g.Speed)
                .Include(g => g.SanityThreshold)
                .FirstOrDefaultAsync(g => g.GhostId == id);

            if (ghost == null)
            {
                return NotFound();
            }

            return Ok(ghost);
        }

        [HttpPost]
        public async Task<ActionResult<Ghost>> AddGhost(Ghost ghost)
        {
            _context.Ghosts.Add(ghost);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetGhostById), new { id = ghost.GhostId }, ghost);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGhost(int id, Ghost updatedGhost)
        {
            var ghost = await _context.Ghosts.FindAsync(id);

            if (ghost == null)
            {
                return NotFound();
            }

            ghost.Name = updatedGhost.Name;
            ghost.JournalInfo = updatedGhost.JournalInfo;
            ghost.Strengths = updatedGhost.Strengths;
            ghost.Weaknesses = updatedGhost.Weaknesses;
            ghost.Behaviour = updatedGhost.Behaviour;
            ghost.Test = updatedGhost.Test;

            _context.Entry(ghost).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGhost(int id)
        {
            var ghost = await _context.Ghosts.FindAsync(id);

            if (ghost == null)
            {
                return NotFound();
            }

            _context.Ghosts.Remove(ghost);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }

}
