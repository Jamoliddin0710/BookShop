﻿using Entities.DTO.Book;
using Entities.DTO.Seller;
using Entities.Exceptions;
using Entities.Models;
using Entities.ModelView;
using Mapster;
using MyShop.Services.BookService.Contracts;
using Repository;

namespace MyShop.Services.BookService
{
    public class BookService : IBookService
    {
        private readonly RepositoryManager repositoryManager;
        public BookService(RepositoryManager repositoryManager)
        {
            this.repositoryManager = repositoryManager;
        }

        public async Task AddBook(CreateBookDTO bookDTO)
        {
            var book = bookDTO.Adapt<Book>();
            book.CreatedDate = DateTime.UtcNow;
            repositoryManager.Book.AddBook(book);
            await repositoryManager.SaveAsync();
        }

        public async Task DeleteBook(int bookId)
        {
            var book = await repositoryManager.Book.GetBookById(bookId, false);
            repositoryManager.Book.DeleteBook(book);
            await repositoryManager.SaveAsync();
        }

        public async Task<ICollection<BookDTO>> GetAllBooks(bool trackChanges)
        {
            var books =  repositoryManager.Book.GetAllBook(trackChanges);
            
            if(books is null)
                return new List<BookDTO>();
            return books.Adapt<ICollection<BookDTO>>();
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
            config.ForType<UpdateSellerDTO, Book>()
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
