using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.RepositoryContract
{
    public interface IRepositoryManager
    {
        IBuyerRepository Buyer { get; }
        IBookRepository Book { get; }
        IPublisherRepository Publisher { get; }
        IGenreRepository Genre { get; }
        IAuthorRepository Author { get; }
        Task SaveAsync();
    }
}
