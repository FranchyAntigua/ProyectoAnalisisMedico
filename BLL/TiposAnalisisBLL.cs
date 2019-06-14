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
     public class TiposAnalisisBLL
    {

        public static bool Guardar(TiposAnalisis tiposanalisis)
        {
            bool estado = false;

            Contexto contexto = new Contexto();
            try
            {
                if (contexto.TiposAnalisis.Add(tiposanalisis) != null)
                {
                    contexto.SaveChanges();
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

        public static bool Editar(TiposAnalisis tipo)
        {
            bool estado = false;

            Contexto contexto = new Contexto();
            try
            {
                contexto.Entry(tipo).State = EntityState.Modified;
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
                TiposAnalisis tiposAnalisis = contexto.TiposAnalisis.Find(id);

                contexto.TiposAnalisis.Remove(tiposAnalisis);

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

        public static TiposAnalisis Buscar(int id)
        {
            Contexto contexto = new Contexto();
            TiposAnalisis tiposAnalisis = new TiposAnalisis();
            try
            {
                tiposAnalisis = contexto.TiposAnalisis.Find(id);
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return tiposAnalisis ;


        }
        public static List<TiposAnalisis> GetList(Expression<Func<TiposAnalisis, bool>> expression)
        {
            List<TiposAnalisis> tiposAnalises = new List<TiposAnalisis>();
            Contexto contexto = new Contexto();

            try
            {
                tiposAnalises = contexto.TiposAnalisis.Where(expression).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }

            return tiposAnalises;
        }
    }

}
