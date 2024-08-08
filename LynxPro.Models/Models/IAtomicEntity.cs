namespace LynxPro.Models
{
    public interface IAtomicEntity
    {
        byte[] RowVersion { get; set; }
    }
}