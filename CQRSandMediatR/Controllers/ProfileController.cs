using CQRSandMediatR.Commands;
using CQRSandMediatR.Models;
using CQRSandMediatR.Queries;
using MediatR;
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
        public async Task<List<ProfileModel>> GetProfileModelsAsync()
        {
            var profileModels = await _mediator.Send(new GetListProfileQuery());
            return profileModels;
        }

        [HttpGet("profileId")]
        public async Task<ProfileModel> GetProfileByIdAsync(int profileId)
        {
            var profileModel = await _mediator.Send(new GetByIdProfileQuery() { Id = profileId});
            return profileModel;
        }

        [HttpPost]
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
        public async Task<int> DeleteProfileModelAsync(int id)
        {
            return await _mediator.Send(new DeleteProfileCommand() { Id = id });
        }
    }
}
