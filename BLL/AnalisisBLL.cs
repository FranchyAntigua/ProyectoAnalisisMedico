using ProyectoAnalisisMedico.DAL;
using ProyectoAnalisisMedico.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAnalisisMedico.BLL
{
     public class AnalisisBLL
    {
            public static bool Guardar(Analisis analisis)
            {
                bool estado = false;
                try
                {
                    Contexto context = new Contexto();
                    context.Analisis.Add(analisis);
                    context.SaveChanges();
                    estado = true;

                }
                catch (Exception)
                {

                    throw;
                }
                return estado;
            }
        public static bool Editar(Analisis analisis)
        {
            bool estado = false;

            Contexto contexto = new Contexto();
            try
            {
                contexto.Entry(analisis).State = EntityState.Modified;
                if (contexto.SaveChanges() > 0)
                {
                    estado = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return estado;
        }
        public static bool Eliminar(int id)
        {
            bool estado = false;

            Contexto contexto = new Contexto();
            try
            {
                Analisis analisis = contexto.Analisis.Find(id);

                contexto.Analisis.Remove(analisis);

                if (contexto.SaveChanges() > 0)
                {
                    estado = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {

                throw;
            }
            return estado;
        }
        public static Analisis Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Analisis analisis = new Analisis();
            try
            {
                analisis = contexto.Analisis.Find(id);
                contexto.Dispose();
            }
            catch (Exception)
            {

                throw;
            }
            return analisis;
        }
        public static List<Analisis> GetList(Expression<Func<Analisis, bool>> expression)
        {
            List<Analisis> analisis = new List<Analisis>();
            Contexto contexto = new Contexto();

            try
            {
                analisis = contexto.Analisis.Where(expression).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }

            return analisis;
        }
    }
}
