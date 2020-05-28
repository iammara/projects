using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Linq.Mapping;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class HomeController : Controller
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();

        
        public ActionResult Show()
        {
            List<List> listA = dc.Lists.ToList<List>();
            List<List> listB = new List<List>();
            if (listA != null)
            {
                foreach (var q in listA)
                {
                    listB.Add(q);
                }
            }
            if (listB != null)
            {
                return View(listB);
            }
            else
            {
                return View();
            }
        }
        public ActionResult Add()
        {
            return View();
        }
        public ActionResult AddTODO()
        {
            String todo = Request.Form["todo"];
            String duedate = Request.Form["ddate"];
            String priority = Request.Form["priority"];
            List b = new List();
            b.ToDo = todo;
            b.DueDate = duedate;
            b.Priority = priority;

            dc.Lists.InsertOnSubmit(b);
            dc.SubmitChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Update()
        {

            return View();
        }
        public ActionResult UpdateTODO()
        {
            int id = int.Parse(Request.Form["id"]);

            String todo = Request.Form["todo"];
            String duedate = Request.Form["ddate"];
            String priority = Request.Form["priority"];
            try
            {
                List b = dc.Lists.First(a => a.Id.Equals(id));
                b.ToDo = todo;
                b.DueDate = duedate;
                b.Priority = priority;
            
                dc.SubmitChanges();
            }catch(Exception e) { }
            return RedirectToAction("Show");
        }
        public ActionResult Index()
        {
             return View();
        }
        public ActionResult High()
        {
            List<List> listA = dc.Lists.ToList<List>();
            List<List> listB = new List<List>();
            if (listA != null)
            {
                foreach (var q in listA)
                {
                    listB.Add(q);
                }
            }
            if (listB != null)
            {
                return View(listB);
            }
            else
            {
                return View();
            }
        }
        public ActionResult Medium()
        {
            List<List> listA = dc.Lists.ToList<List>();
            List<List> listB = new List<List>();
            if (listA != null)
            {
                foreach (var q in listA)
                {
                    listB.Add(q);
                }
            }
            if (listB != null)
            {
                return View(listB);
            }
            else
            {
                return View();
            }
        }
        public ActionResult Low()
        {
            List<List> listA = dc.Lists.ToList<List>();
            List<List> listB = new List<List>();
            if (listA != null)
            {
                foreach (var q in listA)
                {
                    listB.Add(q);
                }
            }
            if (listB != null)
            {
                return View(listB);
            }
            else
            {
                return View();
            }
        }
    }
}