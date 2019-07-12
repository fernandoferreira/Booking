using System.Web.Mvc;

namespace FF.MinhaReserva.UI.Web.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index()
        {
            ViewBag.AlertaErro = "Ocorreu um erro";
            ViewBag.AlertaErro = "Ocorreu um erro, tente novamente ou contate o suporte.";
            return View("Error");
        }

        public ActionResult NotFound()
        {
            ViewBag.AlertaErro = "Não encontrado";
            ViewBag.AlertaErro = "Não existe uma página para a URL informada";
            return View("Error");
        }

        public ActionResult AccessDenied()
        {
            ViewBag.AlertaErro = "Acesso negado";
            ViewBag.AlertaErro = "Você não tem permissão para executar isso!";
            return View("Error");
        }
    }
}