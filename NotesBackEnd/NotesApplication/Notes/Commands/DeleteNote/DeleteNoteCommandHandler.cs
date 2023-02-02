using MediatR;
using Microsoft.EntityFrameworkCore;
using NotesApplication.Common.Exeptions;
using NotesApplication.Interfaces;
using NotesDomain;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NotesApplication.Notes.Commands.UpdateNote
{
    public class DeleteNoteCommandHandler : IRequestHandler<DeleteNoteCommand>
    {
        private readonly INotesDbContext _dbContext;
        public DeleteNoteCommandHandler(INotesDbContext dbContext) =>   
            _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Notes.FindAsync( new object[] {request.Id},cancellationToken);
            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundExeption(nameof(Note), request.Id);
            }

             _dbContext.Notes.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
