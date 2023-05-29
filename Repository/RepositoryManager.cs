﻿using Contracts.RepositoryContract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext context;
        private Lazy<IBuyerRepository> buyerRepository;
        private Lazy<IPublisherRepository> publisherRepository;
        private Lazy<IBookRepository> bookRepository;
        private Lazy<ISellerRepository> sellerRepository;
        private Lazy<IAuthorRepository> authorRepository;
        private Lazy<IGenreRepository> genreRepository;
        public RepositoryManager(RepositoryContext context)
        {
            this.context = context;
            this.publisherRepository = new Lazy<IPublisherRepository>(() => new PublisherRepository(context));
            this.sellerRepository = new Lazy<ISellerRepository>(() => new SellerRepository(context));
            this.bookRepository = new Lazy<IBookRepository>(() => new BookRepository(context));
            this.buyerRepository = new Lazy<IBuyerRepository>(() => new BuyerRepository(context));
            this.authorRepository = new Lazy<IAuthorRepository>(() => new AuthorRepository(context));
            this.genreRepository = new Lazy<IGenreRepository>(() => new GenreRepository(context));
        }

        public IBuyerRepository Buyer => buyerRepository.Value;

        public IBookRepository Book => bookRepository.Value;

        public ISellerRepository Seller => sellerRepository.Value;

        public IPublisherRepository Publisher => publisherRepository.Value;

        public IAuthorRepository Author => authorRepository.Value;

        public IGenreRepository Genre => genreRepository.Value;

        public async Task SaveAsync() => await context.SaveChangesAsync();
    }
}
