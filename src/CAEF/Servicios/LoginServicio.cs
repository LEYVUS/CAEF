using CAEF.Models.Contexts;
using CAEF.Models.DTO;
using CAEF.Models.Entities.UABC;
using CAEF.Models.Repositories;
using CAEF.Repositorios.Implementacion;
using CAEF.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAEF.Servicios
{
    public class LoginServicio
    {
        private UsuarioRepositorioImpl usuarioRepositorio;
        private UsuarioUABCRepositorioImpl usuarioUABCRepositorio;
        private UsuarioFIADRepositorioImpl usuarioFIADRepositorio;
        private SignInManager<UsuarioUABC> _signIn;

        public LoginServicio()
        {
            usuarioRepositorio = new UsuarioRepositorioImpl(new EntidadesCAEF());
            usuarioUABCRepositorio = new UsuarioUABCRepositorioImpl(new UsuarioUABCContext());
            usuarioUABCRepositorio = new UsuarioUABCRepositorioImpl(new UsuarioUABCContext());
        }

        public async void LogOut(bool logeado)
        {
            if (logeado)
            {
                await _signIn.SignOutAsync();
            }

        }
        public async Task<bool> GuardarLogin(LoginDTO login)
        {
            var signIn = await _signIn.PasswordSignInAsync(login.Email,
                                                    login.Password,
                                                    true, false);
            return signIn.Succeeded;
        }

        public async Task<MensajeDTO> Logear(LoginDTO login)
        {
            MensajeDTO mensaje = new MensajeDTO();

            if (usuarioUABCRepositorio.BuscarPorCorreo(login.Email) != null)
            {
                if (usuarioFIADRepositorio.BuscarPorCorreo(login.Email) != null)
                {
                    if (usuarioRepositorio.BuscarPorCorreo(login.Email) != null)
                    {
                        var signIn = await _signIn.PasswordSignInAsync(login.Email,
                                                    login.Password,
                                                    true, false);
                        if (signIn.Succeeded)
                        {
                            mensaje.estado = true;
                            return mensaje;
                        }
                      
                    }
                    else
                    {
                        await _signIn.SignOutAsync();
                        mensaje.SetMensaje(null, false, "El usuario no se encuentra registrado en el sistema");
                        return mensaje;
                    }
                }
                else
                {
                    await _signIn.SignOutAsync();
                    mensaje.SetMensaje(null, false, "El usuario no pertenece a FIAD");
                    return mensaje;
                }

            }

                await _signIn.SignOutAsync();
                mensaje.SetMensaje(null, false, "El usuario no pertenece a UABC");
                return mensaje;
            

        }


    }
}
