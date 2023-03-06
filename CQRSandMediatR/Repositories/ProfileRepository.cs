using CQRSandMediatR.Models;

namespace CQRSandMediatR.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        public Task<ProfileModel> AddProfile(ProfileModel profile)
        {
            throw new NotImplementedException();
        }

        public Task<ProfileModel> DeleteProfile(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ProfileModel> GetProfileById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProfileModel>> GetProfiles()
        {
            throw new NotImplementedException();
        }

        public Task<ProfileModel> UpdateProfile(ProfileModel profile)
        {
            throw new NotImplementedException();
        }
    }
}
