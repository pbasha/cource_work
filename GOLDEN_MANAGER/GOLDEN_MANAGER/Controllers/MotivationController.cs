using GOLDEN_MANAGER.Data;
using GOLDEN_MANAGER.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace golden_manager.Controllers
{
    public class MotivationController : Controller
    {
        #region constructor

        public MotivationController()
        {
            repository = new ManagerDBRepository();
        }

        #endregion

        #region private fields

        private ManagerDBRepository repository;

        #endregion

        #region public logic

        public ActionResult Add(Motivation mot)
        {
            if (mot == null || Request.Cookies["userId"] == null)
            {
                return PartialView("~/Views/Shared/_partialWriteStringView.cshtml",
                   "Can't add the new motivation. Authorization needed.");
            }

            mot.user = repository.GetUserById(int.Parse(Request.Cookies["userId"].Value));
            //mot.task = new Task() { task_id = 1 };

            repository.Addmotivation(mot);

            IEnumerable<Motivation> mots = repository.GetAllMots()
                .Where(x => x.user.user_id == mot.user.user_id);

            return PartialView(@"~\Views\ContentViews\MotivationView.cshtml", mots);
        }

        #endregion
    }
}