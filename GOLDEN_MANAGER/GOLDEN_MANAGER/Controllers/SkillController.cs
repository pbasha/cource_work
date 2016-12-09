using GOLDEN_MANAGER.Data;
using GOLDEN_MANAGER.Models;
using System.Web.Mvc;

namespace GOLDEN_MANAGER.Controllers
{
    public class SkillController : Controller
    {
        #region constructor

        public SkillController()
        {
            repository = new ManagerDBRepository();
        }

        #endregion

        #region private fields

        private ManagerDBRepository repository;

        #endregion

        #region public logic

        public ActionResult Add(Skill skill)
        {
            if (skill == null)
            {
                ViewData["errorMessage"] = "Can't add the new skill. Looks like it's empty..";
                return View("ErrorView");
            }

            repository.AddSkill(skill);

            return PartialView(@"~\Views\ContentViews\SkillView.cshtml", repository.GetAllSkills());
        }

        #endregion
    }
}