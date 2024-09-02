using Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acceso_Datos
{
    public class MyDBContext : DbContext
    {

        // Constructor:
        public MyDBContext(DbContextOptions<MyDBContext> options)
            : base(options)
        {
        }


        // Tablas DB:
        public DbSet<Ciudad> Ciudades { get; set; }
        public DbSet<Persona> Personas { get; set; }

    }
}
