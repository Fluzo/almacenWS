
using AlmacenWS.BaseDatos;
using AlmacenWS.DTO;
using AlmacenWS.Usuarios.DTO.GestionUsuarios;
using AlmacenWS.Usuarios.DTO.Login;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Data;

namespace AlmacenWS.Usuarios.Servicios
{

    public interface IUsuariosService
    {
        Task<DbResponse<LoginResponseDTO>> Login(LoginDTO login);
        Task<DbResponse<bool>> AltaUsuario(UsuarioDTO usuario);
        Task<DbResponse<bool>> EditarUsuario(UsuarioDTO usuario);
        DbResponse<List<V_USUARIOS>> DameUsuarios(FiltroUsuariosDTO filtro);
    }
    public class UsuariosService: IUsuariosService
    {
        public AlmacenContext _ctx;
        public UsuariosService(AlmacenContext ctx)
        {
            this._ctx = ctx;

        }


        public async Task<DbResponse<LoginResponseDTO>> Login(LoginDTO login)
        {
            var result = await this.PaLogin(login);
            return result;
        }

        public DbResponse<List<V_USUARIOS>> DameUsuarios(FiltroUsuariosDTO filtro)
        {
            List<V_USUARIOS> usuarios =  this._ctx.V_USUARIOS.ToList();
            return new DbResponse<List<V_USUARIOS>>(usuarios);
        }


        public async Task<DbResponse<bool>> AltaUsuario(UsuarioDTO usuario)
        {
            SqlParameter Usuario = new SqlParameter()
            {
                ParameterName = "USUARIO",
                SqlDbType = SqlDbType.VarChar,
                Size = 50,
                Value = usuario.Usuario
            };
            SqlParameter Password = new SqlParameter()
            {
                ParameterName = "PASSWORD",
                SqlDbType = SqlDbType.VarChar,
                Size = 50,
                Value = usuario.Password
            };
            SqlParameter Email = new SqlParameter()
            {
                ParameterName = "EMAIL",
                SqlDbType = SqlDbType.VarChar,
                Size = 50,
                Value = usuario.Email
            };
            SqlParameter IdPerfil = new SqlParameter()
            {
                ParameterName = "ID_PERFIL",
                SqlDbType = SqlDbType.Int,
                Value = usuario.IdPerfil
            };
            //SqlParameter Activo = new SqlParameter()
            //{
            //    ParameterName = "ACTIVO",
            //    SqlDbType = SqlDbType.Bit,
            //    Value = usuario.Activo
            //};

            SqlParameter outMensaje = new SqlParameter()
            {
                ParameterName = "MENSAJE",
                SqlDbType = SqlDbType.VarChar,
                Size = 2000,
                Direction = ParameterDirection.Output
            };
            SqlParameter outRetcode = new SqlParameter()
            {
                ParameterName = "RETCODE",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Output
            };

            var sqlParameters = new[]
            {
                Usuario,
                Password,
                Email,
                IdPerfil,
                outMensaje,
                outRetcode
            };


            await this._ctx.Database.ExecuteSqlRawAsync("EXEC [dbo].[PA_ALTA_USUARIO] @USUARIO, @PASSWORD, @EMAIL, @ID_PERFIL, @MENSAJE OUTPUT,@RETCODE OUTPUT", sqlParameters);

            if ((int)outRetcode.Value != 0)
            {
                return new DbResponse<bool>(false)
                {
                    Mensaje = outMensaje.Value.ToString(),
                    Retcode = (int)outRetcode.Value
                };
            }
            else
            {
                return new DbResponse<bool>(true)
                {
                    Mensaje = outMensaje.Value.ToString(),
                    Retcode = (int)outRetcode.Value
                };
            }
        }

        public async Task<DbResponse<bool>> EditarUsuario(UsuarioDTO usuario)
        {
            SqlParameter IdUsuario = new SqlParameter()
            {
                ParameterName = "ID_USUARIO",
                SqlDbType = SqlDbType.Int,
                Value = usuario.IdUsuario
            };
            SqlParameter Password = new SqlParameter()
            {
                ParameterName = "PASSWORD",
                SqlDbType = SqlDbType.VarChar,
                Size = 50,
                Value = usuario.Password
            };
            SqlParameter Email = new SqlParameter()
            {
                ParameterName = "EMAIL",
                SqlDbType = SqlDbType.VarChar,
                Size = 100,
                Value = usuario.Email
            };
            SqlParameter IdPerfil = new SqlParameter()
            {
                ParameterName = "ID_PERFIL",
                SqlDbType = SqlDbType.Int,
                Value = usuario.IdPerfil
            };

            SqlParameter Activo = new SqlParameter()
            {
                ParameterName = "ACTIVO",
                SqlDbType = SqlDbType.Bit,
                Value = usuario.Activo
            };

            SqlParameter outMensaje = new SqlParameter()
            {
                ParameterName = "MENSAJE",
                SqlDbType = SqlDbType.VarChar,
                Size = 2000,
                Direction = ParameterDirection.Output
            };
            SqlParameter outRetcode = new SqlParameter()
            {
                ParameterName = "RETCODE",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Output
            };

            var sqlParameters = new[]
            {
                IdUsuario,
                Password,
                Email,
                Activo,
                IdPerfil,
                outMensaje,
                outRetcode
            };


            await this._ctx.Database.ExecuteSqlRawAsync("EXEC [dbo].[PA_EDITAR_USUARIO] @ID_USUARIO, @PASSWORD, @EMAIL, @ACTIVO, @ID_PERFIL, @MENSAJE OUTPUT, @RETCODE OUTPUT", sqlParameters);

            if ((int)outRetcode.Value != 0)
            {
                return new DbResponse<bool>(false)
                {
                    Mensaje = outMensaje.Value.ToString(),
                    Retcode = (int)outRetcode.Value
                };
            }
            else
            {
                return new DbResponse<bool>(true)
                {
                    Mensaje = outMensaje.Value.ToString(),
                    Retcode = (int)outRetcode.Value
                };
            }
        }

        private async Task<DbResponse<LoginResponseDTO>> PaLogin(LoginDTO login)
        {
            SqlParameter Usuario = new SqlParameter()
            {
                ParameterName = "USUARIO",
                SqlDbType = SqlDbType.VarChar,
                Size = 50,
                Value = login.Usuario
            };
            SqlParameter Password = new SqlParameter()
            {
                ParameterName = "PASSWORD",
                SqlDbType = SqlDbType.VarChar,
                Size = 50,
                Value = login.Password
            };
            SqlParameter outIdUsuario = new SqlParameter()
            {
                ParameterName = "ID_USUARIO",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Output
            };
            SqlParameter outMensaje = new SqlParameter()
            {
                ParameterName = "MENSAJE",
                SqlDbType = SqlDbType.VarChar,
                Size = 2000,
                Direction = ParameterDirection.Output
            };
            SqlParameter outRetcode = new SqlParameter()
            {
                ParameterName = "RETCODE",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Output
            };

            var sqlParameters = new[]
            {
                Usuario,
                Password,
                outIdUsuario,
                outMensaje,
                outRetcode
            };


            await this._ctx.Database.ExecuteSqlRawAsync("EXEC [dbo].[PA_LOGIN] @USUARIO, @PASSWORD, @ID_USUARIO OUTPUT,@MENSAJE OUTPUT,@RETCODE OUTPUT", sqlParameters);

            if((int)outRetcode.Value != 0)
            {
                return new DbResponse<LoginResponseDTO>(new LoginResponseDTO())
                {
                    Mensaje = outMensaje.Value.ToString(),
                    Retcode = (int)outRetcode.Value
                };
            } 
            else
            {
                LoginResponseDTO usuario = new LoginResponseDTO((int)outIdUsuario.Value);

                return new DbResponse<LoginResponseDTO>(usuario)
                {
                    Mensaje = outMensaje.Value.ToString(),
                    Retcode = (int)outRetcode.Value
                };
            }

            
        }


    }
}
