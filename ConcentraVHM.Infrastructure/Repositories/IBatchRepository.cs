namespace ConcentraVHM.Infrastructure.Repositories
{
    public interface IBatchRepository<T>
    {
        Task CreateBatch(T [] entity);
    }
}