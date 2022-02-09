using System.Threading;
using System.Threading.Tasks;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Commands.UpdateBrand
{
    public class UpdateCarCommand:IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class UpdateBrandResponseHandler : IRequestHandler<UpdateCarCommand>
        {
            private IBrandRepository _brandRepository { get; }
            private IMapper _mapper { get; }

            public UpdateBrandResponseHandler(IBrandRepository brandRepository, IMapper mapper)
            {
                _brandRepository = brandRepository;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
            {
                Brand brand = _mapper.Map<Brand>(request);
                await _brandRepository.UpdateAsync(brand);
                return Unit.Value;
            }
        }
    }
}
