using CRUDWithCQRSPattern.Context;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CRUDWithCQRSPattern.Features.Product_Features.Queries.GetById.GetByIdHandler
{
    public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, GetByIdQueryViewModel>
    {
        private readonly IApplicationDBContext _db;
        public GetByIdQueryHandler(IApplicationDBContext db)
        {
            _db = db;
        }

        public async Task<GetByIdQueryViewModel> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            var product = _db.Products.Where(s => s.Id == request.Id).FirstOrDefault();

            if (product == null)
                return null;
            else
            {
                var productViewModel = new GetByIdQueryViewModel
                {
                    Id = product.Id,
                    Barcode = product.Barcode,
                    BuyingPrice = product.BuyingPrice,
                    ConfidentialData = product.ConfidentialData,
                    Description = product.Description,
                    IsActive = product.IsActive,
                    Name = product.Name,
                    Rate = product.Rate
                };

                return productViewModel;
            }
        }
    }
}
