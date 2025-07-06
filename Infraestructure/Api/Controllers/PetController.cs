using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using PetsFoundation.Application.Interfaces;
using PetsFoundation.Application.Services.Pets;
using PetsFoundation.Domain;
using PetsFoundation.Domain.Request;
using System.Net;

namespace PetsFoundation.Infraestructure.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PetController : ControllerBase
    {
        #region Attributes
        private readonly ICreatePet createPet;
        private readonly IGetPet getPet;
        #endregion

        #region Constructor
        public PetController(ICreatePet createPet, IGetPet getPet)
        {
            this.createPet = createPet;
            this.getPet = getPet;
        }
        #endregion

        #region Methods
        [HttpPost]
        public ActionResult CreatePet(PetCreation petCreation)
        {
            //try
            //{
               return Ok(createPet.Execute(petCreation));
            //}
            //catch (ArgumentException ex)
            //{
            //    BadRequest(new object(ex)
            //    {
            //        errors = ex.Message
            //    });
            //}
            //catch (Exception ex)
            //{
            //    StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            //}

        }

        [HttpGet]
        public IEnumerable<Pet> GetAllPets()
        {
            return getPet.Execute();
        }
        #endregion
    }
}
