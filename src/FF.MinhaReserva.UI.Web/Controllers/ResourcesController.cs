using DomainValidation.Validation;
using FF.MinhaReserva.Application.Interfaces;
using FF.MinhaReserva.Application.ViewModels;
using FF.MinhaReserva.Infra.CrossCutting.AspNetFilters;
using System;
using System.Web.Mvc;

namespace FF.MinhaReserva.UI.Web.Controllers
{
    [Authorize]
    [RoutePrefix("Reservas/Recursos")]
    public class ResourcesController : Controller
    {
        private readonly IResourceAppService _resourceAppService;

        public ResourcesController(IResourceAppService resourceAppService)
        {
            _resourceAppService = resourceAppService;
        }

        [ClaimsAuthorize("ManagementResource", "SA")]
        [Route("Listrar-todos")]
        public ActionResult Index()
        {
            return View(_resourceAppService.GetAll());
        }

        [ClaimsAuthorize("ManagementResource", "DE")]
        // GET: Resources/Details/5
        [Route("{id:guid}/detalhes")]
        public ActionResult Details(Guid id)
        {
            var resource = _resourceAppService.GetById(id);

            if (resource == null)
            {
                return HttpNotFound();
            }
            return View(resource);
        }

        [ClaimsAuthorize("ManagementResource", "IN")]
        // GET: Resources/Create
        [Route("Criar-novo")]
        public ActionResult Create()
        {
            return View();
        }

        [ClaimsAuthorize("ManagementResource", "IN")]
        // POST: Resources/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("Criar-novo")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ResourceViewModel resourceViewModel)
        {
            if (!ModelState.IsValid)
                return View(resourceViewModel);

            resourceViewModel = _resourceAppService.Add(resourceViewModel);
            if (resourceViewModel.ValidationResult.IsValid)
                return RedirectToAction("Index");

            AddErrorIntoModelState(resourceViewModel.ValidationResult);

            return View(resourceViewModel);
        }

        [ClaimsAuthorize("ManagementResource", "ED")]
        // GET: Resources/Edit/5
        [Route("{id:guid}/editar")]
        public ActionResult Edit(Guid id)
        {
            var resource = _resourceAppService.GetById(id);
            if (resource == null)
            {
                return HttpNotFound();
            }
            return View(resource);
        }

        [ClaimsAuthorize("ManagementResource", "ED")]
        // POST: Resources/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("{id:guid}/editar")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ResourceViewModel resourceViewModel)
        {
            if (ModelState.IsValid)
            {
                resourceViewModel = _resourceAppService.Update(resourceViewModel);
                if (resourceViewModel.ValidationResult.IsValid)
                    return RedirectToAction("Index");
                AddErrorIntoModelState(resourceViewModel.ValidationResult);
            }
            return View(resourceViewModel);
        }

        [ClaimsAuthorize("ManagementResource", "EX")]
        // GET: Resources/Delete/5
        [Route("{id:guid}/excluir")]
        public ActionResult Delete(Guid id)
        {
            var resource = _resourceAppService.GetById(id);
            if (resource == null)
            {
                return HttpNotFound();
            }
            return View(resource);
        }


        [ClaimsAuthorize("ManagementResource", "EX")]
        // POST: Resources/Delete/5
        [Route("{id:guid}/excluir")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _resourceAppService.Delete(id);

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
                _resourceAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
