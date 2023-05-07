using Entities.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new List<User>
                { 
                    new User { Id = 1, 
                        FirstName="Admin" , 
                        Login= "Admin",
                        Password="Admin",
                        LastName = "Admin",
                        Token = "sdsdsd",
                         Role = EUserRole.Admin,} }
                );

        }
    }
}
