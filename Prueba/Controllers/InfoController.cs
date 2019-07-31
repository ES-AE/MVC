using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prueba.Controllers
{
    public class InfoController : Controller
    {
        // GET: Info
        public ActionResult Carrera()
        {
            return View();
        }
    }
}