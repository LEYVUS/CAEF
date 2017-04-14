using CAEF.Models.Contexts;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

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
