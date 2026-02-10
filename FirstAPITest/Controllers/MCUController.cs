using FirstAPITest.Data;
using FirstAPITest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstAPITest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MCUController : ControllerBase
    {
        private readonly FirstAPIContext _context;
        public MCUController(FirstAPIContext context) { _context = context; }

        [HttpGet]
        public async Task<ActionResult<List<Microcontroller>>> GetMicrocontroller()
        {
            return Ok(await _context.Microcontrollers.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Microcontroller>> GetMicrocontrollerById(int id)
        {
            var microcontroller = await _context.Microcontrollers.FindAsync(id);
            if (microcontroller == null) return NotFound();

            return Ok(microcontroller);
        }

        [HttpPost]
        public async Task<ActionResult<Microcontroller>> AddMicrocontroller(Microcontroller newMC)
        {
            if (newMC == null) return BadRequest();

            _context.Microcontrollers.Add(newMC);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMicrocontrollerById), new { id = newMC.Id }, newMC);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMicrocontroller(int id, Microcontroller newMC)
        {
            var microcontroller = await _context.Microcontrollers.FindAsync(id);
            if (microcontroller == null) return NotFound();

            microcontroller.Id = newMC.Id;
            microcontroller.Model = newMC.Model;
            microcontroller.Manufacturer = newMC.Manufacturer;
            microcontroller.ClockFz = newMC.ClockFz;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMicrocontroller(int id)
        {
            var microcontroller = await _context.Microcontrollers.FindAsync(id);
            if (microcontroller == null) return NotFound();

            _context.Microcontrollers.Remove(microcontroller);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
