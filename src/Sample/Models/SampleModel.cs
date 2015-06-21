using Sample.Core.Contracts;
using System.ComponentModel.DataAnnotations;

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