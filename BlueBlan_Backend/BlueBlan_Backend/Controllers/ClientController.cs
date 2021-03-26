using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlueBan.Aplication.Contracts;
using BlueBan.Aplication.Entitydto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlueBlan_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : Controller
    {
        private readonly IClientAplicationService _clientAplicationService;
        public ClientController(IClientAplicationService _clientAplicationService)
        {
            this._clientAplicationService = _clientAplicationService;
        }
        // GET: api/<AccountController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var clientAll = await _clientAplicationService.getAllClients();
            if (clientAll == null || clientAll.Count == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, "Not Found Account!");
            }
            return Ok(clientAll);
        }

        // GET api/<AccountController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var client = await _clientAplicationService.getClientById(id);
            if (client == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, "Not Found Client!");
            }
            return Ok(client);
        }

        // POST api/<AccountController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Clientdto clientdto)
        {

            if (clientdto == null)
            { 
                return BadRequest(ModelState);
            }


            var issave = await _clientAplicationService.saveClient(clientdto);

            if (!issave)
            {
                ModelState.AddModelError("", $"Something went wrong creating the record {clientdto.name}");

                return StatusCode(500, ModelState);
            }

            return Ok(clientdto);
        }

        // PATCH api/<AccountController>/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(Guid id, [FromBody] Clientdto clientdto)
        {
            if (clientdto == null || id != clientdto.clientid)
            {
                return BadRequest(ModelState);
            }

            var issave = await _clientAplicationService.updateClient(clientdto);

            if (!issave)
            {
                ModelState.AddModelError("", $"Something went wrong creating the record {clientdto.name}");

                return StatusCode(500, ModelState);
            }

            return Ok(clientdto);
        }

        // DELETE api/<AccountController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var isexist = await _clientAplicationService.existsClient(id);
            if (!isexist)
            {
                return NotFound();
            }

            var client = await _clientAplicationService.getClientById(id);

            var isdelete = await _clientAplicationService.deleteClient(client);

            if (!isdelete)
            {
                ModelState.AddModelError("", $"Something went wrong creating the record {client.name}");

                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
