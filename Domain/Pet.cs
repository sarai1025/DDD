using System;
using System.Collections.Generic;

namespace PetsFoundation.Domain;

public partial class Pet
{
    public Guid KPet { get; set; }

    public int IdentificationNumber { get; set; }

    public string FirtName { get; set; } = null!;

    public int PetType { get; set; }

    public string Race { get; set; } = null!;

    public int Age { get; set; }

    public DateTime EntryDate { get; set; }

    public Guid? KGodFather { get; set; }

    public Guid? KOwner { get; set; }

    public virtual ICollection<AdoptionRequest> AdoptionRequests { get; set; } = new List<AdoptionRequest>();

    public virtual Interested? KGodFatherNavigation { get; set; }

    public virtual Interested? KOwnerNavigation { get; set; }
}
