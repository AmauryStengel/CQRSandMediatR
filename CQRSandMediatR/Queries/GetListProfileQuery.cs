using CQRSandMediatR.Models;
using MediatR;

namespace CQRSandMediatR.Queries
{
    public class GetListProfileQuery : IRequest<List<ProfileModel>>
    {

    }
}
