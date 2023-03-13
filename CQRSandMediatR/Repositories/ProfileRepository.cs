using CQRSandMediatR.Data;
using CQRSandMediatR.Models;
using Microsoft.EntityFrameworkCore;

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

        public async Task<ProfileModel> GetProfileById(int id)
        {
            //return mostra perfil na tela; await porque é async; _profileData está acessando o banco de dados;
            //Profiles é a tabela; Where faz o query sobre o database;
            //x acessa os valores do database, como "André, João ou Maria..."
            //x.Id porque eu quero  um Id específico baseado no parâmentro id no método.
            return await _profileData.Profiles.Where(x => x.Id == id).FirstOrDefaultAsync(); 
            
        }

        public async Task<List<ProfileModel>> GetProfiles()
        {
            return await _profileData.Profiles.ToListAsync();
        }

        public async Task<ProfileModel> UpdateProfile(ProfileModel profile)
        {
            var result = _profileData.Profiles.Update(profile);
            await _profileData.SaveChangesAsync();
            return result.Entity;
        }
    }
}
