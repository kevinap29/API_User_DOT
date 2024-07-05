namespace Domain.Interfaces.Models
{
    public interface IBaseModel
    {
        int ID { get; set; }
        DateTime CreatedAt { get; set; }

        string CreatedBy { get; set; }

        DateTime? UpdatedAt { get; set; }

        string? UpdatedBy { get; set; }
    }
}
