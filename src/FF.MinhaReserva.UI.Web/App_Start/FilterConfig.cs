using System.Web;
using System.Web.Mvc;
using FF.MinhaReserva.Infra.CrossCutting.AspNetFilters;

namespace FF.MinhaReserva.UI.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new GlobalActionLogger());
        }
    }
}
