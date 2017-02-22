using GOLDEN_MANAGER.Data;
using GOLDEN_MANAGER.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace golden_manager.Controllers
{
    public class DayController : Controller
    {
        #region constructor

        public DayController()
        {
            repository = new ManagerDBRepository();
        }

        #endregion

        #region public logic

        public ActionResult Add(Day day)
        {
            if (day == null || Request.Cookies["userId"] == null)
            {
                return PartialView("~/Views/Shared/_partialWriteStringView.cshtml",
                   "Can't add the new day. Authorization needed.");
            }

            day.user = repository.GetUserById(int.Parse(Request.Cookies["userId"].Value));

            repository.AddDay(day);

            IEnumerable<Day> days = repository.GetAllDays()
                .Where(x => x.user.user_id == day.user.user_id);

            return PartialView(@"~\Views\ContentViews\DayView.cshtml", days);
        }

        #endregion

        #region private fields

        private ManagerDBRepository repository;

        #endregion
    }
}