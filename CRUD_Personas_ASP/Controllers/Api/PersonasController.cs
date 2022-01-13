using BL;
using CRUD_Personas_Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CRUD_Personas_BL.Gestoras;

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
            return new clsListadoPersonasBL().Personas;
        }

        // GET api/<Personas>/5
        [HttpGet("{id}")]
        public clsPersona Get(int id)
        {
            return new clsListadoPersonasBL(id).Persona;
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
