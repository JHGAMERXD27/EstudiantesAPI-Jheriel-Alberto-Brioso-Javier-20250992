using EstudiantesAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EstudiantesAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Estudiante> Estudiantes { get; set; }
    }
}