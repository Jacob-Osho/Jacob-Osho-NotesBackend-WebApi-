﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NotesApplication.Notes.Commands.CreateNote;
using NotesApplication.Notes.Commands.UpdateNote;
using NotesApplication.Notes.Queries.GetNoteDetails;
using NotesApplication.Notes.Queries.GetNoteList;
using NotesWebApi.Models;
using System;
using System.Threading.Tasks;

namespace NotesWebApi.Controllers
{
    [Route("api/[controller]")]
    public class NoteController : BaseController
    {

        private readonly IMapper _mapper;
        public NoteController(IMapper mapper)=> _mapper = mapper;   

        [HttpGet]
        public async Task<ActionResult<NoteListVm>> GetAll()
        {
            var query = new GetNoteListQuery { UserId = UserId };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<NoteDetailsVm>> GetAll(Guid id)
        {
            var query = new GetNoteDetailsQuery
            {
                UserId = UserId,
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create( [FromBody] CreateNoteDto createNoteDto)
        {
            var command = _mapper.Map<CreateNoteCommand>(createNoteDto);
            command.UserId =UserId;
            var noteId = await Mediator.Send(command);
            return Ok(noteId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateNoteDto updateNoteDto)
        {
            var command = _mapper.Map<UpdateNoteCommand>(updateNoteDto);
            command.UserId = UserId;
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteNoteCommand
            {
                Id = id,
                UserId = UserId
            };
            await Mediator.Send(command);
            return NoContent();
        }

    }
}
