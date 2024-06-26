﻿using ApiModelo.Application.DTOs;
using ApiModelo.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiModelo.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClienteController : Controller
    {
        private readonly IApplicationServiceCliente applicationServiceCliente;

        public ClienteController(IApplicationServiceCliente applicationServiceCliente)
        {
            this.applicationServiceCliente = applicationServiceCliente;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(applicationServiceCliente.GetAll());
        }

        // GET api/values/5
        [HttpGet("{id:int}")]
        public ActionResult<string> Get(int id)
        {
            return Ok(applicationServiceCliente.GetById(id));
        }

        [HttpGet("{nome}")]
        public ActionResult<string> GetByName(string nome)
        {
            return Ok(applicationServiceCliente.GetByName(nome));
        }


        [HttpPost]
        public ActionResult Post([FromBody] ClienteDto clienteDTO)
        {
            try
            {
                if (clienteDTO == null)
                    return NotFound();

                applicationServiceCliente.Add(clienteDTO);
                return Ok("Cliente Cadastrado com sucesso!");
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        // PUT api/values/5
        [HttpPut]
        public ActionResult Put(int id , [FromBody] ClienteDto clienteDTO)
        {
            try
            {
                if (clienteDTO == null)
                    return NotFound();

                applicationServiceCliente.Update(id ,clienteDTO);
                return Ok("Cliente Atualizado com sucesso!");
            }
            catch (Exception)
            {

                throw;
            }
        }

        // DELETE api/values/5
        [HttpDelete()]
        public ActionResult Delete(int id)
        {
            try
            {
                if (id == null)
                    return NotFound();

                applicationServiceCliente.Delete(id);
                return Ok("Cliente Removido com sucesso!");
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
    

