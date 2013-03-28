using System.Web.Mvc;
using System.Web.Routing;

using SwissKnife.Web.Models;

namespace SwissKnife.Web.Controllers
{
    public class FormsController : Controller
    {
        public ActionResult Index()
        {
            var model = new FormModel
            {
                PrefectureId = 13,
                ColorId = 2,
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(FormModel model)
        {
            return View(model);
        }

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);

            ViewBag.PrefectureId = Master.PrefectureList;
            ViewBag.ColorId = Master.ColorList;
        }
    }
}
