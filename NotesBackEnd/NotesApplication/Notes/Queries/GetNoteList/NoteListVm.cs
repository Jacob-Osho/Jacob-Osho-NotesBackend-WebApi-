using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApplication.Notes.Queries.GetNoteList
{
    public  class NoteListVm
    {
        public IList<NoteLookUpDTO> Notes { get; set; }
    }
}
