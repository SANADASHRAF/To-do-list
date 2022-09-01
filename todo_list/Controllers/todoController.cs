using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows.Documents;
using todo_list.Models;

namespace todo_list.Controllers
{
    public class todoController : Controller
    {

        datacontext db= new datacontext();


        //toster notification

        #region home
        public ActionResult home()
        {

            return View(db.dailies.ToList());
        }
        #endregion

        #region hom2
        [HttpPost]
        public ActionResult home(daily d, string target)
        {
            if (target == "monthly")
            {
                return RedirectToAction("monthly",new {Name=d.Name });
            }

            if (target == "annual")
            {
                return RedirectToAction("anyaly",new { Name = d.Name });
            }

            d.Date = DateTime.Now;

            if (target == "daily" && d.Name != "")
            {   
                if (ModelState.IsValid)
                {
                    db.dailies.Add(d);
                    db.SaveChanges();
                    return RedirectToAction("home");

                }
             }



            return RedirectToAction("home");
        }
        #endregion

        #region show daily todo
        public ActionResult showdaily()
        {
            List<daily> li = db.dailies.ToList();
            return View(li);
        }
        #endregion

        #region delete daily
        public ActionResult delete(int Id)
        {
            var delitem = db.dailies.Where(d => d.Id == Id).SingleOrDefault();
            db.dailies.Remove(delitem);
            db.SaveChanges();
            return RedirectToAction("showdaily");
        }
        #endregion

        #region uppdate daily todo
        public ActionResult update(int Id)
        {
            var x = db.dailies.Where(n => n.Id == Id).SingleOrDefault();

            return View(x);
        }

        [HttpPost]
        public ActionResult update(daily d)
        {
            db.Entry(d).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("home");
        }

        #endregion

        ///////////////////////////////////////////////monthly
        #region add manthly todo 
        public ActionResult monthly(monthly m)
        {

            m.Date = DateTime.Now;

            if (m.Name != "")
            {
                if (ModelState.IsValid)
                {
                    db.monthlies.Add(m);
                    db.SaveChanges();
                    return RedirectToAction("monthshow");

                }
            }
            
            return RedirectToAction("monthshow");
        }
        #endregion

        #region monthshow todo
        public ActionResult monthshow()
        {
            List<monthly> li = db.monthlies.ToList();
            return View(li);
        }
        #endregion

        #region delmonth todo
        public ActionResult delmonth(int Id)
        {
            var x = db.monthlies.Where(n => n.Id == Id).SingleOrDefault();
            db.monthlies.Remove(x);
            db.SaveChanges();
            return RedirectToAction("monthshow");
        }
        #endregion


        #region updatemonth todo
        public ActionResult updatemonth(int Id)
        {
            var x = db.monthlies.Where(n => n.Id == Id).SingleOrDefault();
            return View(x);
        }
        [HttpPost]
        public ActionResult updatemonth(monthly m)
        {
            if (ModelState.IsValid)
            {
                db.Entry(m).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("monthshow");
            }
            return View();
        }

        #endregion


        ////////////////////////////////////////////////anyaly
        #region addannual todo
        public ActionResult anyaly(annualcs a)
        {

            a.Date = DateTime.Now;
            if (a.Name != "")
            {
                if (ModelState.IsValid)
                {
                    db.annualcs.Add(a);
                    db.SaveChanges();
                    return RedirectToAction("anualshow");
                }
            }
            return View("anualshow");
        } 
        #endregion

        #region anualhshow todo
        public ActionResult anualshow()
        {
            List<annualcs> li = db.annualcs.ToList();
            return View(li);
        }

        #endregion

        #region delanual todo
        public ActionResult delanual(int Id)
        {
            var x = db.annualcs.Where(n => n.Id == Id).SingleOrDefault();
            db.annualcs.Remove(x);
            db.SaveChanges();
            return RedirectToAction("anualshow");
        }
        #endregion


        #region updateannual todo
        public ActionResult updateannual(int Id)
        {
            var x = db.annualcs.Where(n => n.Id == Id).SingleOrDefault();
            return View(x);
        }

        [HttpPost]
       
        public ActionResult updateannual(annualcs a)
        {
            if (ModelState.IsValid)
            {
                db.Entry(a).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("anualshow");
            }
            return View();
        }

        #endregion
  
    
    }
}