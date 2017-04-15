﻿using CAEF.Models.Contexts;
using CAEF.Models.Entities.FIAD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAEF.Models.Repositories
{
    public class FIADRepository : IFIADRepository
    {
        private UsuarioFIADContext _context;

        public FIADRepository(UsuarioFIADContext context)
        {
            _context = context;
        }

        public IEnumerable<UsuarioFIAD> ObtenerUsuarios()
        {
            return _context.UsuariosFIAD.ToList();
        }
    }
}
