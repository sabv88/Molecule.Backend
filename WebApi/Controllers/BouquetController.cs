using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Molecule.Application.Bouquets.Commands.CreateBouquet;
using Molecule.Application.Bouquets.Commands.DeleteBouquet;
using Molecule.Application.Bouquets.Commands.UpdateBouquet;
using Molecule.Application.Bouquets.Queries.GetBouquetDetails;
using Molecule.Application.Bouquets.Queries.GetBouquetList;
using Notes.WebApi.Controllers;
using WebApi.Models.Bouquet;

namespace WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class BouquetController : BaseController
    {
        private readonly IMapper _mapper;

        public BouquetController(IMapper mapper) => _mapper = mapper;

        /// <summary>
        /// Gets the list of bouquets
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /bouquet
        /// </remarks>
        /// <returns>Returns BouquetListVm</returns>
        /// <response code="200">Success</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<BouquetListVm>> GetAll()
        {
            var query = new GetBouquetListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Gets the bouquet by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /bouquet/D34D349E-43B8-429E-BCA4-793C932FD580
        /// </remarks>
        /// <param name="id">Bouquet id (guid)</param>
        /// <returns>Returns BouquetDetailsVm</returns>
        /// <response code="200">Success</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<BouquetDetailsVm>> Get(Guid id)
        {
            var query = new GetBouquetDetailsQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Creates the bouquet
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /bouquet
        /// {
        ///     Name: "bouquet name",
        ///     Description: "some text",
        ///     Flours[]
        /// }
        /// </remarks>
        /// <param name="createBouquetDto">CreateBouquetDto object</param>
        /// <returns>Returns id (guid)</returns>
        /// <response code="201">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        ///         

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateBouquetDto createBouquetDto)
        {
            var command = _mapper.Map<CreateBouquetCommand>(createBouquetDto);
            var bouqueId = await Mediator.Send(command);
            return Ok(bouqueId);
        }

        /// <summary>
        /// Updates the bouquet
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// PUT /bouquet
        /// {
        ///     name: "updated bouquet name",
        ///     Description: "some text",
        ///     Flours[]
        /// }
        /// </remarks>
        /// <param name="updateBouquetDto">UpdateBouquetDto object</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        /// 
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Update([FromBody] UpdateBouquetDto updateBouquetDto)
        {
            var command = _mapper.Map<UpdateBouquetCommand>(updateBouquetDto);
            await Mediator.Send(command);
            return NoContent();
        }
        /// <summary>
        /// Deletes the bouquet by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE /bouquet/88DEB432-062F-43DE-8DCD-8B6EF79073D3
        /// </remarks>
        /// <param name="id">Id of the bouquet (guid)</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        /// 
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteBouquetCommand
            {
                Id = id
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
