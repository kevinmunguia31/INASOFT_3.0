using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INASOFT_3._0.Modelos
{
    class Usuarios
    {
        int id, id_tipo;
        string usuario, password, conPassword, nombre;
        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Usuario { get => usuario; set => usuario = value; }
        public int Id_tipo { get => id_tipo; set => id_tipo = value; }
        public string Password { get => password; set => password = value; }
        public string ConPassword { get => conPassword; set => conPassword = value; }
    }
}
