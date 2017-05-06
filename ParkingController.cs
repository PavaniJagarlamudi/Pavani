using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyApplication.Models;

namespace MyApplication.Controllers
{
    public class ParkingController : Controller
    {


        static List<parkData> parkInfo = new List<parkData>();
        // GET: Parking
        public ActionResult Index()
        {
            ParkInfoDaoImpl parkdao = new ParkInfoDaoImpl();
            parkInfo = parkdao.getParkingInformation();
            List<string> cm = new List<string>();
            foreach (var info in parkInfo)
            {
                cm.Add(info.parkSlotId);
            }
            SelectList MakerName1 = new SelectList(cm);
            ViewData["parkSlotId"] = MakerName1;
            return View(ViewData);
        }

        // GET: Parking/Details/5
        public ActionResult Parking()
        {
            ParkInfoDaoImpl parkdao = new ParkInfoDaoImpl();
            parkdao.updateParkingInformation();
            List<parkData> parkInfo = parkdao.getParkingInformation();
            return RedirectToAction("Success");
        }

        public ActionResult Success()
        {
            ViewBag.Title = "Success ";

            return View();
        }

        public JsonResult Availability(string Maker)
        {
            List<string> ModelList = new List<string>();
            foreach (var location in parkInfo)
            {
                if (location.parkSlotId == Maker)
                {

                    ModelList.Add(location.isParkingAvailable);

                }
            }

            return Json(ModelList);
        }


        // GET: Parking/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Parking/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Parking/Edit/5
        public ActionResult Edit(int id)
        {
            ParkInfoDaoImpl parkdao = new ParkInfoDaoImpl();
            parkdao.updateParkingInformation();
            List<parkData> parkInfo = parkdao.getParkingInformation();
            return View(parkInfo);
        }

        // POST: Parking/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                ParkInfoDaoImpl parkdao = new ParkInfoDaoImpl();
                parkdao.updateParkingInformation();
                List<parkData> parkInfo = parkdao.getParkingInformation();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Parking/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Parking/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
