using MediatR;
using System;


namespace NotesApplication.Notes.Commands.UpdateNote
{
    public class DeleteNoteCommand :IRequest
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }

    }
}
