using System;
using System.Collections.Generic;

namespace PetsFoundation.Domain;

public partial class AdoptionRequest
{
    public Guid KAdoptionRequest { get; set; }

    public Guid KPet { get; set; }

    public Guid KInterested { get; set; }

    public bool Approved { get; set; }

    public virtual Interested KInterestedNavigation { get; set; } = null!;

    public virtual Pet KPetNavigation { get; set; } = null!;
}
