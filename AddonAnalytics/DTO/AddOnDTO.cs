using AddonAnalytics.Core.Models;

namespace AddonAnalytics.Core.DTO
{
    public class AddOnDTO
    {

        public Guid Id { get; set; }

        public string Name { get; set; } = "";
        public string ArchiCadVersion { get; set; } = "";

        public string AddOnVersion { get; set; } = "";

        public string Localization { get; set; } = "";

        public User AddOnUser { get; set; } = new User();
    }
}
