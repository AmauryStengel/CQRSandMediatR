using CQRSandMediatR.Commands;
using CQRSandMediatR.Repositories;
using MediatR;

namespace CQRSandMediatR.Handlers
{
    public class DeleteProfileHandler : IRequestHandler<DeleteProfileCommand, int>
    {
        private readonly IProfileRepository _profileRepository;

        public DeleteProfileHandler(IProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;
        }
        public async Task<int> Handle(DeleteProfileCommand command, CancellationToken cancellationToken)
        {
            var profileModel = await _profileRepository.GetProfileById(command.Id);
            if (profileModel == null)
            {
                return default;
            }

            return await _profileRepository.DeleteProfile(profileModel.Id);
        }
    }
}
