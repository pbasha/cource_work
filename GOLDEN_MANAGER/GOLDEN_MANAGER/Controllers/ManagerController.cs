using GOLDEN_MANAGER.Data;
using GOLDEN_MANAGER.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public ActionResult Authorization(User user)
        {
            User current_user = repository.GetUserByEmail(user.user_email);

            if (current_user != null && current_user.user_password == user.user_password)
            {
                Response.Cookies["userId"].Value = current_user.user_id.ToString();
                Response.Cookies["userId"].Expires = DateTime.MinValue;
            }

            return RedirectToAction("Main");
        }

        public ActionResult Main()
        {
            if (Request.Cookies["userId"] == null)
            {
                return View("~/Views/Manager/Main.cshtml", model:null);
            }
            else
            {
                User current_user = repository.GetUserById(int.Parse(Request.Cookies["userId"].Value));
                return View("~/Views/Manager/Main.cshtml", model:current_user.user_name);
            }

        }

        public ActionResult GoToHomePage()
        {
            if (Request.Cookies["userId"] == null)
            {
                return PartialView(@"~/Views/ContentViews/_partialMainContainer.cshtml", model:null);
            }
            else
            {
                User current_user = repository.GetUserById(int.Parse(Request.Cookies["userId"].Value));
                return PartialView(@"~/Views/ContentViews/_partialMainContainer.cshtml", model: current_user.user_name);
            }
        }

        public ActionResult GetTaskView()
        {
            if (Request.Cookies["userId"] == null)
                return PartialView("~/Views/Shared/_partialWriteStringView.cshtml",
                   "Sorry, but it looks like you are not registred...");

            int user_id = int.Parse(Request.Cookies["userId"].Value);

            IEnumerable<Task> tasks = repository.GetAllTasks()
                .Where(x => x.user.user_id == user_id);

            if (!Request.IsAjaxRequest() || tasks == null)
                return null;

            return PartialView(@"~\Views\ContentViews\TaskView.cshtml", tasks);
        }

        public ActionResult GetMotivationView()
        {
            if (Request.Cookies["userId"] == null)
                return PartialView("~/Views/Shared/_partialWriteStringView.cshtml",
                   "Sorry, but it looks like you are not registred...");

            int user_id = int.Parse(Request.Cookies["userId"].Value);

            IEnumerable<Motivation> mots = repository.GetAllMots()
                .Where(x => x.user.user_id == user_id);

            if (!Request.IsAjaxRequest() || mots == null)
                return null;

            return PartialView(@"~\Views\ContentViews\MotivationView.cshtml", mots);
        }

        public ActionResult GetBonusView()
        {
            if (Request.Cookies["userId"] == null)
                return PartialView("~/Views/Shared/_partialWriteStringView.cshtml",
                   "Sorry, but it looks like you are not registred...");

            int user_id = int.Parse(Request.Cookies["userId"].Value);

            IEnumerable<Bonus> bonuses = repository.GetAllBonuses()
                .Where(x => x.user.user_id == user_id);

            if (!Request.IsAjaxRequest() || bonuses == null)
                return null;

            return PartialView(@"~\Views\ContentViews\BonusView.cshtml", bonuses);
        }

        public ActionResult GetDaysView()
        {
            if (Request.Cookies["userId"] == null)
                return PartialView("~/Views/Shared/_partialWriteStringView.cshtml",
                   "Sorry, but it looks like you are not registred...");

            int user_id = int.Parse(Request.Cookies["userId"].Value);

            IEnumerable<Day> days = repository.GetAllDays()
                .Where(x => x.user.user_id == user_id);

            if (!Request.IsAjaxRequest() || days == null)
                return null;

            return PartialView(@"~\Views\ContentViews\DayView.cshtml", days);
        }

        public ActionResult GetNoteView()
        {
            if (Request.Cookies["userId"] == null)
                return PartialView("~/Views/Shared/_partialWriteStringView.cshtml",
                   "Sorry, but it looks like you are not registred...");

            int user_id = int.Parse(Request.Cookies["userId"].Value);

            IEnumerable<Note> notes = repository.GetAllNotes()
                .Where(x => x.user.user_id == user_id);

            if (!Request.IsAjaxRequest() || notes == null)
                return null;

            return PartialView(@"~\Views\ContentViews\NoteView.cshtml", notes);
        }

        public ActionResult GetSkillView()
        {
            if (Request.Cookies["userId"] == null)
                return PartialView("~/Views/Shared/_partialWriteStringView.cshtml",
                   "Sorry, but it looks like you are not registred...");

            int user_id = int.Parse(Request.Cookies["userId"].Value);

            IEnumerable<Skill> skills = repository.GetAllSkills()
                .Where(x => x.user.user_id == user_id);

            if (!Request.IsAjaxRequest() || skills == null)
                return null;

            return PartialView(@"~\Views\ContentViews\SkillView.cshtml", skills);
        }

        public ActionResult GetAboutView()
        {
            if (!Request.IsAjaxRequest())
                return null;

            //delete cookie
            Response.Cookies["userId"].Expires = DateTime.Now.AddDays(-1d);

            return PartialView("~/Views/Shared/_partialWriteStringView.cshtml",
                   "Progress manager. Basha Pavlo. MIT License.");
        }

        #endregion
    }
}