using AutoMapper;
using CarCrashChecker.Interfaces;
using CarCrashChecker.Models;
using CarCrashChecker.Entities;
using MediatR;
namespace CarCrashChecker.Features.Car.Queries
{
    public class GetCarQueryHandler : IRequestHandler<GetCarQuery, ICollection<CarVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetCarQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ICollection<CarVm>> Handle(GetCarQuery request, CancellationToken cancellationToken)
        {
            var cars =  await _unitOfWork.CarRepository.GetAllAsync();
            return _mapper.Map<ICollection<CarVm>>(cars);
        }
    }
}
