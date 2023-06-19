using System.ComponentModel.DataAnnotations;

namespace SaeedLearn.Domain.Common
{
    public abstract class BaseDomainEntity
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
