using Application.Features.Brands.Rules;
using Application.Services.Repositories;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Queries.GetBrandById
{
    public class GetBrandByIdQuery : IRequest<Brand>
    {
        public int Id { get; set; }
        public class GetBrandByIdHandler : IRequestHandler<GetBrandByIdQuery, Brand>
        {
            IBrandRepository _brandRepository;
            BrandBusinessRules _brandBusinessRules;

            public GetBrandByIdHandler(IBrandRepository brandRepository, BrandBusinessRules brandBusinessRules)
            {
                _brandRepository = brandRepository;
                _brandBusinessRules = brandBusinessRules;
            }

            public async Task<Brand> Handle(GetBrandByIdQuery request, CancellationToken cancellationToken)
            {
                await _brandBusinessRules.BrandIdShouldExistWhenSelected(request.Id);
                Brand? brand = await _brandRepository.GetAsync(b => b.Id == request.Id);
                return brand;
            }
        }
    }
}
