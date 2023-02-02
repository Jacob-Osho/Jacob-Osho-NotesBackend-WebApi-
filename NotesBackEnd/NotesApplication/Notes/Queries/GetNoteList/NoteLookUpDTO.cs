using AutoMapper;
using NotesApplication.Common.Mappings;
using NotesDomain;
using System;


namespace NotesApplication.Notes.Queries.GetNoteList
{
    public class NoteLookUpDTO :IMapWith<Note>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Note, NoteLookUpDTO>()
                .ForMember(noteDto => noteDto.Title,
                opt => opt.MapFrom(note => note.Title))
                .ForMember(noteDto => noteDto.Id,
                opt => opt.MapFrom(note => note.Id));
        }
    }
}
