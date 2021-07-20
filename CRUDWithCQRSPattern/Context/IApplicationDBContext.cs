using CRUDWithCQRSPattern.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CRUDWithCQRSPattern.Context
{
    public interface IApplicationDBContext
    {
        DbSet<Product> Products { get; set; }

        Task<int> SaveChangesAsync();
    }
}