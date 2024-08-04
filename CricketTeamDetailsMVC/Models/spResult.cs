using System.ComponentModel.DataAnnotations;

namespace CricketTeamDetailsMVC.Models;

//[Keyless]
public partial class SpResult
{
    [Key]
    public string PlayerId { get; set; } = string.Empty;
    public string PlayerName { get; set; } = null!;
    public string PlayerRole { get; set; } = null!;
    public string PlayerHeight { get; set; } = null!;
    public string PlayerSalary { get; set; } = null!;
    public string PlayerLocality { get; set; } = null!;
}
