using MediatR;
using System;


namespace NotesApplication.Notes.Queries.GetNoteDetails
{
    public class GetNoteDetailsQuery:IRequest<NoteDetailsVm>
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }
}
