﻿using Eventplus_api_senai.Domais;
using Eventplus_api_senai.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eventplus_api_senai.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class EventoController : ControllerBase
    {
        private readonly IEventoRepository _eventoRepository;
        public EventoController(IEventoRepository eventoRepository)
        {
            _eventoRepository = eventoRepository;
        }

        /// <summary>
        /// Endpoint para listar Eventos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_eventoRepository.Listar());
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint para cadastras Eventos
        /// </summary>
        /// <param name="novoEvento"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(Evento novoEvento)
        {
            try
            {
                _eventoRepository.Cadastrar(novoEvento);
                return Created();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Endpoint para Deletar Eventos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _eventoRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Endpoint para Atualizar Eventos
        /// </summary>
        /// <param name="id"></param>
        /// <param name="novoEvento"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put(Guid id, Evento novoEvento)
        {
            try
            {
                _eventoRepository.Atualizar(id, novoEvento);
                return NoContent();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }

        /// <summary>
        /// Endpoint para Listar Proximos Eventos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("ListarProximosEventos/{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                List<Evento> listarEvento = _eventoRepository.ListarProximosEventos(id);
                return Ok(listarEvento);
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }

        }

        /// <summary>
        /// Endpoint para Listar Eventos por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("ListarPorId/{id}")]
        public IActionResult GetById(Guid id) 
        {
            try
            {
                List<Evento> listarEvento = _eventoRepository.ListarPorId(id);
                return Ok(listarEvento);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
