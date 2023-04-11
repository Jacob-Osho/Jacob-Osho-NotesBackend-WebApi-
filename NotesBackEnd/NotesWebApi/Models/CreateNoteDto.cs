using AutoMapper;
using NotesApplication.Common.Mappings;
using NotesApplication.Notes.Commands.CreateNote;

namespace NotesWebApi.Models
{
    public class CreateNoteDto : IMapWith<CreateNoteCommand>
    {
        public string Title { get; set; }
        public string Details { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateNoteDto, CreateNoteCommand>()
                        .ForMember(noteComand => noteComand.Title, opt => opt.MapFrom(noteDto => noteDto.Title))
                        .ForMember(noteComand => noteComand.Details, opt => opt.MapFrom(noteDto => noteDto.Details));
        }
    }
}
