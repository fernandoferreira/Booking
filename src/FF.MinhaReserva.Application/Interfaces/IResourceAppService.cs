using System;
using System.Collections.Generic;
using FF.MinhaReserva.Application.ViewModels;

namespace FF.MinhaReserva.Application.Interfaces
{
    public interface IResourceAppService : IDisposable
    {
        IEnumerable<ResourceViewModel> GetAll();

        ResourceViewModel GetById(Guid Id);

        ResourceViewModel GetByDescription(string name);

        ResourceViewModel Add(ResourceViewModel resourceViewModel);

        ResourceViewModel Update(ResourceViewModel resourceViewModel);

        void Delete(Guid id);

    }
}
