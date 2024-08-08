using LynxPro.Models.Interfaces;

namespace LynxPro.Models.Infrastructure
{
    public class LynxRepository : ILynxRepository
    {
        private readonly LynxContext _context;

        public LynxRepository(LynxContext context)
        {
            _context = context;
        }

        public void Add(Device entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Device entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Device>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Device> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Device entity)
        {
            throw new NotImplementedException();
        }
    }
}