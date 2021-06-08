using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos.Response;
using API.Errors;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    public class VehicleController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public VehicleController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("get-cars-by-color")]
        public async Task<ActionResult<IReadOnlyList<CarDto>>> GetCarsByColorAsync(int colorId)
        {
            var spec = new VehicleSpecification<Car>(colorId);

            return (await _unitOfWork.Repository<Car>().ListWithSpecAsync(spec))
                .Select(_mapper.Map<CarDto>).ToList();
        }

        [HttpGet("get-buses-by-color")]
        public async Task<ActionResult<IReadOnlyList<BusDto>>> GetBusesByColorAsync(int colorId)
        {
            var spec = new VehicleSpecification<Bus>(colorId);

            return (await _unitOfWork.Repository<Bus>().ListWithSpecAsync(spec))
                .Select(_mapper.Map<BusDto>).ToList();
        }

        [HttpGet("get-boats-by-color")]
        public async Task<ActionResult<IReadOnlyList<BoatDto>>> GetBoatsByColorAsync(int colorId)
        {
            var spec = new VehicleSpecification<Boat>(colorId);

            return (await _unitOfWork.Repository<Boat>().ListWithSpecAsync(spec))
                .Select(_mapper.Map<BoatDto>).ToList();
        }

        [HttpPost("turn-headlights")]
        public async Task<ActionResult<ApiResponse>> TurnOnOfHeadlightsAsync(int carId)
        {
            var car = await _unitOfWork.Repository<Car>().GetByIdAsync(carId);

            if (car != null)
            { 
                car.HeadLights = !car.HeadLights;
                _unitOfWork.Repository<Car>().Update(car);
                await _unitOfWork.Complete();
            }
            else
            {
                return new ApiResponse(500, "Car was not found.");
            }

            return new ApiResponse(200, car.HeadLights ? "Headlights on" : "Headlights of");

        }

        [HttpDelete("delete-car")]
        public async Task<ActionResult<ApiResponse>> DeleteCarByIdAsync(int carId)
        {
            var car = await _unitOfWork.Repository<Car>().GetByIdAsync(carId);
            try
            {
                _unitOfWork.Repository<Car>().Delete(car);
                await _unitOfWork.Complete();
            }
            catch (Exception e)
            {
                return new ApiResponse(500, e.Message);
            }

            return new ApiResponse(200,"Deletion successful.");
        }

}
}
