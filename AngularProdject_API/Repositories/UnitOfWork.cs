using API.Models;
using API.Repositories.Interfaces;

namespace API.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        ProductDbContext db;
        public UnitOfWork(ProductDbContext db)
        {
            this.db = db;
        }
        public async Task CompleteAsync()
        {
            await db.SaveChangesAsync();
        }

        public void Dispose()
        {
            this.db.Dispose();
        }

        public IGenericRepo<T> GetRepo<T>() where T : class, new()
        {
            return new GenericRepo<T>(this.db);
        }
    }
}
