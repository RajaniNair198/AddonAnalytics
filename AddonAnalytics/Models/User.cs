namespace AddonAnalytics.Core.Models
{
    public class User
    {

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;


    }
}
