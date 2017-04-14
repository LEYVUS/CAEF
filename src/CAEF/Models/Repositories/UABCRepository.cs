using CAEF.Models.Contexts;

namespace CAEF.Models.Repositories
{
    public class UABCRepository
    {
        private UsuarioUABCContext _context;

        public UABCRepository(UsuarioUABCContext context)
        {
            _context = context;
        }
    }
}
