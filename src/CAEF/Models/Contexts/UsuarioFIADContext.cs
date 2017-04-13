using CAEF.Models.FIAD;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAEF.Models.Contexts
{
    public class UsuarioFIADContext : DbContext
    {
        private IConfigurationRoot _config;

        public UsuarioFIADContext(IConfigurationRoot config, DbContextOptions<UsuarioFIADContext> options) : base(options)
        {
            _config = config;
        }
        public DbSet<UsuarioFIAD> UsuariosFIAD { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_config["ConexionesBD:ConexionUsuariosFIAD"]);
        }
    }
}
