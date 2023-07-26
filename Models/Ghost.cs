using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace PhasmophobiaDatabase.Models
{
    public class Ghost
    {
        [Key]
        public int GhostId { get; set; }
        public string Name { get; set; }
        public string JournalInfo { get; set; }
        public string Strengths { get; set; }
        public string Weaknesses { get; set; }
        public string Behaviour { get; set; }
        public string Test { get; set; }

        // Navigation properties
        public ICollection<Evidence> Evidence { get; set; }
        public ICollection<Speed> Speed { get; set; }
        public ICollection<SanityThreshold> SanityThreshold { get; set; }
    }

}
