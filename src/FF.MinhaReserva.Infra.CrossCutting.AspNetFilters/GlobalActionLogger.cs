using System.Web.Mvc;

namespace FF.MinhaReserva.Infra.CrossCutting.AspNetFilters
{
    public class GlobalActionLogger : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //You can put a audit log here.

            if (filterContext.Exception != null)
            {
                //things to be done
                //To manipulate the exception
                //Inject some error lib
                //To save  the log on database
                //Send an e-mail to admin
                //Return a known error code

                //Important ALWAUS use Async here

                filterContext.Result = new HttpStatusCodeResult(500);

            }

            base.OnActionExecuted(filterContext);
        }
    }
}
