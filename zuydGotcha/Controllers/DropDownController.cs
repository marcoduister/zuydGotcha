using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace zuydGotcha.Controllers
{
    public class DropDownController : Controller
    {
        [ChildActionOnly]
        public ActionResult RenderMenu()
        {
            return PartialView("_AddBox");
        }
    }
}