using CQRSandMediatR.Models;
using CQRSandMediatR.Queries;
using CQRSandMediatR.Repositories;
using MediatR;

namespace CQRSandMediatR.Handlers
{
    public class GetByIdProfileHandler : IRequestHandler<GetByIdProfileQuery, ProfileModel>
    {
        private readonly IProfileRepository _profileRepository;

        public GetByIdProfileHandler(IProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;

        }

        public async Task<ProfileModel> Handle(GetByIdProfileQuery query, CancellationToken cancellationToken)
        {
            return await _profileRepository.GetProfileById(query.Id);
        }
    }
}
