using FF.MinhaReserva.Infra.Data.Context;

namespace FF.MinhaReserva.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MinhaReservaContext _context;

        public UnitOfWork(MinhaReservaContext context)
        {
            _context = context;
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }
    }
}
