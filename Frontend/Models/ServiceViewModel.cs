namespace Frontend.Models
{
    public class ServiceViewModel
    {
        public int Id { get; set; }
        public required string ImageUrl { get; set; }
        public required string Heading { get; set; }
        public required string Subheading { get; set; }
        public required string Duration { get; set; }
        public required string Trainer { get; set; }
        public required string Intensity { get; set; }
    }
}
