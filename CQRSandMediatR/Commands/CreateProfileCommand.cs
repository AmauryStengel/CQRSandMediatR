using CQRSandMediatR.Models;
using MediatR;

namespace CQRSandMediatR.Commands
{
    public class CreateProfileCommand : IRequest<ProfileModel>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CPF { get; set; }
        public string BirthDate { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public string Address { get; set; }
        public string CellPhone { get; set; }
        public string CivilStatus { get; set; }

        public CreateProfileCommand(string firstName, string lastName, string cpf, string birthDate,
            string email, bool isActive, string address, string cellPhone, string civilStatus)
        {
            FirstName = firstName;
            LastName = lastName;
            CPF = cpf;
            BirthDate = birthDate;
            Email = email;
            IsActive = isActive;
            Address = address;
            CellPhone = cellPhone;
            CivilStatus = civilStatus;
        }
    }
}
