using System;
using System.Web.Mvc;
using DomainValidation.Validation;
using FF.MinhaReserva.Application.Services;
using FF.MinhaReserva.Application.ViewModels;
using FF.MinhaReserva.Infra.CrossCutting.AspNetFilters;

namespace FF.MinhaReserva.UI.Web.Controllers
{
    //Claims => Declarações
    //Claims such as Roles are stored in cookies, so for reasons of saving space let's use short name for them.
    //ManagementRoom = SA,DE,ED,EX,IN

    [Authorize]
    [RoutePrefix("Reservas/Salas")]
    public class RoomsController : Controller
    {
        private readonly IRoomAppService _roomAppService;

        public RoomsController(IRoomAppService roomAppService)
        {
            _roomAppService = roomAppService;
        }

        [ClaimsAuthorize("ManagementRoom","SA")]
        [Route("Listar-todas")]
        public ActionResult Index()
        {
            return View(_roomAppService.GetAll());
        }

        [ClaimsAuthorize("ManagementRoom", "DE")]
        // GET: Rooms/Details/5
        [Route("{id:guid}/detalhes")]
        public ActionResult Details(Guid id)
        {
            var room = _roomAppService.GetById(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View(room);
        }

        [ClaimsAuthorize("ManagementRoom", "IN")]
        // GET: Rooms/Create
        [Route("Criar-nova")]
        public ActionResult Create()
        {
            return View();
        }

        [ClaimsAuthorize("ManagementRoom", "IN")]
        // POST: Rooms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("Criar-nova")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RoomViewModel roomViewModel)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index");

            roomViewModel= _roomAppService.Add(roomViewModel);
            if (roomViewModel.ValidationResult.IsValid)
                return RedirectToAction("Index");

            AddErrorIntoModelState(roomViewModel.ValidationResult);
            return View(roomViewModel);
        }

        [ClaimsAuthorize("ManagementRoom", "ED")]
        // GET: Rooms/Edit/5
        [Route("{id:guid}/editar")]
        public ActionResult Edit(Guid id)
        {
            var room = _roomAppService.GetById(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View(room);
        }

        [ClaimsAuthorize("ManagementRoom", "ED")]
        // POST: Rooms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("{id:guid}/editar")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RoomViewModel roomViewModel)
        {
            if (ModelState.IsValid)
            {
               var roomRet = _roomAppService.Update(roomViewModel);
                if (roomRet.ValidationResult.IsValid)
                    return RedirectToAction("Index");

                AddErrorIntoModelState(roomRet.ValidationResult);
            }
            return View(roomViewModel);
        }

        [ClaimsAuthorize("ManagementRoom", "EX")]
        // GET: Rooms/Delete/5
        [Route("{id:guid}/excluir")]
        public ActionResult Delete(Guid id)
        {
            var room = _roomAppService.GetById(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View(room);
        }

        [ClaimsAuthorize("ManagementRoom", "EX")]
        // POST: Rooms/Delete/5
        [Route("{id:guid}/excluir")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _roomAppService.Delete(id);
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
                _roomAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
