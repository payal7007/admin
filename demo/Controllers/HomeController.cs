using demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace demo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
       
        public ActionResult addlist()
        {
           AdslistRepo repo = new AdslistRepo();
            List<MyAdvertise> advertiseList = repo.Advertises(); 
            return View(advertiseList);
        }
        //[HttpPost]
        //public ActionResult ApproveAdvertise(int advertiseId)
        //{
        //    AdslistRepo repo = new AdslistRepo();
        //    bool approve = repo.ApproveAdvertise(advertiseId);
        //    return View(approve);
        //}
        [HttpPost]
        public ActionResult ApproveAdvertisement(int advertiseId)
        {
                AdslistRepo repo = new AdslistRepo();
                bool isApproved = repo.ApproveAdvertise(advertiseId);

            if (isApproved == true)
            {
                return  Json(new { success= true });
            }
            else
            {
                return Json(new { success = false });
            }

        }

        [HttpPost]
        public ActionResult RejectAdvertisement(int advertiseId)
        {
                AdslistRepo repo = new AdslistRepo();
                bool isRejected = repo.RejectAdvertisement(advertiseId);

                if (isRejected != true)
                {
                    return Json(new { success = true });
                }
                else
                {
                    return Json(new { success = false });
                }
            }
          
        }

    }



