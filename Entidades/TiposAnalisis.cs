using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAnalisisMedico.Entidades
{
    public class TiposAnalisis
    {
        [Key]

        public int TipoId { get; set; }
        public string Descripcion { get; set; }

        public TiposAnalisis()
        {
            this.TipoId = 0;
            this.Descripcion = string.Empty;
        }
    }
}
