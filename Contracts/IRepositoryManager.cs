using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryManager
    {
        IBuyerRepository Buyer {  get; }
        IBookRepository Book { get; }
        ISellerRepository Seller { get; }
        Task SaveAsync();
    }
}
