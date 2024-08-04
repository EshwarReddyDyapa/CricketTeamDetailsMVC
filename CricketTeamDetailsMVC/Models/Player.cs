using System;
using System.Collections.Generic;

namespace CricketTeamDetailsMVC.Models;

public partial class Player
{
    public string PlayerId { get; set; } = null!;

    public string PlayerName { get; set; } = null!;

    public string PlayerRole { get; set; } = null!;

    public virtual ICollection<PlayerDetail> PlayerDetails { get; set; } = new List<PlayerDetail>();
}
