using Clothes.Store.Domain.Entities;
using Clothes.Store.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clothes.Store.API.Controllers
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

        [HttpGet]
        public IActionResult GetAll()
        {
            var custumers = _context.Custumer.Where(d => d.IsActivate).ToList();

            return Ok(custumers);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var custumer = _context.Custumer.SingleOrDefault(d => d.CustumerID == id);

            if (custumer == null)
            {
                return NotFound();
            }

            return Ok(custumer);
        }

        [HttpPost]
        public IActionResult Post(Custumer custumer)
        {
            _context.Custumer.Add(custumer);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new {id = custumer.CustumerID}, custumer);
        }

        [HttpPut("{id}")]
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

        [HttpDelete("{id}")]
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
