using CRUDWithCQRSPattern.Context;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CRUDWithCQRSPattern.Features.Queries.GetAll.GetAllHandler
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, IEnumerable<GetAllProductQueryViewModel>>
    {
        private readonly IApplicationDBContext _db;
        public GetAllProductQueryHandler(IApplicationDBContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<GetAllProductQueryViewModel>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            var products = _db.Products.Select(s => new GetAllProductQueryViewModel
            {
                Id = s.Id,
                Name = s.Name,
                Barcode = s.Barcode,
                ConfidentialData = s.ConfidentialData,
                BuyingPrice = s.BuyingPrice,
                Description = s.Description,
                IsActive = s.IsActive,
                Rate = s.Rate
            }).ToList();

            return products;
        }
    }
}
