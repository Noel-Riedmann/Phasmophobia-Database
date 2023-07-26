using System.ComponentModel.DataAnnotations;

namespace PhasmophobiaDatabase.Models
{
    using System.ComponentModel.DataAnnotations;

    public class SanityThreshold
    {
        [Key]
        public int SanityThresholdId { get; set; }
        public string Name { get; set; }

        // Foreign key to Ghost
        public int GhostId { get; set; }
        public Ghost Ghost { get; set; }
    }

}
