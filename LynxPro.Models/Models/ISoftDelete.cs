namespace LynxPro.Models
{
    public interface ISoftDelete
    {
        bool IsDeleted { get; set; }
    }
}