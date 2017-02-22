using GOLDEN_MANAGER.Data;
using GOLDEN_MANAGER.Models;
using System.Web.Mvc;

namespace golden_manager.Controllers
{
    public class UserController : Controller
    {
        #region constructor

        public UserController()
        {
            repository = new ManagerDBRepository();
        }

        #endregion

        #region public logic

        public ActionResult Registration(User user)
        {
            if (user == null)
            {
                return PartialView("~/Views/Shared/_partialWriteStringView.cshtml",
                   "Can't register new user.");
            }

            if (repository.GetUserByEmail(user.user_email) == null)
            {
                user.userGroup = new UserGroup() { ug_id = 0 };
                repository.AddUser(user);
            }
            return RedirectToAction("Main");
        }

        #endregion

        #region private fields

        private ManagerDBRepository repository;

        #endregion
    }
}