﻿using Contracts.RepositoryContract;
using Contracts.ServiceContract.AdminServiceContract;
using Entities.DTO.Book;
using Entities.Exceptions;
using Entities.Models;
using Entities.Models.Enums;
using Entities.ModelView;
using Mapster;
using MyShop.Helpers;


namespace MyShop.Services.AdminService
{
    public class BookService : IBookService
    {
        private readonly IRepositoryManager repositoryManager;
        public BookService(IRepositoryManager repositoryManager)
        {
            this.repositoryManager = repositoryManager;
        }

        public async Task<BookDTO> AddBook(CreateBookDTO bookDTO)
        {
            var book = bookDTO.Adapt<Book>();
            book.CreatedDate = DateTime.UtcNow;
            repositoryManager.Book.AddBook(book);
            await repositoryManager.SaveAsync();
            return book.Adapt<BookDTO>();
        }

        public async Task DeleteBook(int bookId)
        {
            var book = await repositoryManager.Book.GetBookById(bookId, false);
            repositoryManager.Book.DeleteBook(book);
            await repositoryManager.SaveAsync();
        }

        public async Task<IEnumerable<BookDTO>> GetAllBooks(BookFilterDTO filter)
        {
            var books = repositoryManager.Book.GetAllBook(true);

            if (books is null)
                return new List<BookDTO>();

            if (filter.Inscription is not null)
                books = books.Where(book => book.Inscription == filter.Inscription).AsQueryable();

            if (filter.Language is not null)
                books = books.Where(book => book.Language == filter.Language).AsQueryable();

            if (filter.authorId is not null)
                books = books.Where(book => book.authorId == filter.authorId).AsQueryable();

            if (filter.genreId is not null)
                books = books.Where(book => book.genreId == filter.authorId).AsQueryable();

            if (filter.publisherId is not null)
                books = books.Where(book => book.publisherId == filter.publisherId).AsQueryable();

            if (filter.Cover is not null)
                books = books.Where(book => book.Cover == filter.Cover).AsQueryable();

            if (filter.FromPrice is not null)
                books = books.Where(book => book.Price >= filter.FromPrice).AsQueryable();

            if (filter.ToPrice is not null)
                books = books.Where(book => book.Price <= filter.ToPrice).AsQueryable();

            if (filter.SortingStatus is not null)
                books = filter.SortingStatus switch
                {
                    EBookSotringStatus.New => books.OrderBy(book => book.CreatedDate).AsQueryable(),
                    EBookSotringStatus.Cheap => books.OrderBy(book => book.Price).AsQueryable(),
                    EBookSotringStatus.Most_Expensive => books.OrderByDescending(book => book.Price).AsQueryable(),
                };

            var sortingbooks = books.Adapt<List<BookDTO>>().ToPagedList(filter);

            return sortingbooks;
        }

        public async Task<BookDTO> GetBookById(int bookId, bool trackChanges)
        {
            var book = await repositoryManager.Book.GetBookById(bookId, trackChanges);
            if (book is null)
                throw new EntityNotFoundException<Book>();

            return book.Adapt<BookDTO>();
        }

        public async Task UpdateBook(int bookId, UpdateBookDTO bookDTO)
        {
            var book = await repositoryManager.Book.GetBookById(bookId, true);
            if (book is null)
                throw new EntityNotFoundException<Book>();

            var config = new TypeAdapterConfig();
            config.ForType<UpdateBookDTO, Book>()
                .IgnoreNullValues(true)
                .BeforeMapping((src, dest) =>
                {
                    dest.Id = book.Id;
                });
            var bookUpdate = bookDTO.Adapt(book, config);
            repositoryManager.Book.UpdateBook(bookUpdate);
            await repositoryManager.SaveAsync();
        }
    }
}
