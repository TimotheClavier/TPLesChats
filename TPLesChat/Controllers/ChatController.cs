using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TPLesChat.Models;

namespace TPLesChat.Controllers
{
    public class ChatController : Controller
    {
        public List<Chat> listeChats = Chat.GetMeuteDeChats();

        // GET: Chat
        public ActionResult Index()
        {
           
            return View(listeChats);
        }

        // GET: Chat/Details/5
        public ActionResult Details(int id)
        {

            var chat = listeChats.FirstOrDefault(c => c.Id == id);
            return View(chat);
        }

        // GET: Chat/Delete/5
        public ActionResult Delete(int id)
        {
            var chat = listeChats.FirstOrDefault(c => c.Id == id);



            return View(chat);
        }

        // POST: Chat/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var chat = listeChats.FirstOrDefault(c => c.Id == id);
                if (chat != null)
                {
                    listeChats.Remove(chat);
                }
            }
            catch
            {
                return View();
            }
            return RedirectToAction("Index");
        }
    }
}
