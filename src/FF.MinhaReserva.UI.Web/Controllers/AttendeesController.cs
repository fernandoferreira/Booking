using System;
using System.Web.Mvc;
using DomainValidation.Validation;
using FF.MinhaReserva.Application.Services;
using FF.MinhaReserva.Application.ViewModels;
using FF.MinhaReserva.Infra.CrossCutting.AspNetFilters;

namespace FF.MinhaReserva.UI.Web.Controllers
{
    [Authorize]
    [RoutePrefix("Reservas/Participantes")]
    public class AttendeesController : Controller
    {
        private readonly IAttendeeAppService _atendeeAppService;

        public AttendeesController(IAttendeeAppService atendeeService)
        {
            _atendeeAppService = atendeeService;
        }

        [ClaimsAuthorize("ManagementAtendee", "SA")]
        [Route("Listar-todos")]
        public ActionResult Index()
        {
            return View(_atendeeAppService.GetAllActive());
        }

        [ClaimsAuthorize("ManagementAtendee", "DE")]
        [Route("{id:guid}/detalhes")]
        public ActionResult Details(Guid id)
        {
            var atendee = _atendeeAppService.GetById(id);
            if (atendee == null)
                return HttpNotFound();
            else
                return View(atendee);
        }

        [ClaimsAuthorize("ManagementAtendee", "IN")]
        [Route("Criar-novo")]
        public ActionResult Create()
        {
            return View();
        }

        [ClaimsAuthorize("ManagementAtendee", "IN")]
        [Route("Criar-novo")]
        [HttpPost]
        public ActionResult Create(AttendeeViewModel atendeeViewModel)
        {
            if (!ModelState.IsValid)
                return View(atendeeViewModel);

            atendeeViewModel = _atendeeAppService.Add(atendeeViewModel);
            if (atendeeViewModel.ValidationResult.IsValid)
                return RedirectToAction("Index");

            AddErrorIntoModelState(atendeeViewModel.ValidationResult);

            return View(atendeeViewModel);
        }

        [ClaimsAuthorize("ManagementAtendee", "ED")]
        // GET: Atendee/Edit/5
        [Route("{id:guid}/editar")]
        public ActionResult Edit(Guid id)
        {
            var atendee = _atendeeAppService.GetById(id);
            if (atendee == null)
                return HttpNotFound();
            else
                return View(atendee);

        }

        [ClaimsAuthorize("ManagementAtendee", "ED")]
        // POST: Atendee/Edit/5
        [Route("{id:guid}/editar")]
        [HttpPost]
        public ActionResult Edit(AttendeeViewModel atendeeViewModel)
        {
            if (ModelState.IsValid)
            {
                atendeeViewModel = _atendeeAppService.Update(atendeeViewModel);
                if (atendeeViewModel.ValidationResult.IsValid)
                    return RedirectToAction("Index");

                AddErrorIntoModelState(atendeeViewModel.ValidationResult);
            }
            return View(atendeeViewModel);
        }

        [ClaimsAuthorize("ManagementAtendee", "EX")]
        // GET: Atendee/Delete/5
        [Route("{id:guid}/excluir")]
        public ActionResult Delete(Guid id)
        {
            var atendee = _atendeeAppService.GetById(id);
            if (atendee == null)
                return HttpNotFound();
            else
                return View(atendee);

        }

        [ClaimsAuthorize("ManagementAtendee", "EX")]
        // POST: Atendee/Delete/5
        [Route("{id:guid}/excluir")]
        [HttpPost]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _atendeeAppService.Delete(id);
            return RedirectToAction("Index");
        }

        private void AddErrorIntoModelState(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Erros)
            {
                ModelState.AddModelError(string.Empty, error.Message);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _atendeeAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
