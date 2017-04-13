using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CAEF.Models.UABC;
using Microsoft.Extensions.Configuration;

namespace CAEF.Models.Contexts
{
    public class UsuarioUABCContext : DbContext
    {
        private IConfigurationRoot _config;

        public UsuarioUABCContext(IConfigurationRoot config, DbContextOptions<UsuarioUABCContext> options) : base(options)
        {
            _config = config;
        }
        public DbSet<UsuarioUABC> UsuariosUABC { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_config["ConexionesBD:ConexionUsuariosUABC"]);
        }
    }
}
