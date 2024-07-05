using Domain.Interfaces.Models;

namespace Domain.Models
{
    public class BaseModel : IBaseModel
    {
        public int ID { get ; set ; }
        public DateTime CreatedAt { get ; set ; }
        public string CreatedBy { get ; set ; }
        public DateTime? UpdatedAt { get ; set ; }
        public string? UpdatedBy { get ; set ; }
    }
}
