using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LITIsEpic.Data;
using LITIsEpic.Web.Models;

namespace LITIsEpic.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var repo = new VisitsRepository(Properties.Settings.Default.ConStr);
            repo.AddVisit(Request.UserHostAddress);
            var vm = new HomePageViewModel
            {
                FiveMostFrequentIPs = repo.GetFiveMostFrequentIPs(),
                TodayCount = repo.GetVisitCountForToday(),
                MostPopularIP = repo.GetMostPopularIpAddress()
            };
            return View(vm);
        }
    }
}