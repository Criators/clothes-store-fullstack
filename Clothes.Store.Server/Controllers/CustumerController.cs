using Clothes.Store.Domain.Entities;
using Clothes.Store.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clothes.Store.Server.Controllers
{
    [Route("api/custumer")]
    [ApiController]
    public class CustumerController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public CustumerController(DatabaseContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get all the custumers
        /// </summary>
        /// <returns>Collection of Custumers</returns>
        /// <response code="200">Success</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            var custumers = _context.Custumer.Where(d => d.IsActivate).ToList();

            return Ok(custumers);
        }

        /// <summary>
        /// Get one custumer by identifier
        /// </summary>
        /// <param name="id">Identifier of Custumer</param>
        /// <returns>Data of Custumer</returns>
        /// <response code="200">Success</response>
        /// /// <response code="404">Not Found</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(Guid id)
        {
            var custumer = _context.Custumer.SingleOrDefault(d => d.CustumerID == id);

            if (custumer == null)
            {
                return NotFound();
            }

            return Ok(custumer);
        }

        /// <summary>
        /// Register custumer
        /// </summary>
        /// <remarks>
        /// {"custumerName": "string", "email": "string", "cpf": "string", "password": "string", "criationDateHour": "NOW", "typeUser": 1}
        /// </remarks>
        /// <param name="custumer">Data of Custumer</param>
        /// <returns>Created Object</returns>
        /// <response code="201">Success</response> 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Post(Custumer custumer)
        {
            _context.Custumer.Add(custumer);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = custumer.CustumerID }, custumer);
        }

        /// <summary>
        /// Update a custumer
        /// </summary>
        /// <remarks>
        /// {"custumerName": "string", "email": "string", "cpf": "string", "password": "string", "criationDateHour": "NOW", "typeUser": 1}
        /// </remarks>
        /// <param name="id">Identifier of Custumer</param>
        /// <param name="input">Data of Custumer</param>
        /// <returns>No Content</returns>
        /// <response code="204">Success</response>
        /// <response code="404">Not Found</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Update(Guid id, Custumer input)
        {
            var custumer = _context.Custumer.SingleOrDefault(d => d.CustumerID == id);

            if (custumer == null)
            {
                return NotFound();
            }

            custumer.Update(input.CustumerName, input.Email, input.CPF, input.Password, input.CriationDateHour, input.TypeUser);

            _context.Custumer.Update(custumer);
            _context.SaveChanges();

            return NoContent();
        }

        /// <summary>
        /// Desactivate a custumer
        /// </summary>
        /// <param name="id">Identifier of Custumer</param>
        /// <returns>No Content</returns>
        /// <response code="204">Success</response>
        /// <response code="404">Not Found</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(Guid id)
        {
            var custumer = _context.Custumer.SingleOrDefault(d => d.CustumerID == id);

            if (custumer == null)
            {
                return NotFound();
            }

            custumer.Delete();

            _context.SaveChanges();

            return NoContent();
        }
    }
}
