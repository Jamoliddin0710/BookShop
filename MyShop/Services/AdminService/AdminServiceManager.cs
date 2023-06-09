﻿using Entities;
using MyShop.Services.AdminService.Contracts;
using MyShop.Services.BuyerService;
using MyShop.Services.BuyerService.Contracts;
using Contracts.RepositoryContract;
using Contracts.ServiceContract.AdminServiceContract;
using Microsoft.AspNetCore.Mvc;

namespace MyShop.Services.AdminService
{
    public class AdminServiceManager : IAdminServiceManager
    {
        private readonly Lazy<IBuyerService> buyerService;
        private readonly Lazy<IAuthorService> authorService;
        private readonly Lazy<IGenreService> genreService;
        private readonly Lazy<IPublisherService> publisherService;
        private readonly Lazy<IImageService> imageService;
        private readonly Lazy<IBookService> bookService;

        public AdminServiceManager(IRepositoryManager repositoryManager, [FromServices] IWebHostEnvironment webHostEnvironment)
        {
            this.authorService = new Lazy<IAuthorService>(() => new AuthorService(repositoryManager));
            this.genreService = new Lazy<IGenreService>(() => new GenreService(repositoryManager));
            this.publisherService = new Lazy<IPublisherService>(() => new PublisherService(repositoryManager));
            this.buyerService = new Lazy<IBuyerService>(() => new MyShop.Services.BuyerService.BuyerService(repositoryManager));
            this.bookService = new Lazy<IBookService>(() => new BookService(repositoryManager));
            this.imageService = new Lazy<IImageService>(() => new ImageService(repositoryManager));
        }
        public IPublisherService Publisher => publisherService.Value;

        public IAuthorService Author => authorService.Value;

        public IGenreService Genre => genreService.Value;

        public IBuyerService Buyer => buyerService.Value;

        public IBookService Book => bookService.Value;

        public IImageService BookImage => imageService.Value;
    }
}
