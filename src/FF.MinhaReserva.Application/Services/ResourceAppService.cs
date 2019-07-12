using System;
using System.Collections.Generic;
using AutoMapper;
using FF.MinhaReserva.Application.Interfaces;
using FF.MinhaReserva.Application.ViewModels;
using FF.MinhaReserva.Domain.Interfaces;
using FF.MinhaReserva.Domain.Models;
using FF.MinhaReserva.Infra.Data.UoW;

namespace FF.MinhaReserva.Application.Services
{
    public class ResourceAppService : AppService, IResourceAppService
    {
        protected readonly IResourceRepository _resourceRepository;
        protected readonly IResourceService _resourceService;

        public ResourceAppService(IResourceRepository resourceRepository, IResourceService resourceService, IUnitOfWork uow) : base(uow)
        {
            _resourceRepository = resourceRepository;
            _resourceService = resourceService;
        }

        public ResourceViewModel GetById(Guid Id)
        {
            return Mapper.Map<ResourceViewModel>(_resourceRepository.GetById(Id));
        }

        public IEnumerable<ResourceViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<ResourceViewModel>>(_resourceRepository.GetAll());
        }

        public ResourceViewModel GetByDescription(string description)
        {
            return Mapper.Map<ResourceViewModel>(_resourceRepository.GetByDescripion(description));
        }

        public ResourceViewModel Add(ResourceViewModel resourceViewModel)
        {
            var resource = Mapper.Map<Resource>(resourceViewModel);
            resource.Activate();

            //Must be improved
            var resourceRet = _resourceService.Add(resource);
            if (resourceRet.validationResult.IsValid)
            {
                if (!Commit())
                {
                    //Place to treat or get erros
                }
            }
            resourceViewModel = Mapper.Map<ResourceViewModel>(resourceRet);
            return resourceViewModel;
        }

        public void Delete(Guid id)
        {
            _resourceRepository.Remove(id);
        }

        public ResourceViewModel Update(ResourceViewModel resourceViewModel)
        {
            var resource = Mapper.Map<Resource>(resourceViewModel);

            //Must be improved
            if (resource.IsValid())
                _resourceRepository.Update(resource);
            resourceViewModel = Mapper.Map<ResourceViewModel>(resource);
            return resourceViewModel;
        }

        public void Dispose()
        {
            _resourceRepository.Dispose();
            _resourceService.Dispose();
        }

    }
}
