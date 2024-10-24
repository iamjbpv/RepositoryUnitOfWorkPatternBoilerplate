using CarCrashChecker.Entities;
using CarCrashChecker.Features.Car.Queries;
using CarCrashChecker.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarCrashChecker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;

        public CarController(IUnitOfWork unitOfWork, IMediator mediator)
        {
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var cars = await _mediator.Send(new GetCarQuery());
            return Ok(cars);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var car = await _unitOfWork.CarRepository.GetByIdAsync(id);
            if (car == null)
                return NotFound();
            return Ok(car);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Car car)
        {
            await _unitOfWork.CarRepository.AddAsync(car);
            await _unitOfWork.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = car.Id }, car);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Car car)
        {
            if (id != car.Id)
                return BadRequest();

            _unitOfWork.CarRepository.Update(car);
            await _unitOfWork.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var car = await _unitOfWork.CarRepository.GetByIdAsync(id);
            if (car == null)
                return NotFound();

            _unitOfWork.CarRepository.Delete(car);
            await _unitOfWork.SaveChangesAsync();
            return NoContent();
        }
    }

}
