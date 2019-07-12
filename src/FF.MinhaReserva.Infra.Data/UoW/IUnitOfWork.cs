namespace FF.MinhaReserva.Infra.Data.UoW
{
    public interface IUnitOfWork
    {
        int Commit();
    }
}
