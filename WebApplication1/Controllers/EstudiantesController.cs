using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EstudiantesAPI.Data;
using EstudiantesAPI.Models;
using EstudiantesAPI.DTOs;

namespace EstudiantesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudiantesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EstudiantesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estudiante>>> Get()
        {
            return await _context.Estudiantes.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Estudiante>> Post(EstudianteDTO dto)
        {
            var estudiante = new Estudiante
            {
                Nombre = dto.Nombre,
                Carrera = dto.Carrera,
                Matricula = dto.Matricula
            };
            _context.Estudiantes.Add(estudiante);
            await _context.SaveChangesAsync();
            return Ok(estudiante);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, EstudianteDTO dto)
        {
            var estudiante = await _context.Estudiantes.FindAsync(id);
            if (estudiante == null) return NotFound();

            estudiante.Nombre = dto.Nombre;
            estudiante.Carrera = dto.Carrera;
            estudiante.Matricula = dto.Matricula;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var estudiante = await _context.Estudiantes.FindAsync(id);
            if (estudiante == null) return NotFound();

            _context.Estudiantes.Remove(estudiante);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}