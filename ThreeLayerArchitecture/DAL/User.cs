using System;
using System.Collections.Generic;

namespace ThreeLayerArchitecture.DAL;

public partial class User
{
    public int Id { get; set; }

    public string? Email { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public int? GenderId { get; set; }

    public string? MobileNumber { get; set; }

    public string? Password { get; set; }

    public string? AadharNumber { get; set; }

    public string? Category { get; set; }

    public bool? TermsConditions { get; set; }

    public virtual Gender? Gender { get; set; }
}
