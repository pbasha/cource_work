using GOLDEN_MANAGER.Data;
using GOLDEN_MANAGER.Models;
using System.Web.Mvc;

namespace GOLDEN_MANAGER.Controllers
{
    public class TaskController : Controller
    {
        #region constructor

        public TaskController()
        {
            repository = new ManagerDBRepository();
        }

        #endregion

        #region private fields

        private ManagerDBRepository repository;

        #endregion

        public ActionResult Add(Task task)
        {
            if (task == null)
            {
                ViewData["errorMessage"] = "Can't add the new task. Looks like it's empty..";
                return View("ErrorView");
            }

            repository.AddTask(task);

            return PartialView(@"~\Views\ContentViews\TaskView.cshtml", repository.GetAllTasks());
        }
    }
}