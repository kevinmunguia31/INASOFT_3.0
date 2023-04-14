using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace INASOFT_3._0.Controladores
{
    class ctrlUsuarios
    {
        public string ctrlRegistro(Modelos.Usuarios usuario)
        {
            Modelos.ModeloUsers modelo = new Modelos.ModeloUsers();
            string respuesta = "";

            if (string.IsNullOrEmpty(usuario.Usuario) || string.IsNullOrEmpty(usuario.Password) || string.IsNullOrEmpty(usuario.ConPassword) || string.IsNullOrEmpty(usuario.Nombre))
            {
                respuesta = "Debe Llenar todos los campos";
            }
            else
            {
                if (usuario.Password == usuario.ConPassword)
                {
                    if (modelo.existeUsuario(usuario.Usuario))
                    {
                        respuesta = "El usuario ya existe";
                    }
                    else
                    {
                        usuario.Password = generarSHA1(usuario.Password);
                        modelo.registro(usuario);
                    }
                }
                else
                {
                    respuesta = "Las contraseña no coinciden";
                }
            }
            return respuesta;
        }

        public string ctrlLogin(string usuario, string password)
        {
            Modelos.ModeloUsers modelo = new Modelos.ModeloUsers();
            string respuesta = "";

            Modelos.Usuarios datosUsuario = null;

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(password))
            {
                respuesta = "Debe de llenar todos los campos";
            }
            else
            {
                datosUsuario = modelo.porUsuario(usuario);

                if (datosUsuario == null)
                {
                    respuesta = "El usuario no existe";
                }
                else
                {
                    if (datosUsuario.Password != generarSHA1(password))
                    {
                        respuesta = "El usuario y/o contraseña no coinciden";
                    }
                    else
                    {
                        Modelos.Sesion.id = datosUsuario.Id;
                        Modelos.Sesion.usuario = usuario;
                        Modelos.Sesion.nombre = datosUsuario.Nombre;
                        Modelos.Sesion.id_tipo = datosUsuario.Id_tipo;
                    }
                }
            }
            return respuesta;
        }

        private string generarSHA1(string cadena)
        {
            //CIFRAR LA CONTRASEÑA
            UTF8Encoding enc = new UTF8Encoding();
            byte[] data = enc.GetBytes(cadena);
            byte[] result;

            SHA1CryptoServiceProvider sha = new SHA1CryptoServiceProvider();

            result = sha.ComputeHash(data);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] < 16)
                {
                    sb.Append("0");
                }
                sb.Append(result[i].ToString("x"));
            }

            return sb.ToString();
        }
    }
}
