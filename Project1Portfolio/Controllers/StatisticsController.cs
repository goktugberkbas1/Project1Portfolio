using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project1Portfolio.Models;

namespace Project1Portfolio.Controllers
{
    public class StatisticsController : Controller
    {
        MyPortfolioDbEntities context = new MyPortfolioDbEntities();
        public ActionResult Index()
        {
            int messageCount = context.Message.Count();
            int messageCountIsReadyByTrue = context.Message.Where(x => x.IsRead == true).Count();
            int messageCountIsReadyByFalse = context.Message.Where(x => x.IsRead == false).Count();
            int skillCount = context.Skill.Count();
            var totalSkillValue = context.Skill.Sum(x => x.Value);
            var avarageSkillValue = context.Skill.Average(x => x.Value);
            var getEmailFromProfile = context.Profile.Select(x => x.Email).FirstOrDefault();
            var getLastCategoryId = context.Category.Max(x => x.CategoryId);
            var getLastCategoryName = context.Category.Where(x => x.CategoryId == getLastCategoryId).Select(y => y.CategoryName).FirstOrDefault();

            ViewBag.messageCount = messageCount;
            ViewBag.messageCountIsReadyByTrue = messageCountIsReadyByTrue;
            ViewBag.messageCountIsReadyByFalse = messageCountIsReadyByFalse;
            ViewBag.skillCount = skillCount;
            ViewBag.totalSkillValue = totalSkillValue;
            ViewBag.avarageSkillValue = avarageSkillValue;
            ViewBag.getEmailFromProfile = getEmailFromProfile;
            ViewBag.getLastCategoryName = getLastCategoryName;


            return View();
        }
    }
}