using CRUD_Personas_BL.Gestoras;
using CRUD_Personas_BL.Listados;
using CRUD_Personas_Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Web.Http;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CRUD_Personas_ASP.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentossController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<clsDepartamento> Get()
        {
            ObservableCollection<clsDepartamento> departs;

            try
            {
                departs = new clsListadoDepartamentosBL().Departamentos;
            }catch (Exception e)
            {
                throw new HttpResponseException(HttpStatusCode.ServiceUnavailable);
            }

            if (departs == null || departs.Count == 0) 
            { 
                throw new HttpResponseException(HttpStatusCode.NoContent);
            }

            return departs;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public clsDepartamento Get(int id)
        {
            clsDepartamento depart;

            try
            {
                depart = new clsListadoDepartamentosBL(id).Departamento;
            }
            catch (Exception e)
            {
                throw new HttpResponseException(HttpStatusCode.ServiceUnavailable);
            }

            if (depart == null)
            {
                throw new HttpResponseException(HttpStatusCode.NoContent);
            }

            return depart;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] clsDepartamento departamento)
        {
            GestoraAccionesDepartamentosBL.addDepartamentosBL(departamento);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] clsDepartamento departamento)
        {
            GestoraAccionesDepartamentosBL.alterDepartamentosBL(departamento);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            GestoraAccionesDepartamentosBL.deleteDepartamentosBL(id);
        }
    }
}
