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
    [Route("api/[controller]")]
    public class NoteController : BaseController
    {
        private readonly IMapper _mapper;

        public NoteController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<FlourListVm>> GetAll()
        {
            var query = new GetFlourListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FlourDetailsVm>> Get(Guid id)
        {
            var query = new GetFlourDetailsQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateFlourDto createFlourDto)
        {
            var command = _mapper.Map<CreateFlourCommand>(createFlourDto);
            var flourId = await Mediator.Send(command);
            return Ok(flourId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateFlourDto updateNoteDto)
        {
            var command = _mapper.Map<UpdateFlourCommand>(updateNoteDto);
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
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