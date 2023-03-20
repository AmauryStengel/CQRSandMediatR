using MediatR;

namespace CQRSandMediatR.Commands
{
    public class DeleteProfileCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
