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
            if (chatDetails != null)
            {
                return View(chatDetails);
            }
            return RedirectToAction("Index");
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

        // GET: Chat/Edit/5
        public ActionResult Edit(int id)
        {
            Chat chatToEdit = Data.Instance.ListeChats.Where(c => c.Id == id).FirstOrDefault();
            if(chatToEdit != null)
            {
                return View(chatToEdit);
            }
            return RedirectToAction("Index");
        }

        // POST: Chat/Edit/5
        [HttpPost]
        public ActionResult Edit(Chat chat)
        {
            try
            {
                Chat chatDb = Data.Instance.ListeChats.FirstOrDefault(c => c.Id == chat.Id);
                chatDb.Age = chat.Age;
                chatDb.Couleur = chat.Couleur;
                chatDb.Nom = chat.Nom;

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Chat/Delete/5
        public ActionResult Delete(int id)
        {
            Chat chatToDelete = Data.Instance.ListeChats.Where(c => c.Id == id).FirstOrDefault();
            if (chatToDelete != null)
            {
                return View(chatToDelete);
            }
            return RedirectToAction("Index");
        }

        // POST: Chat/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                try
                {
                    Chat chat = Data.Instance.ListeChats.FirstOrDefault(x => x.Id == id);
                    Data.Instance.ListeChats.Remove(chat);

                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
