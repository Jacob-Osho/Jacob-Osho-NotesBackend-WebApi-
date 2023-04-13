﻿using FluentValidation;
using System;

namespace NotesApplication.Notes.Commands.CreateNote
{
    internal class CreateNoteCommandValidator : AbstractValidator<CreateNoteCommand>
    {
        public CreateNoteCommandValidator()
        {
            RuleFor(createNoteCommand => createNoteCommand.Title).NotEmpty().MaximumLength(250);
            RuleFor(createNoteCommand => createNoteCommand.UserId).NotEqual(Guid.Empty);
                    
        }
    }
}