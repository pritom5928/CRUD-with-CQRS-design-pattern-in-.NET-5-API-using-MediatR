using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDWithCQRSPattern.Features.Product_Features.Queries.GetById
{
    public class GetByIdQuery : IRequest<GetByIdQueryViewModel>
    {
        public int Id { get; set; }
    }
}
