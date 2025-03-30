using Domain.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Advice : IAggregateRoot
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ExternalId { get; set; }
        public required string AdviceText { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
