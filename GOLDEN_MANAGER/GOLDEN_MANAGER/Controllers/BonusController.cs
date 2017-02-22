
using GOLDEN_MANAGER.Data;
using GOLDEN_MANAGER.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace GOLDEN_MANAGER.Controllers
{
    public class BonusController : Controller
    {
        #region constructor

        public BonusController()
        {
            repository = new ManagerDBRepository();
        }

        #endregion

        #region public logic

        public ActionResult Add(Bonus bonus)
        {
            if (bonus == null || Request.Cookies["userId"] == null)
            {
                return PartialView("~/Views/Shared/_partialWriteStringView.cshtml",
                   "Can't add the new bonus. Authorization needed.");
            }

            bonus.user = repository.GetUserById(int.Parse(Request.Cookies["userId"].Value));

            repository.AddBonus(bonus);

            IEnumerable<Bonus> bonuses = repository.GetAllBonuses()
                .Where(x => x.user.user_id == bonus.user.user_id);

            return PartialView(@"~\Views\ContentViews\BonusView.cshtml", bonuses);
        }

        #endregion

        #region private fields

        private ManagerDBRepository repository;

        #endregion
    }
}