namespace CQRSandMediatR.Models
{
    public class ProfileModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CPF { get; set; }
        public string BirthDate { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public string Address { get; set; }
        public string CellPhone { get; set; }
        public string CivilStatus { get; set; }
    }
}
