using AddonAnalyticsAPI.Core.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AddonAnalytics.Core.Models
{
    public class AddOn
    {
        public AddOn()
        {

        }
        public AddOn(string name, ArchicadVersionEnum ACversionNum, 
                string addOnVersion, string localization)
        {
            Name = name;
            ArchicadVersion = ACversionNum;
            AddOnVersion = addOnVersion;
            Localization = localization;

        }
        public AddOn BuildFromUserDetails(User user, Guid addOnId) => new AddOn
        {
            Id = addOnId,
            AddOnUserId = user.Id
        };

        [Key]
        public Guid Id { get; set; }

        
        [Column(TypeName = "nvarchar(250)")]
        public string Name { get; set; } = string.Empty;
        public ArchicadVersionEnum ArchicadVersion { get; set; }

        public string AddOnVersion { get; set; } = string.Empty;

        public string Localization { get; set; } = string.Empty;

        public int AddOnUserId { get; set; }

        //[ForeignKey("AddOnUserId")]
        //public User AddOnUser { get; set; }

        //[ForeignKey("AddOnId")]
        //public AddOnMaster AddOnMaster { get; set; }


    }
}
