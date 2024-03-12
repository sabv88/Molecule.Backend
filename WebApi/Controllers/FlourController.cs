using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Molecule.Application.Flours.Commands.CreateFlour;
using Molecule.Application.Flours.Commands.DeleteFlour;
using Molecule.Application.Flours.Commands.UpdateFlour;
using Molecule.Application.Flours.Queries.GetFlourDetails;
using Molecule.Application.Flours.Queries.GetFlourList;
using Molecule.Backend.Models;

namespace Notes.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class FlourController : BaseController
    {
        private readonly IMapper _mapper;

        public FlourController(IMapper mapper) => _mapper = mapper;

        /// <summary>
        /// Gets the list of flours
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /flour
        /// </remarks>
        /// <returns>Returns FlourListVm</returns>
        /// <response code="200">Success</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<FlourListVm>> GetAll()
        {
            var query = new GetFlourListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Gets the flour by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /flour/D34D349E-43B8-429E-BCA4-793C932FD580
        /// </remarks>
        /// <param name="id">Flour id (guid)</param>
        /// <returns>Returns FlourDetailsVm</returns>
        /// <response code="200">Success</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<FlourDetailsVm>> Get(Guid id)
        {
            var query = new GetFlourDetailsQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Creates the flour
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /flour
        /// {
        ///     Name: "flour name",
        /// }
        /// </remarks>
        /// <param name="createNoteDto">CreateFlourDto object</param>
        /// <returns>Returns id (guid)</returns>
        /// <response code="201">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        ///         

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateFlourDto createFlourDto)
        {
            var command = _mapper.Map<CreateFlourCommand>(createFlourDto);
            var flourId = await Mediator.Send(command);
            return Ok(flourId);
        }

        /// <summary>
        /// Updates the flour
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// PUT /flour
        /// {
        ///     name: "updated flour name"
        /// }
        /// </remarks>
        /// <param name="updateNoteDto">UpdateFlourDto object</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        /// 
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Update([FromBody] UpdateFlourDto updateNoteDto)
        {
            var command = _mapper.Map<UpdateFlourCommand>(updateNoteDto);
            await Mediator.Send(command);
            return NoContent();
        }
        /// <summary>
        /// Deletes the flour by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE /flour/88DEB432-062F-43DE-8DCD-8B6EF79073D3
        /// </remarks>
        /// <param name="id">Id of the flour (guid)</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        /// 
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteFlourCommand
            {
                Id = id
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}