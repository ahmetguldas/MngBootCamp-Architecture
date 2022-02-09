using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Rules
{
    public class CarBusinessRules
    {
        private readonly ICarRepository _carRepository;

        public CarBusinessRules(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task CarIdShouldExistWhenSelected(int id)
        {
            Car? result = await _carRepository.GetAsync(b => b.Id == id);
            if (result == null) throw new BusinessException("Car not exists.");
        }

        public async Task CarNameCanNotBeDuplicatedWhenInserted(int id)
        {
            IPaginate<Car> result = await _carRepository.GetListAsync(b => b.Id == id);
            if (result.Items.Any()) throw new BusinessException("Car name exists.");
        }
    }
}
