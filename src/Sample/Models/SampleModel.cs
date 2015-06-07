using System.ComponentModel.DataAnnotations;
using Sample.Core.Contracts;

namespace Sample.Models
{
    public class SampleModel : IEntity<int>
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [MinLength(6)]
        public string Name { get; set; }
    }
}