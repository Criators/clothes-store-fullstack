using AutoMapper;
using Clothes.Store.Application.Interfaces;
using Clothes.Store.Application.Interfaces.Services;
using Clothes.Store.Domain.Entities;
using Clothes.Store.Application.Models.InputModel;
using Clothes.Store.Application.Models.ViewModel;
using Clothes.Store.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Clothes.Store.Server.Controllers
{
    [Route("api/custumer")]
    [ApiController]
    public class CustumerController : ControllerBase
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        private readonly ICustumerService _custumerService;
        private readonly ICustumer _custumer;
        private readonly ILogger<CustumerController> _logger;

        public CustumerController(DatabaseContext context,
                                  IMapper mapper,
                                  ICustumerService custumerService,
                                  ICustumer custumer,
                                  ILogger<CustumerController> logger)
        {
            _context = context;
            _mapper = mapper;

            _custumerService = custumerService;
            _custumer = custumer;
            _logger = logger;
        }

        /// <summary>
        /// Get all the custumers
        /// </summary>
        /// <returns>Collection of Custumers</returns>
        /// <response code="200">Success</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            //var custumers = _context.Custumer.Where(d => d.IsActivate).ToList();
            var custumer = await _custumer.GetAll();
            var viewModel = _mapper.Map<List<CustumerViewModel>>(custumer);

            return Ok(viewModel);
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
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var custumer = await _custumer.GetById(id);

                if (custumer == null)
                {
                    return NotFound();
                }

                var viewModel = _mapper.Map<CustumerViewModel>(custumer);

                return Ok(viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while get data. (GetByIdCustumerMethod)");
                return StatusCode(500, "Server internal error!");
            }
        }

        /// <summary>
        /// Register custumer
        /// </summary>
        /// <remarks>
        /// {"custumerName": "string", "email": "string", "cpf": "string", "password": "string", confirmedPassword: "string", "usertype": 1}
        /// </remarks>
        /// <param name="input">Data of Custumer</param>
        /// <returns>Created Object</returns>
        /// <response code="201">Success</response> 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Post(CustumerInputModel input)
        {
            var custumer = _mapper.Map<Custumer>(input);

            try
            {
                var savedCustumer = await _custumerService.SaveCustumer(custumer);

                var viewModel = _mapper.Map<CustumerViewModel>(savedCustumer);

                return CreatedAtAction(nameof(GetById), new { id = viewModel.CustumerID }, viewModel);
            } catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while recording. (PostCustumerMethod)");
                return StatusCode(500, "Server internal error!");
            }
        }

        /// <summary>
        /// Update a custumer
        /// </summary>
        /// <remarks>
        /// {"custumerName": "string", "email": "string", "cpf": "string", "password": "string", "usertype": 1}
        /// </remarks>
        /// <param name="id">Identifier of Custumer</param>
        /// <param name="input">Data of Custumer</param>
        /// <returns>No Content</returns>
        /// <response code="204">Success</response>
        /// <response code="404">Not Found</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(Guid id, UpdateCustumerInputModel input)
        {
            var custumer = await _custumer.GetById(id);

            if (custumer == null)
            {
                return NotFound();
            }

            custumer.CustumerName = input.CustumerName;
            custumer.Email = input.Email;
            custumer.CPF = input.CPF;

            await _custumer.Update(custumer);

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
        public async Task<IActionResult> Delete(Guid id)
        {
            var custumer = await _custumer.GetById(id);

            if (custumer == null)
            {
                return NotFound();
            }

            await _custumer.Delete(custumer);

            return NoContent();
        }
    }
}
