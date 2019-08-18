using LNLOrder.Write.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LNLOrder.Persistance.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {

            builder.OwnsOne(b => b.Email, a =>
            {
                a.Property(p => p.EmailAdress).HasColumnName("Email");
            });
        }
    }
}
