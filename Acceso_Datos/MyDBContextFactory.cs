using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acceso_Datos
{
    public class MyDBContextFactory : IDesignTimeDbContextFactory<MyDBContext>
    {
        public MyDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MyDBContext>();
            const string Cadena_Conexion = "Data Source=.;Initial Catalog=X1_CRUD;Integrated Security=True;Trust Server Certificate=True";
            optionsBuilder.UseSqlServer(Cadena_Conexion);

            return new MyDBContext(optionsBuilder.Options);
        }

    }
}
