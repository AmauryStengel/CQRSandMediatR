using CQRSandMediatR.Data;
using CQRSandMediatR.Models;

namespace CQRSandMediatR.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly DbProfileData _profileData;

        public ProfileRepository(DbProfileData dbProfileData)
        {
            _profileData = dbProfileData;
        }
        public async Task<ProfileModel> AddProfile(ProfileModel profile)
        {
            var result = _profileData.Profiles.Add(profile);
            await _profileData.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<int> DeleteProfile(int id)
        {
            var result = _profileData.Profiles.Where(x => x.Id == id).FirstOrDefault();
            _profileData.Profiles.Remove(result);
            return await _profileData.SaveChangesAsync();
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
