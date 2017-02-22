using GOLDEN_MANAGER.Data;
using GOLDEN_MANAGER.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace GOLDEN_MANAGER.Controllers
{
    public class NoteController : Controller
    {
        #region constructor

        public NoteController()
        {
            repository = new ManagerDBRepository();
        }

        #endregion

        #region private fields

        private ManagerDBRepository repository;

        #endregion

        #region public logic

        public ActionResult Add(Note note)
        {
            if (note == null || Request.Cookies["userId"] == null)
            {
                return PartialView("~/Views/Shared/_partialWriteStringView.cshtml",
                   "Can't add the new day. Authorization needed.");
            }

            note.user = repository.GetUserById(int.Parse(Request.Cookies["userId"].Value));
            note.noteGroup = new NoteGroup() { np_id = 0 };

            repository.AddNote(note);

            IEnumerable<Note> notes = repository.GetAllNotes()
                .Where(x => x.user.user_id == note.user.user_id);

            return PartialView(@"~\Views\ContentViews\NoteView.cshtml", notes);
        }

        #endregion
    }
}