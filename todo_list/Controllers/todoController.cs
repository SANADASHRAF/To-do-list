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

        #region daily 
        [HttpPost]
        public ActionResult home(daily d, string target)
        {
            if (target == "monthly")
            {
                return RedirectToAction("monthly");
            }

            if (target == "annual")
            {
                return RedirectToAction("anyaly");
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
            return RedirectToAction("showdaily");
        }


            public ActionResult monthly(monthly m)
        {

            m.Date = DateTime.Now;

            if (ModelState.IsValid)
            {
                db.monthlies.Add(m);

            }

            return View("monthly");

        }
        public ActionResult anyaly(annualcs a)
        {


            a.Date = DateTime.Now;

            if (ModelState.IsValid)
            {
                db.annualcs.Add(a);

            }

            return View("anyaly");


        }



    }
}