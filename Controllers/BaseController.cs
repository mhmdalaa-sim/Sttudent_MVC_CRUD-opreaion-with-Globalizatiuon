using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Globalization;
using Microsoft.AspNetCore.Mvc.Filters;

namespace StudentTask.Controllers
{
    public class BaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
          if(HttpContext.Session.GetString("Lang")!=null)
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(HttpContext.Session.GetString("Lang"));
            }
        }
    }
}
