using FF.MinhaReserva.Infra.Data.UoW;

namespace FF.MinhaReserva.Application.Services
{
    public abstract class AppService
    {
        private readonly IUnitOfWork _uow;

        public AppService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public bool Commit()
        {
            return _uow.Commit() > 0;
        }
    }
}
