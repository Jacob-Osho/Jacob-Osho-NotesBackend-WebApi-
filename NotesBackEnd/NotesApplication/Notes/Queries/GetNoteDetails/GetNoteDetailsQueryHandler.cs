﻿using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NotesApplication.Common.Exeptions;
using NotesApplication.Interfaces;
using NotesDomain;
using System.Threading;
using System.Threading.Tasks;

namespace NotesApplication.Notes.Queries.GetNoteDetails
{
    public class GetNoteDetailsQueryHandler : IRequestHandler<GetNoteDetailsQuery, NoteDetailsVm>
    {
        private readonly INotesDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetNoteDetailsQueryHandler(INotesDbContext dbContext,IMapper mapper) =>
            (_dbContext,_mapper) = (dbContext, mapper);
        public  async Task<NoteDetailsVm> Handle(GetNoteDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Notes
                .FirstOrDefaultAsync( note => note.Id == request.Id,cancellationToken );
            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundExeption(nameof(Note), request.Id);
            }
          

            return _mapper.Map<NoteDetailsVm>(entity);

        }
    }
}
