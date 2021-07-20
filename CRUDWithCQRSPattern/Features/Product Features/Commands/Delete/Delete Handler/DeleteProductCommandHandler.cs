using CRUDWithCQRSPattern.Context;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CRUDWithCQRSPattern.Features.Product_Features.Commands.Delete.Delete_Handler
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, int>
    {
        private readonly IApplicationDBContext _db;
        public DeleteProductCommandHandler(IApplicationDBContext db)
        {
            _db = db;
        }

        public async Task<int> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {
            if (command != null)
            {
                var product = _db.Products.Find(command.Id);

                _db.Products.Remove(product);
                await _db.SaveChangesAsync();

                return product.Id;
            }
            else
                return 0;
        }
    }
}
