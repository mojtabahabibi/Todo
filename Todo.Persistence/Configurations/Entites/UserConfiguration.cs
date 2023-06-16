using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using Todo.Domain.Entites;

namespace Todo.Persistence.Configurations.Entites
{
    public class UserConfiguration : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.HasData(new Users { Id = 1, FirstName = "Mojtaba", LastName = "Habbibi", BirthDate = DateTime.Today, RegisterDate = DateTime.Now });
        }
    }
}
