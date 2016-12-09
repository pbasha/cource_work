
using GOLDEN_MANAGER.Data;
using GOLDEN_MANAGER.Models;
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
            if (bonus == null)
            {
                ViewData["errorMessage"] = "Can't add the new bonus. Looks like it's empty..";
                return View("ErrorView");
            }

            repository.AddBonus(bonus);

            return PartialView(@"~\Views\ContentViews\BonusView.cshtml", repository.GetAllBonuses());
        }

        #endregion

        #region private fields

        private ManagerDBRepository repository;

        #endregion
    }
}