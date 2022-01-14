using BL;
using CRUD_Personas_Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CRUD_Personas_BL.Gestoras;
using System.Collections.ObjectModel;
using System;
using System.Web.Http;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CRUD_Personas_ASP.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        // GET: api/<Personas>
        [HttpGet]
        public IEnumerable<clsPersona> Get()
        {
            ObservableCollection<clsPersona> people;

            try
            {
                people = new clsListadoPersonasBL().Personas;
            }
            catch (Exception e)
            {
                throw new HttpResponseException(HttpStatusCode.ServiceUnavailable);
            }

            if (people == null || people.Count == 0)
            {
                throw new HttpResponseException(HttpStatusCode.NoContent);
            }
            return people;
        }

        // GET api/<Personas>/5
        [HttpGet("{id}")]
        public clsPersona Get(int id)
        {
            clsPersona person;

            try
            {
                person = new clsListadoPersonasBL(id).Persona;
            }
            catch (Exception e)
            {
                throw new HttpResponseException(HttpStatusCode.ServiceUnavailable);
            }

            if (person == null)
            {
                throw new HttpResponseException(HttpStatusCode.NoContent);
            }
            return person;
        }

        // POST api/<Personas>
        [HttpPost]
        public void Post([FromBody] clsPersona persona)
        {
            GestoraAccionesPersonasBL.addPersonaBL(persona);
        }

        // PUT api/<Personas>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] clsPersona persona)
        {
            GestoraAccionesPersonasBL.alterPersonaBL(persona);
        }

        // DELETE api/<Personas>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            GestoraAccionesPersonasBL.deletePersonaBL(id);
        }
    }
}
