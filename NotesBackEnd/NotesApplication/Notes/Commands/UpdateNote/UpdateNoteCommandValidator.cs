﻿using FluentValidation;
using System;
    
namespace NotesApplication.Notes.Commands.UpdateNote
{
    public class UpdateNoteCommandValidator :AbstractValidator<UpdateNoteCommand>
    {
        public UpdateNoteCommandValidator()
        {
            RuleFor(updateNoteCommand=>updateNoteCommand.Title).NotEmpty().MaximumLength(250);
            RuleFor(updateNoteCommand=>updateNoteCommand.UserId).NotEqual(Guid.Empty);
            RuleFor(updateNoteCommand=>updateNoteCommand.Id).NotEqual(Guid.Empty);

        }
    }
}
