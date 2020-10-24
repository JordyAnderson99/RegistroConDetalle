using System;
using System.Linq;
using System.Linq.Expressions;
using RegistroConDetalle.Dal;
using RegistroConDetalle.Entidades;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RegistroConDetalle.BLL
{
    public class OrdenesBLL
    {
        public static bool Guardar(Ordenes ordenes)
        {
            if (!Existe(ordenes.OrdenId))
                return Insertar(ordenes);
            else
                return Modificar(ordenes);
        }

        private static bool Insertar(Ordenes ordenes)
        {

            bool paso = false;
            Contexto contexto = new Contexto();
          
            try
            {
                //Agregar a la entidad que se desea ingresar al contexto
                foreach (var item in ordenes.Detalle)
                {
                    contexto.Entry(item.productos).State = EntityState.Modified;
                }               
                contexto.Ordenes.Add(ordenes);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;

        }

        private static bool Modificar(Ordenes ordenes)
        {

            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Database.ExecuteSqlRaw($"Delete FROM MorasDetalle Where MoraId={ordenes.OrdenId}");

                foreach (var item in ordenes.Detalle)
                {
                    contexto.Entry(item).State = EntityState.Added;
                }
                
                contexto.Entry(ordenes).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        public static bool Eliminar(int id)
        {

            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                //Buscar La entidad que se desea eliminar
                var moras = contexto.Ordenes.Find(id);

                if (moras != null)
                {
                    contexto.Ordenes.Remove(moras);//Removemos la entidad
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        public static Ordenes Buscar(int id)
        {

            Contexto contexto = new Contexto();
            Ordenes ordenes = new Ordenes();

            try
            {
                 ordenes = contexto.Ordenes
                    .Where(d => d.OrdenId == id)
                    .Include(d => d.Detalle)
                    .ThenInclude(p => p.productos)
                    .SingleOrDefault();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return ordenes;

        }

        public static bool Existe(int id)
        {

            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Ordenes.Any(e => e.OrdenId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;
        }

        public static List<Ordenes> GetList(Expression<Func<Ordenes, bool>> criterio)
        {

            List<Ordenes> lista = new List<Ordenes>();
            Contexto contexto = new Contexto();

            try
            {
                //obtener la lista y filtrarla segun el criterio recibido por parametro
                lista = contexto.Ordenes.Where(criterio).ToList();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }
    }
}