using System.ComponentModel.DataAnnotations;

namespace WereldbouwerAPI
{
    public class WereldBouwer
    {
        public string id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string ownerUserId { get; set; }
        [Required]
        public int maxLength { get; set; }
        [Required]
        public int maxHeight { get; set; }

        // Constructor to initialize the 'name' field
        public WereldBouwer() { }
        public WereldBouwer(string name)
        {
            this.name = name;
        }
    }
}
