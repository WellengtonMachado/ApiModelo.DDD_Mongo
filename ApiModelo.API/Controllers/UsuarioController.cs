﻿using ApiModelo.Application.DTOs;
using ApiModelo.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiModelo.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {
        private readonly IApplicationServiceUsuario applicationServiceUsuario;
        private readonly IApplicationServiceTarefa applicationServiceTarefa;

        public UsuarioController(IApplicationServiceUsuario applicationServiceUsuario, IApplicationServiceTarefa applicationServiceTarefa)
        {
            this.applicationServiceUsuario = applicationServiceUsuario;
            this.applicationServiceTarefa = applicationServiceTarefa;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(applicationServiceUsuario.GetAll());
        }

        [HttpGet("{id:int}")]
        public ActionResult<string> Get(int id)
        {
            return Ok(applicationServiceUsuario.GetById(id));
        }

        [HttpGet("{nome}")]
        public ActionResult<string> GetByName(string nome)
        {
            return Ok(applicationServiceUsuario.GetByName(nome));
        }

        [HttpPost]
        public ActionResult Post([FromBody] UsuarioDto usuarioDTO)
        {
            try
            {
                if (usuarioDTO == null)
                    return NotFound();


                applicationServiceUsuario.Add(usuarioDTO);
                return Ok("O usuário foi cadastrada com sucesso");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPut]
        public ActionResult Put(int id, [FromBody] UsuarioDto usuarioDTO)
        {

            try
            {
                if (usuarioDTO == null)
                    return NotFound();

                applicationServiceUsuario.Update(id, usuarioDTO);
                return Ok("O usuário foi atualizado com sucesso!");

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpDelete()]
        public ActionResult Delete(int id)
        {
            try
            {
                if (id == null)
                    return NotFound();

                var tarefaComUsuario = applicationServiceTarefa.GetByUsuarioId(id);

                if (tarefaComUsuario == null)
                {
                    
                    applicationServiceUsuario.Delete(id);
                    return Ok("O usuário foi removido com sucesso!");
                }
                else
                {
                    
                    return BadRequest("Não é possível excluir o usuário devido a tarefas associadas.");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
