using System;
using System.Collections.Generic;

namespace Artikel_Hersteller.Models;

public partial class Artikel
{
    public int ArtId { get; set; }

    public string ArtName { get; set; } = null!;

    public virtual ICollection<Hersteller> Hers { get; set; } = new List<Hersteller>();
}
