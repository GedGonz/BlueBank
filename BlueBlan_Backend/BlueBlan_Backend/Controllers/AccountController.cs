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
    public class AccountController : ControllerBase
    {
        private readonly IAccountAplicationService _accountAplicationService;
        public AccountController(IAccountAplicationService _accountAplicationService)
        {
            this._accountAplicationService = _accountAplicationService;
        }
        // GET: api/<AccountController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var accountAll = await _accountAplicationService.getAllAccounts();
            if (accountAll==null || accountAll.Count==0)
            {
                return StatusCode(StatusCodes.Status404NotFound, "Not Found Account!");
            }
            return Ok(accountAll);
        }

        // GET api/<AccountController>/5
        [HttpGet("{Id}/{AccountNumber}")]
        public async Task<IActionResult> Get(Guid Id,string AccountNumber)
        {
            var account = await _accountAplicationService.getAccountByAccountNumber(Id,AccountNumber);
            if (account == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, "Not Found Account!");
            }
            return Ok(account);
        }

        // POST api/<AccountController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Accountdto accountdto)
        {

            if (accountdto==null) 
            {
                return BadRequest(ModelState);
            }


            var issave=await _accountAplicationService.saveAccount(accountdto);

            if (!issave) 
            {
                ModelState.AddModelError("", $"Something went wrong creating the record {accountdto.Number}");

                return StatusCode(500, ModelState);
            }

           return Ok(accountdto);
        }

        // PATCH api/<AccountController>/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(Guid id, [FromBody] Accountdto accountdto)
        {
            if (accountdto == null || id != accountdto.AccountId)
            {
                return BadRequest(ModelState);
            }

            var issave = await _accountAplicationService.updateAccount(accountdto);

            if (!issave)
            {
                ModelState.AddModelError("", $"Something went wrong creating the record {accountdto.Number}");

                return StatusCode(500, ModelState);
            }

            return Ok(accountdto);
        }

        // DELETE api/<AccountController>/5
        [HttpDelete("{Id}/{AccountNumber}")]
        public async Task<IActionResult> Delete(Guid Id,string AccountNumber)
        {
            var isexist = await _accountAplicationService.existsAccount(AccountNumber);
            if (!isexist)
            {
                return NotFound();
            }

            var account = await _accountAplicationService.getAccountByAccountNumber(Id,AccountNumber);

            var isdelete = await _accountAplicationService.deleteAccount(account);

            if (!isdelete)
            {
                ModelState.AddModelError("", $"Something went wrong creating the record {account.Number}");

                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        //MOVE ACCOUNT

        [HttpGet("Move/{Id}/{AccountNumber}")]
        public async Task<IActionResult> Move(Guid Id,string AccountNumber)
        {
            var accountMove = await _accountAplicationService.getAccountMoveByAccountNumber(Id,AccountNumber);
            if (accountMove == null || accountMove.Count == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, "Not Found Account!");
            }
            return Ok(accountMove);
        }

        // POST api/<AccountController>
        [HttpPost("Move/{AccountNumber}")]
        public async Task<IActionResult> Move(string AccountNumber,[FromBody] AccountMovedto accountMovedto)
        {

            if (accountMovedto == null)
            {
                return BadRequest(ModelState);
            }


            var issave = await _accountAplicationService.creatMoveAccount(AccountNumber,accountMovedto);

            if (!issave)
            {
                ModelState.AddModelError("", $"Something went wrong creating the record {accountMovedto.Value}");

                return StatusCode(500, ModelState);
            }

            return Ok(accountMovedto);
        }
    }
}
