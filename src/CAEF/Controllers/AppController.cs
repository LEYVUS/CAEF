using CAEF.Models.Contexts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAEF.Controllers
{
    public class AppController : Controller
    {
        private UsuarioUABCContext _context;

        public AppController(UsuarioUABCContext context)
        {
            _context = context;
        }
        public IActionResult Inicio()
        {
            var data = _context.UsuariosUABC.ToList();
            return View(data);
        }
    }
}
