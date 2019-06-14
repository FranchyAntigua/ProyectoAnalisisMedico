using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAnalisisMedico.Entidades
{
    public class Analisis
    {
        [Key]

        public int AnalisisId { get; set; }
        public DateTime Fecha { get; set; }
        public int UsuarioId { get; set; }
        public virtual List<AnalisisDetalle> Detalle { get; set; }

        public Analisis()
        {
            this.AnalisisId = 0;
            this.Fecha = DateTime.Now;
            this.UsuarioId = 0;
            this.Detalle = new List<AnalisisDetalle>();
        }

        public void AgregarDetalle(int Id, int AnalisisId, int TipoId, string Resultado)
        {
            this.Detalle.Add(new AnalisisDetalle(Id, AnalisisId, TipoId, Resultado));
        }
        
    }
}
