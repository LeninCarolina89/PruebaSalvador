using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
//using System.Net.Http;
using System.Web.Http;
using LibreriaDatos;
using System.Data.Entity;

using System.Text.RegularExpressions;



namespace WebPrueba.Controllers
{
    public class EmpleadoController : ApiController
    {
        private PRUEBAEntities1 Context = new PRUEBAEntities1();

        [HttpGet]



        public IEnumerable<empleado> Get()
        {
            using (PRUEBAEntities1 bd = new PRUEBAEntities1())
            {

                return bd.empleadoes.ToList();
            }
        }


        [HttpGet]
        public empleado Get(int id)
        {
            using (PRUEBAEntities1 bd = new PRUEBAEntities1())
            {
                return bd.empleadoes.FirstOrDefault(x => x.id == id);
            }
        }

        /// <summary>
        /// Guarda 
        /// </summary> /// <param name="empleado"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult AgregarEmpleado([FromBody] empleado empleado)
        {
            if (ModelState.IsValid)
            {
        
               // if (!Regex.IsMatch(empleado.telefono.ToString(), @"([0-9]{3})-[0-9]{3}-[0-9]{4}"))
                //    return BadRequest("El Teléfono no tiene formato válido");

            
                Context.empleadoes.Add(empleado); Context.SaveChanges();
                Context.SaveChanges();
                return Ok(empleado);

            }
            else
            {
                return BadRequest();
            }
        }


        /// <summary>
        /// Actualiza 
        /// </summary> /// <param name="empleado"></param>
        /// </summary> /// <param name="id"></param>
        /// <returns></returns>

        [HttpPut]

        public IHttpActionResult ActualizarEmpleado(int id, [FromBody] empleado empleado)
        {
            if (ModelState.IsValid)
            {
                var articuloExiste = Context.empleadoes.Count(e => e.id == id) > 0;

                if (articuloExiste)
                {
                    Context.Entry(empleado).State = EntityState.Modified;

                    Context.SaveChanges();
                    return Ok(empleado);
                }
                else
                {

                    return NotFound();
                }
            }
            else
            {
                return BadRequest();
            }

        }


        // DELETE
    
        [HttpDelete]

        public IHttpActionResult EliminarEmpleado(int id)
        {
            var empleado = Context.empleadoes.Find(id);

            if (empleado != null)
            {

                Context.empleadoes.Remove(empleado);
                Context.SaveChanges();

                return Ok(empleado);
            }
            else
            {
                return NotFound();
            }
        }

    }
}
