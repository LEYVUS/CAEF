using CAEF.Models.Contexts;
using CAEF.Models.Entities.CAEF;
using CAEF.Repositorios.RepositorioGenericos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAEF.Repositorios.Implementacion
{
    public class UsuarioRepositorioImpl : RepostorioCRUD<Usuario>, IUsuarioRepositorio
    {
        public UsuarioRepositorioImpl(DbContext context) : base(context)
        {

        }

        public Usuario BuscarPorCorreo(String Correo)
        {

            EntidadesCAEF context = new EntidadesCAEF();
            Usuario usuarioCAEF;

            try
            {
                     usuarioCAEF  = context.Usuarios
                    .Include(u => u.Rol)
                    .Where(u => u.Correo == Correo)
                    .FirstOrDefault<Usuario>();
            }
            catch (Exception ex)
            {
                return null;
            }

            return usuarioCAEF;
        }

        public override void Modificar(Usuario usuario)
        {
        }
        //    private EntidadesCAEF _contextoCAEF;
        //    private UsuarioUABCContext _contextoUABC;

        //    public CAEFRepository(EntidadesCAEF contextoCAEF, UsuarioUABCContext contextoUABC)
        //    {
        //        _contextoCAEF = contextoCAEF;
        //        _contextoUABC = contextoUABC;
        //    }

        //    public void AgregarUsuario(Usuario usuario)
        //    {
        //        // Al agregar usuario nuevo, solo se pide matrícula,
        //        // correo y rol, por lo tanto se tienen que extraer sus
        //        // nombres de la BD de UABC para poder mostrarlo en la lista
        //        // con toda la información correcta.
        //        var usuarioUABC = _contextoUABC.UsuariosUABC
        //            .Where(u => u.Email == usuario.Correo)
        //            .FirstOrDefault();

        //        usuario.Id = usuarioUABC.Matricula;
        //        usuario.Nombre = usuarioUABC.Nombre;
        //        usuario.ApellidoP = usuarioUABC.ApellidoP;
        //        usuario.ApellidoM = usuarioUABC.ApellidoM;
        //        _contextoCAEF.Add(usuario);
        //    }

        //    public IEnumerable<Usuario> ObtenerUsuarios()
        //    {
        //        return _contextoCAEF.Usuarios
        //            .Include(u => u.Rol)
        //            .ToList();
        //    }

        //    public async Task<bool> GuardarCambios()
        //    {
        //        return (await _contextoCAEF.SaveChangesAsync()) > 0;
        //    }

        //    public bool UsuarioExiste(string Correo)
        //    {
        //        var resultado = _contextoUABC.Users
        //            .Where(u => u.Email == Correo)
        //            .FirstOrDefault();

        //        return resultado == null ? false: true;
        //    }

        //    public Usuario UsuarioAutenticado(string Username)
        //    {
        //        var Correo = Username + "@uabc.edu.mx";
        //        var Usuario = _contextoCAEF.Usuarios
        //            .Include(u => u.Rol)
        //            .Where(u => u.Correo == Correo)
        //            .FirstOrDefault();

        //        return Usuario;
        //    }

        //    public IEnumerable<Rol> ObtenerRoles()
        //    {
        //        return _contextoCAEF.Roles.ToList();
        //    }

        //    public bool UsuarioDuplicado(string Correo)
        //    {
        //        var resultado = _contextoCAEF.Usuarios
        //            .Where(u => u.Correo == Correo)
        //            .FirstOrDefault();

        //        return resultado == null ? false : true;
        //    }

        //    public void EditarUsuario(Usuario usuario)
        //    {
        //        var resultado = _contextoCAEF.Usuarios
        //            .Where(u => u.Correo == usuario.Correo)
        //            .FirstOrDefault();

        //        if(resultado != null)
        //        {
        //            resultado.RolId = usuario.RolId;
        //            _contextoCAEF.Usuarios.Update(resultado);
        //        }
        //    }

        //    public void BorrarUsuario(Usuario usuario)
        //    {
        //        var resultado = _contextoCAEF.Usuarios
        //            .Where(u => u.Correo == usuario.Correo)
        //            .FirstOrDefault();

        //        if(resultado != null) _contextoCAEF.Usuarios.Remove(resultado);
        //    }

        //    public IEnumerable<Carrera> ObtenerCarreras()
        //    {
        //        return _contextoCAEF.Carreras.ToList();
        //    }

        //    public IEnumerable<Materia> ObtenerMaterias()
        //    {
        //        return _contextoCAEF.Materias.ToList();
        //    }

        //    public IEnumerable<SubtipoExamen> ObtenerSubtiposExamen()
        //    {
        //        return _contextoCAEF.SubtiposExamen.ToList();
        //    }

        //    public IEnumerable<TipoExamen> ObtenerTiposExamen()
        //    {
        //        return _contextoCAEF.TiposExamen.ToList();
        //    }

        //    public int AgregarActaDocente(SolicitudDocente acta)
        //    {
        //        _contextoCAEF.SolicitudesDocente.Add(acta);
        //        _contextoCAEF.SaveChanges();
        //        return acta.Id;
        //    }

        //    public void AgregarActaAdmin(SolicitudAdministrador acta)
        //    {
        //        _contextoCAEF.SolicitudesAdministrativo.Add(acta);
        //    }

        //    public void AgregarSolicitudAlumno(IEnumerable<SolicitudAlumno> solicitudes)
        //    {
        //        var NumeroSolicitudes = CuentaSolicitudes();
        //        foreach(SolicitudAlumno solicitud in solicitudes)
        //        {
        //            if(solicitud.Alumno.Id != 0)
        //            {
        //                solicitud.IdAlumno = solicitud.Alumno.Id;
        //                _contextoCAEF.SolicitudesAlumno.Add(solicitud);
        //            }
        //        }
        //    }

        //    public int CuentaSolicitudes()
        //    {
        //        return _contextoCAEF.SolicitudesDocente.Count();
        //    }
        //}

    }
    }
