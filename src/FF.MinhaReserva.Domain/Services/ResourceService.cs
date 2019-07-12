using System;
using FF.MinhaReserva.Domain.Interfaces;
using FF.MinhaReserva.Domain.Models;

namespace FF.MinhaReserva.Domain.Services
{
    public class ResourceService : IResourceService
    {
        private readonly IResourceRepository _resourceRepository;

        public ResourceService(IResourceRepository resourceRepository)
        {
            _resourceRepository = resourceRepository;
        }

        public Resource Add(Resource resource)
        {
            if (!resource.IsValid())
                return resource;

            return _resourceRepository.Add(resource);
        }

        public void Delete(Guid id)
        {
            _resourceRepository.Remove(id);
        }

        public Resource Update(Resource resource)
        {
            if (!resource.IsValid())
                return resource;

            return _resourceRepository.Update(resource);
        }

        public void Dispose()
        {
            _resourceRepository.Dispose();
        }
    }
}
