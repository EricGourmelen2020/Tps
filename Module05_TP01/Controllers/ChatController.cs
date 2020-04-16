using Module05_TP01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TPModule3;

namespace Module05_TP01.Controllers
{
    public class ChatController : Controller
    {
        // GET: Chat
        public ActionResult Index()
        {
            List<Chat> listeChats = Data.Instance.ListeChats;

            return View(listeChats);
        }

        // GET: Chat/Details/5
        public ActionResult Details(int id)
        {
            Chat chatDetails = Data.Instance.ListeChats.Where(c => c.Id == id).FirstOrDefault();
            return View(chatDetails);
        }

        //// GET: Chat/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Chat/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Chat/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Chat/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: Chat/Delete/5
        public ActionResult Delete(int id)
        {
            Chat chatToDelete = Data.Instance.ListeChats.Where(c => c.Id == id).FirstOrDefault();
            return View(chatToDelete);
        }

        // POST: Chat/Delete/5
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
