using CRUDWithCQRSPattern.Context;
using CRUDWithCQRSPattern.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CRUDWithCQRSPattern.Features.Product_Features.Commands.Create.Create_Handler
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IApplicationDBContext _db;
        public CreateProductCommandHandler(IApplicationDBContext db)
        {
            _db = db;
        }

        public async Task<int> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            if (command != null)
            {
                var newProduct = new Product
                {
                    Name = command.Name,
                    BuyingPrice = command.BuyingPrice,
                    ConfidentialData = command.ConfidentialData,
                    Description = command.Description,
                    IsActive = command.IsActive,
                    Barcode = command.Barcode,
                    Rate = command.Rate
                };

                await _db.Products.AddAsync(newProduct);
                await _db.SaveChangesAsync();

                return newProduct.Id;
            }
            else
                return 0;

        }
    }
}
