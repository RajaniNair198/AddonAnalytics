using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AddonAnalytics.Core.Models;
using AddonAnalyticsAPI.Core.Models;
using Serilog;

namespace AddonAnalyticsAPI.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddOnsController : ControllerBase
    {
        private readonly AddOnAPIDBContext _context;

        public AddOnsController(AddOnAPIDBContext context)
        {
            _context = context;
        }

        // GET: api/AddOns
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AddOn>>> GetAllAddOns()
        {
            //Log.Information("Inside the method GETAllAddOns");
            if (_context.AddOn == null)
          {
              return NotFound();
          }
            return await _context.AddOn.ToListAsync();
        }

        //// GET: api/AddOns/5
        //[HttpGet("{Id}")]
        //public async Task<ActionResult<AddOn>> GetAddOnById(Guid id)
        //{
        //    if (_context.AddOn == null)
        //    {
        //        return NotFound();
        //    }
        //    var addOn = await _context.AddOn.FindAsync();

        //    if (addOn == null)
        //    {
        //        return NotFound();
        //    }

        //    return addOn;
        //}

        // GET: api/AddOns/5
        [HttpGet("{userId}")]
        public async Task<ActionResult<IEnumerable<AddOn>>> GetAddOnsByUserId(int userId)
        {
          if (_context.AddOn == null)
          {
              return NotFound();
          }
            var addOns = await _context.AddOn.Where(x => x.AddOnUserId == userId).ToListAsync();

            if (addOns == null)
            {
                return NotFound();
            }

            return addOns;
        }

        // GET: api/AddOns/5
        [HttpGet("{archicadVersion}/{userId}")]
        public async Task<ActionResult<IEnumerable<AddOn>>> GetAddOnsByACVersion(ArchicadVersionEnum archicadVersion, int userId)
        {
            if (_context.AddOn == null)
            {
                return NotFound();
            }
            var addOn = await _context.AddOn.Where(x => x.ArchicadVersion == archicadVersion && x.AddOnUserId == userId).ToListAsync();

            if (addOn == null)
            {
                return NotFound();
            }

            return addOn;
        }


        //// PUT: api/AddOns/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutAddOn(Guid id, AddOn addOn)
        //{
        //    if (id != addOn.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(addOn).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!AddOnExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/AddOns
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AddOn>> PostAddOn(AddOn addOn)
        {
          if (_context.AddOn == null)
          {
              return Problem("Entity set 'AddOnAPIDBContext.AddOn'  is null.");
          }
            _context.AddOn.Add(addOn);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAddOnsByUserId", new { id = addOn.Id, userId = addOn.AddOnUserId }, addOn);
        }

        //// DELETE: api/AddOns/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteAddOn(Guid id)
        //{
        //    if (_context.AddOn == null)
        //    {
        //        return NotFound();
        //    }
        //    var addOn = await _context.AddOn.FindAsync(id);
        //    if (addOn == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.AddOn.Remove(addOn);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        private bool AddOnExists(Guid id)
        {
            return (_context.AddOn?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
