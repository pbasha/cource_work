using GOLDEN_MANAGER.Data;
using GOLDEN_MANAGER.Models;
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
            if (note == null)
            {
                ViewData["errorMessage"] = "Can't add the new node. Looks like it's empty..";
                return View("ErrorView");
            }

            repository.AddNote(note);

            return PartialView(@"~\Views\ContentViews\NoteView.cshtml", repository.GetAllNotes());
        }

        #endregion
    }
}