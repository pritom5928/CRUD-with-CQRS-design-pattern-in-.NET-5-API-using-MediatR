using CRUDWithCQRSPattern.Context;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CRUDWithCQRSPattern.Features.Product_Features.Commands.Update.Update_Handler
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, int>
    {
        private readonly IApplicationDBContext _db;
        public UpdateProductCommandHandler(IApplicationDBContext db)
        {
            _db = db;
        }

        public async Task<int> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            if (command != null)
            {
                var getProduct = _db.Products.Find(command.Id);
                if (getProduct != null)
                {
                    getProduct.Name = command.Name;
                    getProduct.BuyingPrice = command.BuyingPrice;
                    getProduct.ConfidentialData = command.ConfidentialData;
                    getProduct.Description = command.Description;
                    getProduct.IsActive = command.IsActive;
                    getProduct.Barcode = command.Barcode;
                    getProduct.Rate = command.Rate;

                     _db.Products.Update(getProduct);
                    await _db.SaveChangesAsync();

                    return getProduct.Id;
                }
                else
                    return 0;
            }
            else
            {
                return 0;
            }
        }
    }
}
