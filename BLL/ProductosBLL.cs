using System;
using System.Linq;
using System.Linq.Expressions;
using RegistroConDetalle.Dal;
using RegistroConDetalle.Entidades;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RegistroConDetalle.BLL{

    public class ProductosBLL{

        public static bool Guardar(Productos productos){
           if(!Existe(productos.ProductoId))
                return Insertar(productos);
           else
                return Modificar(productos);
        }
        
        private static bool Insertar(Productos productos){

             bool paso = false;
             Contexto contexto = new Contexto();

            try{
                //Agregar a la entidad que se desea ingresar al contexto
                contexto.Productos.Add(productos);
                var persona = contexto.Productos.Find(productos.ProductoId);
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

        private static bool Modificar(Productos productos){

            bool paso = false;
            Contexto contexto = new Contexto();

            try{
                //Marcar la entidad como modificada para que 
                //el contexto sepa como proceder
                contexto.Entry(productos).State= EntityState.Modified;
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
                var prestamo = contexto.Productos.Find(id);

                if(prestamo != null){
                    contexto.Productos.Remove(prestamo);//Removemos la entidad
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

        public static Productos Buscar(int id){

            Contexto contexto = new Contexto();
            Productos prestamo = new Productos();

            try{
                prestamo =contexto.Productos.Find(id);

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
                encontrado = contexto.Productos.Any(e => e.ProductoId ==id);
            }
            catch(Exception){
                throw;
            }
            finally{
                contexto.Dispose();
            }

            return encontrado;
        }

        public static List<Productos> GetList(Expression<Func<Productos, bool>> criterio){
            
            List<Productos> lista = new List<Productos>();
            Contexto contexto = new Contexto();

            try{
                //obtener la lista y filtrarla segun el criterio recibido por parametro
                lista = contexto.Productos.Where(criterio).ToList();

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