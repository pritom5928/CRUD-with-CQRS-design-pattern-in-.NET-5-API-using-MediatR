using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDWithCQRSPattern.Features.Product_Features.Commands.Delete
{
    public class DeleteProductCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
