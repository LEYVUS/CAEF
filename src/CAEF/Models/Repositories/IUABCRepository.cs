﻿using System.Collections.Generic;
using CAEF.Models.Entities.UABC;

namespace CAEF.Models.Repositories
{
    public interface IUABCRepository
    {
        IEnumerable<UsuarioUABC> ObtenerUsuarios();
        bool UsuarioExiste(string correo);
    }
}