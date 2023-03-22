using CQRSandMediatR.Commands;
using CQRSandMediatR.Models;
using CQRSandMediatR.Repositories;
using MediatR;

namespace CQRSandMediatR.Handlers
{
    public class CreateProfileHandler : IRequestHandler<CreateProfileCommand, ProfileModel>
    {
        private readonly IProfileRepository _profileRepository;

        public CreateProfileHandler(IProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;
        }

        public async Task<ProfileModel> Handle(CreateProfileCommand command, CancellationToken cancellationToken)
        {
            var profileModel = new ProfileModel()
            {
                Address = command.Address,
                BirthDate = command.BirthDate,
                CellPhone = command.CellPhone,
                CivilStatus = command.CivilStatus,
                CPF = command.CPF,
                Email = command.Email,
                FirstName = command.FirstName,
                LastName = command.LastName,
                IsActive = command.IsActive
            };

            return await _profileRepository.AddProfile(profileModel);
        }
    }
}
