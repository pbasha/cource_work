using GOLDEN_MANAGER.Data;
using GOLDEN_MANAGER.Models;
using System.Collections.Generic;
using System.Linq;
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

        #region public logic

        public ActionResult Add(Task task)
        {
            if (task == null || Request.Cookies["userId"] == null)
            {
                return PartialView("~/Views/Shared/_partialWriteStringView.cshtml",
                   "Can't add the new task. Authorization needed.");
            }

            task.user = repository.GetUserById(int.Parse(Request.Cookies["userId"].Value));
            //task.task_bonuses.Add(repository.GetBonusById(1));
            //task.task_days_durations.Add(repository.GetDayById(1));

            repository.AddTask(task);

            //tasks for current user
            IEnumerable<Task> tasks = repository.GetAllTasks()
                .Where(x => x.user.user_id == task.user.user_id);

            return PartialView(@"~\Views\ContentViews\TaskView.cshtml", tasks);
        }

        public ActionResult Delete(Task task)
        {
            if (task == null || Request.Cookies["userId"] == null)
            {
                return PartialView("~/Views/Shared/_partialWriteStringView.cshtml",
                   "Can't add the new task. Authorization needed.");
            }

            //task.user = repository.GetUserById(int.Parse(Request.Cookies["userId"].Value));

            Task delTask = repository.GetAllTasks()
                .Where(x => x.task_name == task.task_name)
                .FirstOrDefault();

            if (delTask != null)
            {
                repository.DeleteTask(delTask.task_id);
            }

            //tasks for current user
            IEnumerable<Task> tasks = repository.GetAllTasks()
                .Where(x => x.user.user_id == int.Parse(Request.Cookies["userId"].Value));

            return PartialView(@"~\Views\ContentViews\TaskView.cshtml", tasks);
        }

        #endregion
    }
}