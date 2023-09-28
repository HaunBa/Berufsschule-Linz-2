using System;
using System.Collections.Generic;

namespace Artikel_Hersteller.Models;

public partial class Hersteller
{
    public int HerId { get; set; }

    public string HerName { get; set; } = null!;

    public virtual ICollection<Artikel> Arts { get; set; } = new List<Artikel>();
}
