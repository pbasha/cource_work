using GOLDEN_MANAGER.Data;
using GOLDEN_MANAGER.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace GOLDEN_MANAGER.Controllers
{
    public class ManagerController : Controller
    {
        #region private fields

        private ManagerDBRepository repository;

        #endregion

        #region constructor

        public ManagerController()
        {
            repository = new ManagerDBRepository();
        }

        #endregion

        #region getView's methods

        public ActionResult Registration()
        {
            return View("RegistrationView");
        }

        public ActionResult Main()
        {
            return View();
        }

        public ActionResult GetTaskView()
        {
            IEnumerable<Task> tasks = repository.GetAllTasks();

            if (!Request.IsAjaxRequest() || tasks == null)
                return null;

            return PartialView(@"~\Views\ContentViews\TaskView.cshtml", tasks);
        }

        public ActionResult GetBonusView()
        {
            IEnumerable<Bonus> bonuses = repository.GetAllBonuses();

            if (!Request.IsAjaxRequest() || bonuses == null)
                return null;

            return PartialView(@"~\Views\ContentViews\BonusView.cshtml", bonuses);
        }

        public ActionResult GetNoteView()
        {
            IEnumerable<Note> notes = repository.GetAllNotes();

            if (!Request.IsAjaxRequest() || notes == null)
                return null;

            return PartialView(@"~\Views\ContentViews\NoteView.cshtml", notes);
        }

        public ActionResult GetSkillView()
        {
            IEnumerable<Skill> skills = repository.GetAllSkills();

            if (!Request.IsAjaxRequest() || skills == null)
                return null;

            return PartialView(@"~\Views\ContentViews\SkillView.cshtml", skills);
        }

        public ActionResult GetAboutView()
        {
            if (!Request.IsAjaxRequest())
                return null;

            return PartialView(@"");
        }

        #endregion
    }
}