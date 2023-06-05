using Entities.DTO.Book;
using Entities.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.ServiceContract.BuyerServiceContract
{
    public interface IBookService
    {
        Task<BookDTO> GetBookById(int bookId, bool trackChanges);
        Task<IEnumerable<BookDTO>> GetAllBooks(BookFilterDTO bookFilter, bool trackChanges);
    }
}
