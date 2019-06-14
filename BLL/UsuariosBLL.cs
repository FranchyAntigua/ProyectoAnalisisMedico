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
   public  class UsuariosBLL
    {
        public static bool Guardar(Usuarios usuarios)
        {
            bool estado = false;
            try
            {
                Contexto context = new Contexto();
                context.Usuarios.Add(usuarios);
                context.SaveChanges();
                estado = true;

            }
            catch (Exception)
            {

                throw;
            }
            return estado;
        }
        public static bool Editar(Usuarios usuarios)
        {
            bool estado = false;

            Contexto contexto = new Contexto();
            try
            {
                contexto.Entry(usuarios).State = EntityState.Modified;
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
                Usuarios usuarios = contexto.Usuarios.Find(id);

                contexto.Usuarios.Remove(usuarios);

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
        public static Usuarios Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Usuarios usuarios = new Usuarios();
            try
            {
                usuarios = contexto.Usuarios.Find(id);
                contexto.Dispose();
            }
            catch (Exception)
            {

                throw;
            }
            return usuarios;
        }

        public static List<Usuarios> GetList(Expression<Func<Usuarios, bool>> expression)
        {
            List<Usuarios> usuarios = new List<Usuarios>();
            Contexto contexto = new Contexto();

            try
            {
                usuarios = contexto.Usuarios.Where(expression).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }

            return usuarios;
        }
    }
}
