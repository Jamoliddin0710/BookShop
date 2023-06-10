using Contracts.RepositoryContract;
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
        private Lazy<IImageRepository> imageRepository;
        private Lazy<IAuthorRepository> authorRepository;
        private Lazy<IGenreRepository> genreRepository;
        private Lazy<IOrderRepository> ordererRepository;
        public RepositoryManager(RepositoryContext context)
        {
            this.context = context;
            this.publisherRepository = new Lazy<IPublisherRepository>(() => new PublisherRepository(context));
            this.bookRepository = new Lazy<IBookRepository>(() => new BookRepository(context));
            this.buyerRepository = new Lazy<IBuyerRepository>(() => new BuyerRepository(context));
            this.authorRepository = new Lazy<IAuthorRepository>(() => new AuthorRepository(context));
            this.genreRepository = new Lazy<IGenreRepository>(() => new GenreRepository(context));
            this.imageRepository = new Lazy<IImageRepository>(() => new ImageRepository(context));
            this.ordererRepository = new Lazy<IOrderRepository>(() => new OrderRepository(context));
        }

        public IBuyerRepository Buyer => buyerRepository.Value;

        public IBookRepository Book => bookRepository.Value;

        public IPublisherRepository Publisher => publisherRepository.Value;

        public IAuthorRepository Author => authorRepository.Value;

        public IGenreRepository Genre => genreRepository.Value;

        public IImageRepository Image => imageRepository.Value;

        public IOrderRepository Order => ordererRepository.Value;

        public async Task SaveAsync() => await context.SaveChangesAsync();
    }
}
