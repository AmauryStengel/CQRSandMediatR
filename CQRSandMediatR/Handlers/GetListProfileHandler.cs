using CQRSandMediatR.Models;
using CQRSandMediatR.Queries;
using CQRSandMediatR.Repositories;
using MediatR;

namespace CQRSandMediatR.Handlers
{
    public class GetListProfileHandler : IRequestHandler<GetListProfileQuery, List<ProfileModel>>
    {
        private readonly IProfileRepository _profileRepository;

        public GetListProfileHandler(IProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;

        }

        public async Task<List<ProfileModel>> Handle(GetListProfileQuery query, CancellationToken cancellationToken)
        {
            return await _profileRepository.GetProfiles();
        }
    }
}
