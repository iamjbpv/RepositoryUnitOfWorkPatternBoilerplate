using CarCrashChecker.Models;
using MediatR;

namespace CarCrashChecker.Features.Car.Queries
{
    public class GetCarQuery : IRequest<ICollection<CarVm>>
    {

    }
}
