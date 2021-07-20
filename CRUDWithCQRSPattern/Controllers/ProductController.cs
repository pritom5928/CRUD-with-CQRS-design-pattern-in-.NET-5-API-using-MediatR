using CRUDWithCQRSPattern.Features.Queries.GetAll;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using CRUDWithCQRSPattern.Features.Product_Features.Queries.GetById;
using CRUDWithCQRSPattern.Features.Product_Features.Commands.Create;
using CRUDWithCQRSPattern.Features.Product_Features.Commands.Update;
using CRUDWithCQRSPattern.Features.Product_Features.Commands.Delete;

namespace CRUDWithCQRSPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IMediator mediator;
        protected IMediator Mediator => mediator ??= HttpContext.RequestServices.GetRequiredService<IMediator>();

        #region Read
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllProductQuery();
            var response = await Mediator.Send(query);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var query = new GetByIdQuery { Id = id };

            var response = await Mediator.Send(query);

            return Ok(response);
        }
        #endregion



        #region Write 
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductCommand command)
        {
            var reponse = await Mediator.Send(command);

            return Ok(reponse);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateProductCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            else
            {
                var reponse = await Mediator.Send(command);
                return Ok(reponse);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var query = new DeleteProductCommand{ Id = id };

            var response = await Mediator.Send(query);

            return Ok(response);
        }
        #endregion
    }
}
