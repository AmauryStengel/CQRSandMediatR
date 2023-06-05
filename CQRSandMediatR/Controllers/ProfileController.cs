using CQRSandMediatR.Commands;
using CQRSandMediatR.Models;
using CQRSandMediatR.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CQRSandMediatR.Controllers
{
    [Route("api/profile")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProfileController(IMediator mediator)
        {
            _mediator = mediator;

        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<List<ProfileModel>> GetProfileModelsAsync()
        {
            var profileModels = await _mediator.Send(new GetListProfileQuery());
            return profileModels;
        }

        [HttpGet("profileId")]
        [Authorize]
        public async Task<ProfileModel> GetProfileByIdAsync(int profileId)
        {
            var profileModel = await _mediator.Send(new GetByIdProfileQuery() { Id = profileId});
            return profileModel;
        }

        [HttpPost]
        [Authorize(Roles = UserRules.User)] // Model UserRules deveria ser UserRoles
        public async Task<ProfileModel> AddProfileModelAsync(ProfileModel profileModel)
        {
            var resultProfileModel = await _mediator.Send(new CreateProfileCommand(
                profileModel.FirstName,
                profileModel.LastName,
                profileModel.CPF,
                profileModel.BirthDate,
                profileModel.Email,
                profileModel.IsActive,
                profileModel.Address,
                profileModel.CellPhone,
                profileModel.CivilStatus
                ));
            return resultProfileModel;
        }

        [HttpPut]
        [Authorize(Roles = UserRules.Admin)]
        public async Task<int> UpdateProfileModelAsync(ProfileModel profileModel)
        {
            var id = await _mediator.Send(new UpdateProfileCommand(
                profileModel.Id,
                profileModel.FirstName,
                profileModel.LastName,
                profileModel.CPF,
                profileModel.BirthDate,
                profileModel.Email,
                profileModel.IsActive,
                profileModel.Address,
                profileModel.CellPhone,
                profileModel.CivilStatus
                ));
            return id;
        }

        [HttpDelete]
        [Authorize(Roles = UserRules.Admin)]
        public async Task<int> DeleteProfileModelAsync(int id)
        {
            return await _mediator.Send(new DeleteProfileCommand() { Id = id });
        }
    }
}
