using System;
using System.Collections.Generic;

namespace CricketTeamDetailsMVC.Models;

public partial class PlayerDetail
{
    public int Id { get; set; }
    public string PlayerHeight { get; set; } = null!;
    public string PlayerSalary { get; set; } = null!;
    public string? PlayerLocality { get; set; }
    public string? PlayerId { get; set; }
    public virtual Player? Player { get; set; }
}
