using CQRSandMediatR.Models;

namespace CQRSandMediatR.Repositories
{
    public interface IProfileRepository
    {
        public Task<List<ProfileModel>> GetProfiles();
        public Task<ProfileModel> GetProfileById(int id);
        public Task<ProfileModel> AddProfile(ProfileModel profile);
        public Task<ProfileModel> UpdateProfile(ProfileModel profile);
        public Task<int> DeleteProfile(int id);
    }
}
