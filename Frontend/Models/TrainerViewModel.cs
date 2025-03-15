namespace Frontend.Models
{
    public class TrainerViewModel
    {
        public required string Image { get; set; }
        public required string Title { get; set; }
        public required string Caption { get; set; }
        public required List<string> Specialties { get; set; }
        public required string Experience { get; set; }
        public double Rating { get; set; }
        public required Dictionary<string, string> SocialLinks { get; set; }
        public required string Description { get; set; }
    }
}
