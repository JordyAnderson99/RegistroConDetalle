using System;
using System.Linq;
using System.Linq.Expressions;
using RegistroConDetalle.Dal;
using RegistroConDetalle.Entidades;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RegistroConDetalle.BLL{

    public class SuplidoresBLL{

        public static bool Guardar(Suplidores suplidores){
           if(!Existe(suplidores.SuplidorId))
                return Insertar(suplidores);
           else
                return Modificar(suplidores);
        }
        
        private static bool Insertar(Suplidores suplidores){

             bool paso = false;
             Contexto contexto = new Contexto();

            try{
                //Agregar a la entidad que se desea ingresar al contexto
                contexto.Suplidores.Add(suplidores);
                var persona = contexto.Suplidores.Find(suplidores.SuplidorId);
                //-------------------------------------------persona.Balance += prestamo.Monto;
                paso = contexto.SaveChanges()>0;
            }
            catch(Exception){
                throw;
            }
            finally{
                contexto.Dispose();
            }
            return paso;

        }

        private static bool Modificar(Suplidores suplidores){

            bool paso = false;
            Contexto contexto = new Contexto();

            try{
                //Marcar la entidad como modificada para que 
                //el contexto sepa como proceder
                contexto.Entry(suplidores).State= EntityState.Modified;
                paso = contexto.SaveChanges()>0;
            }
            catch(Exception){
                throw;
            }
            finally{
                contexto.Dispose();
            }

            return paso;
        }

        public static bool Eliminar(int id){
            
            bool paso = false;
            Contexto contexto = new Contexto();

            try{
                //Buscar La entidad que se desea eliminar
                var prestamo = contexto.Suplidores.Find(id);

                if(prestamo != null){
                    contexto.Suplidores.Remove(prestamo);//Removemos la entidad
                    paso = contexto.SaveChanges() >0;
                }
            }
            catch(Exception){
                throw;
            }
            finally{
                contexto.Dispose();
            }

            return paso;
        }

        public static Suplidores Buscar(int id){

            Contexto contexto = new Contexto();
            Suplidores prestamo = new Suplidores();

            try{
                prestamo =contexto.Suplidores.Find(id);

            }
            catch(Exception){
                throw;
            }
            finally{
                contexto.Dispose();
            }

            return prestamo;

        }

        public static bool Existe(int id){

            Contexto contexto = new Contexto();
            bool encontrado = false;

            try{
                encontrado = contexto.Suplidores.Any(e => e.SuplidorId ==id);
            }
            catch(Exception){
                throw;
            }
            finally{
                contexto.Dispose();
            }

            return encontrado;
        }

        public static List<Suplidores> GetList(Expression<Func<Suplidores, bool>> criterio){
            
            List<Suplidores> lista = new List<Suplidores>();
            Contexto contexto = new Contexto();

            try{
                //obtener la lista y filtrarla segun el criterio recibido por parametro
                lista = contexto.Suplidores.Where(criterio).ToList();

            }
            catch(Exception){
                throw;
            }
            finally{
                contexto.Dispose();
            }
            return lista;
        }
    }
}