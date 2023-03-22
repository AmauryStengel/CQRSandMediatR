using CQRSandMediatR.Commands;
using CQRSandMediatR.Models;
using CQRSandMediatR.Repositories;
using MediatR;

namespace CQRSandMediatR.Handlers
{
    public class UpdateProfileHandler : IRequestHandler<UpdateProfileCommand, int>
    {
        private readonly IProfileRepository _profileRepository;

        public UpdateProfileHandler(IProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;
        }

        public async Task<int> Handle(UpdateProfileCommand command, CancellationToken cancellationToken)
        {
            var profileModel = await _profileRepository.GetProfileById(command.Id);
            if (profileModel == null)
            {
                return default;
            }

            profileModel.Address = command.Address;
            profileModel.FirstName = command.FirstName;
            profileModel.LastName = command.LastName;
            profileModel.BirthDate = command.BirthDate;
            profileModel.CellPhone = command.CellPhone;
            profileModel.CivilStatus = command.CivilStatus;
            profileModel.CPF = command.CPF;
            profileModel.Email = command.Email;
            profileModel.IsActive = command.IsActive;

            return await _profileRepository.UpdateProfile(profileModel);
        }
    }
}
