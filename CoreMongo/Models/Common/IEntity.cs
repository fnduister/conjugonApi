using System.ComponentModel.DataAnnotations;

namespace ConjugonApi.Models.Common
{
    public record IEntity
    {
        [Required]
        public Guid Id { get; set; }
    }
}
