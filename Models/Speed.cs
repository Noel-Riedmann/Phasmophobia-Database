using System.ComponentModel.DataAnnotations;

namespace PhasmophobiaDatabase.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Speed
    {
        [Key]
        public int SpeedId { get; set; }
        public string Name { get; set; }

        // Foreign key to Ghost
        public int GhostId { get; set; }
        public Ghost Ghost { get; set; }
    }


}
