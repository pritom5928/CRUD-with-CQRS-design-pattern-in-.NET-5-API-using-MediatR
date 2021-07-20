using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDWithCQRSPattern.Features.Queries.GetAll
{
    public class GetAllProductQuery : IRequest<IEnumerable<GetAllProductQueryViewModel>>
    {
    }
}
