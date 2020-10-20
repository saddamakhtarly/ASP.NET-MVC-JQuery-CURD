using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class ReadController : Controller
    {
        // GET: Read
       static List<Reading> readings = new List<Reading>()
            {
                new Reading(){ Id=1, Scoure ="Source-1", Reading1="Reading-1", Reading2="Reading-2", CreateDate=DateTime.Now},
                new Reading(){ Id=2, Scoure ="Source-2", Reading1="Reading-1", Reading2="Reading-2", CreateDate=DateTime.Now},
                new Reading(){ Id=3, Scoure ="Source-3", Reading1="Reading-1", Reading2="Reading-2", CreateDate=DateTime.Now}
            };
        public ActionResult Index()
        {

             return View(readings);
         
        }
      
        // GET: Read/Details/5
        public ActionResult Details(int id)
        {
            Reading s = readings.Where(x => x.Id == id).FirstOrDefault();
            return View(s);
        }
        [HttpGet]
        public string Detail(int id)
        {
            Reading s = readings.Where(x => x.Id == id).FirstOrDefault();

            return JsonConvert.SerializeObject(s);
        }

        // GET: Read/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Read/Create
        [HttpPost]
        public ActionResult Create(string Source, string Reading1, string Reading2,DateTime CreateDate)
        {
            try
            {
                Reading a = new Reading();
                int size= readings.Count;
                a.Id = size + 1;
                a.Scoure = Source;
                a.Reading1 = Reading1;
                a.Reading2 = Reading2;
                a.CreateDate = CreateDate;
                readings.Add(a);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Read/Edit/5
        [HttpGet]
        public string Edit(int id)
        {
            Reading s = readings.Where(x => x.Id == id).FirstOrDefault();
           
            return JsonConvert.SerializeObject(s); 
        }

        // POST: Read/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, string Source, string Reading1, string Reading2, DateTime CreateDate)
        //{
        //    try
        //    {
        //        Reading s = readings.Where(x => x.Id == id).FirstOrDefault();
        //        s.Scoure = Source;
        //        s.Reading1 = Reading1;
        //        s.Reading2 = Reading2;
        //        s.CreateDate = CreateDate;

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
        [HttpPost]
        public string Edit(Reading rd)
        {
            try
            {
                Reading s = readings.Where(x => x.Id == rd.Id).FirstOrDefault();
                s.Scoure = rd.Scoure;
                s.Reading1 = rd.Reading1;
                s.Reading2 = rd.Reading2;
                s.CreateDate = rd.CreateDate;
                return JsonConvert.SerializeObject(new { success = true, responseText = "The attached file is not supported." });
            }
            catch
            {
                return JsonConvert.SerializeObject(new { success = false, responseText = "The attached file is not supported." });
            }
        }
        // GET: Read/Delete/5
        public ActionResult Delete(int id)
        {
            Reading s = readings.Where(x => x.Id == id).FirstOrDefault();
            return View(s);
        }

        // POST: Read/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Reading collection)
        {
            try
            {// TODO: Add delete logic here
                Reading s = readings.Where(x => x.Id == id).FirstOrDefault();
                readings.Remove(s);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
