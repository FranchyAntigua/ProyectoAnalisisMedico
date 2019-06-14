using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAnalisisMedico.Entidades
{
    public class Usuarios
    {
        [Key]
        public int UsuarioId { get; set; }
        public DateTime Fecha { get; set; }
        public string Nombres { get; set; }
        public string Username { get; set; }
        public string Contraseña { get; set; }

        public Usuarios()
        {
            this.UsuarioId = 0;
            this.Nombres = string.Empty;
            this.Username = string.Empty;
            this.Fecha = DateTime.Now;
            this.Contraseña = string.Empty;
        }
    }
}


