using System.ComponentModel.DataAnnotations;

namespace DIMS_Core.Models
{
    public class DirectionViewModel
    {
        public int DirectionId { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 3)]
        public string Name { get; set; }

        [StringLength(255, MinimumLength = 3)]
        public string Description { get; set; }
    }
}