namespace LynxPro.Models.Interfaces
{
    public interface ILynxRepository
    {
        Task<IEnumerable<Device>> GetAllAsync();

        Task<Device> GetByIdAsync(int id);

        void Add(Device entity);

        void Update(Device entity);

        void Delete(Device entity);
    }
}