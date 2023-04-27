using System;
using System.Collections.Generic;

namespace ThreeLayerArchitecture.DAL;

public partial class Gender
{
    public int Id { get; set; }

    public string? Text { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
