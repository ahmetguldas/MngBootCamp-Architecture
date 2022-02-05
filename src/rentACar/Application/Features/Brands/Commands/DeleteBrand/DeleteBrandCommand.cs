using System.Threading;
using System.Threading.Tasks;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Commands.DeleteBrand
{
    public class DeleteBrandCommand:IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class DeleteBrandResponseHandler : IRequestHandler<DeleteBrandCommand>
        {
            private IBrandRepository _brandRepository;
            private IMapper _mapper;

            public DeleteBrandResponseHandler(IBrandRepository brandRepository, IMapper mapper)
            {
                _brandRepository = brandRepository;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
            {
                Brand brand = _mapper.Map<Brand>(request);
                await _brandRepository.DeleteAsync(brand);
                return Unit.Value;
            }
        }
    }
}