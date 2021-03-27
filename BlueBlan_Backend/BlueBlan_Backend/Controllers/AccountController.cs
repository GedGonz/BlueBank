using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlueBan.Aplication.Contracts;
using BlueBan.Aplication.Entitydto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace BlueBlan_API.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
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
            try
            {
                var accountAll = await _accountAplicationService.getAllAccounts();

                if (accountAll == null || accountAll.Count == 0)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Not Found Account!");
                }

                return Ok(accountAll);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Error!");
            }

           
        }

        // GET api/<AccountController>/5
        [HttpGet("{AccountNumber}")]
        public async Task<IActionResult> Get(string AccountNumber)
        {
            try
            {
                var account = await _accountAplicationService.getAccountByAccountNumber(AccountNumber);

                if (account == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Not Found Account!");
                }
                return Ok(account);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Error!");
            }

        }

        // POST api/<AccountController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Accountdto accountdto)
        {
            try
            {
                if (accountdto == null)
                {
                    return BadRequest(ModelState);
                }


                var issave = await _accountAplicationService.saveAccount(accountdto);

                if (!issave)
                {
                    ModelState.AddModelError("", $"Something went wrong creating the record {accountdto.ToString()}");

                    return StatusCode(500, ModelState);
                }

                return Ok(accountdto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Error!");
            }

        }

        // PATCH api/<AccountController>/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(Guid id, [FromBody] Accountdto accountdto)
        {
            try
            {
                if (accountdto == null || id != accountdto.accountid)
                {
                    return BadRequest(ModelState);
                }

                var issave = await _accountAplicationService.updateAccount(accountdto);

                if (!issave)
                {
                    ModelState.AddModelError("", $"Something went wrong creating the record {accountdto.ToString()}");

                    return StatusCode(500, ModelState);
                }

                return Ok(accountdto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Error!");
            }
           
        }

        // DELETE api/<AccountController>/5
        [HttpDelete("{Id}/{AccountNumber}")]
        public async Task<IActionResult> Delete(string AccountNumber)
        {
            try
            {
                var isexist = await _accountAplicationService.existsAccount(AccountNumber);
                if (!isexist)
                {
                    return NotFound();
                }

                var account = await _accountAplicationService.getAccountByAccountNumber(AccountNumber);

                var isdelete = await _accountAplicationService.deleteAccount(account);

                if (!isdelete)
                {
                    ModelState.AddModelError("", $"Something went wrong creating the record {account.ToString()}");

                    return StatusCode(500, ModelState);
                }

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Error!");
            }
            
        }

        //MOVE ACCOUNT

        [HttpGet("Move/{Id}/{AccountNumber}")]
        public async Task<IActionResult> Move(Guid Id,string AccountNumber)
        {
            try
            {
                var accountMove = await _accountAplicationService.getAccountMoveByAccountNumber(Id, AccountNumber);
                if (accountMove == null || accountMove.Count == 0)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Not Found Account!");
                }
                return Ok(accountMove);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Error!");
            }
           
        }

        // POST api/<AccountController>
        [HttpPost("Move/{AccountNumber}")]
        public async Task<IActionResult> Move(string AccountNumber,[FromBody] AccountMovedto accountMovedto)
        {
            try
            {
                if (accountMovedto == null)
                {
                    return BadRequest(ModelState);
                }


                var issave = await _accountAplicationService.creatMoveAccount(AccountNumber, accountMovedto);

                if (!issave)
                {
                    ModelState.AddModelError("", $"Something went wrong creating the record {accountMovedto.ToString()}");

                    return StatusCode(500, ModelState);
                }

                return Ok(accountMovedto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Error!");
            }
           
        }
    }
}
