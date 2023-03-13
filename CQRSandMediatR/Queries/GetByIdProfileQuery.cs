using CQRSandMediatR.Models;
using MediatR;

namespace CQRSandMediatR.Queries
{
    public class GetByIdProfileQuery : IRequest<ProfileModel>
    {
        public int Id { get; set; }
    }
}
