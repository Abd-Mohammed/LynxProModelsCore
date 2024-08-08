using LynxPro.Models.Interfaces;

namespace LynxPro.Models.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LynxContext _context;

        private ILynxRepository _lynxRepository;

        public UnitOfWork(LynxContext context)
        {
            _context = context;
        }

        public ILynxRepository LynxRepository
        {
            get
            {
                if (_lynxRepository == null)
                {
                    _lynxRepository = new LynxRepository(_context);
                }

                return _lynxRepository;
            }
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}