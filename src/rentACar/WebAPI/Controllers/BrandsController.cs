using System.Threading.Tasks;
using Application.Features.Brands.Commands.CreateBrand;
using Application.Features.Brands.Commands.DeleteBrand;
using Application.Features.Brands.Commands.UpdateBrand;
using Application.Features.Brands.Queries.GetBrandList;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : BaseController
    {
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateBrandCommand createBrandCommand) 
        {
            var result = await Mediator.Send(createBrandCommand);
            return Created("", result);
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest) 
        {
            var query = new GetBrandListQuery();
            query.PageRequest = pageRequest;
            var result = await Mediator.Send(query);
            return Ok(result);
        }
        
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCarCommand updateBrandCommand)
        {
            await Mediator.Send(updateBrandCommand);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteBrandCommand deleteBrandCommand)
        {
            await Mediator.Send(deleteBrandCommand);
            return Ok();
        }

    }
}
