using Entities.Models;
using Entities.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<Buyer>
    {
        public void Configure(EntityTypeBuilder<Buyer> builder)
        {
            builder.HasData(
                new List<Buyer>
                {
                    new Buyer { Id = Guid.NewGuid(),
                        FirstName="Admin" ,
                        PhoneNumber= "12345678",
                        Password="Admin",
                        LastName = "Admin",
                        Role = EUserRole.Admin,
                        BuyerSigninStatus = EBuyerSigninStatus.Inprogress,
                        BuyerGender = EGender.Male,
                         } }
                );

        }
    }
}
