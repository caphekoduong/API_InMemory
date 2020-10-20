using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_THC_Inventory.Models;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

namespace API_THC_Inventory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeightManagersController : ControllerBase
    {
        private readonly WeightManagerContext _context;

        public WeightManagersController(WeightManagerContext context)
        {
            _context = context;
        }

        // GET: api/WeightManagers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WeightManager>>> GetWeightManagers()
        {
            return await _context.WeightManagers.ToListAsync();
           
        }

        // GET: api/WeightManagers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WeightManager>> GetWeightManager(long id)
        {
            var weightManager = await _context.WeightManagers.FindAsync(id);

            if (weightManager == null)
            {
                return NotFound();
            }

            return weightManager;
        }

        // PUT: api/WeightManagers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWeightManager(long id, WeightManager weightManager)
        {
            if (id != weightManager.Id)
            {
                return BadRequest();
            }

            _context.Entry(weightManager).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WeightManagerExists(id))
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

        // POST: api/WeightManagers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<WeightManager>> PostWeightManager(WeightManager weightManager)
        {
            _context.WeightManagers.Add(weightManager);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetWeightManager", new { id = weightManager.Id }, weightManager);
            return CreatedAtAction(nameof(GetWeightManager), new { id = weightManager.Id }, weightManager);
        }

        // DELETE: api/WeightManagers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WeightManager>> DeleteWeightManager(long id)
        {
            var weightManager = await _context.WeightManagers.FindAsync(id);
            if (weightManager == null)
            {
                return NotFound();
            }

            _context.WeightManagers.Remove(weightManager);
            await _context.SaveChangesAsync();

            return weightManager;
        }

        private bool WeightManagerExists(long id)
        {
            return _context.WeightManagers.Any(e => e.Id == id);
        }
    }
}
