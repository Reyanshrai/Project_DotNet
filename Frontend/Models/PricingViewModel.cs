namespace Frontend.Models // Change 'YourProjectNamespace' to 'Frontend'
{
    public class PricingViewModel
    {
        public required string PlanName { get; set; }
        public required string Price { get; set; }
        public required string Duration { get; set; }
        public required List<string> Features { get; set; }
        public required string ImageUrl { get; set; }
    }
}
