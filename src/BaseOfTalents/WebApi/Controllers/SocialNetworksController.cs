using Data.Infrastructure;
using Domain.DTO.DTOModels.SetupDTO;
using Domain.Entities.Setup;
using Domain.Repositories;

namespace WebApi.Controllers
{
    public class SocialNetworksController : BoTController<SocialNetwork, SocialNetworkDTO>
    {
        public SocialNetworksController(IDataRepositoryFactory repoFatory, IUnitOfWork unitOfWork)
            : base (repoFatory, unitOfWork)
        {

        }
    }
}