using System;
using System.Collections.Generic;

namespace PetsFoundation.Domain;

public partial class Interested
{
    public Guid KInterested { get; set; }

    public string FirstName { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public string IdentificationNumber { get; set; } = null!;

    public int IdentificationType { get; set; }

    public int Phone { get; set; }

    public string Email { get; set; } = null!;

    public DateTime StartDate { get; set; }

    public virtual ICollection<AdoptionRequest> AdoptionRequests { get; set; } = new List<AdoptionRequest>();

    public virtual ICollection<Pet> PetKGodFatherNavigations { get; set; } = new List<Pet>();

    public virtual ICollection<Pet> PetKOwnerNavigations { get; set; } = new List<Pet>();
}
