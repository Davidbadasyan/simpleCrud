namespace simpleCrud.Infrastructure.EntityConfigurations.Clients;

public class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.ToTable("Client");

        builder.HasKey(b => b.Id);
        builder.Ignore(b => b.DomainEvents);

        builder.Property(b => b.Id)
            .HasColumnName("IdClient");

        builder
            .Property(o => o.Code)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("Code")
            .HasMaxLength(50);

        builder
            .Property(o => o.Name)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("Name")
            .HasMaxLength(500);

        builder
            .Property(o => o.EntityType)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("EntityType")
            .HasMaxLength(50);

        builder
            .Property(o => o.DateInception)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("DateInception");

        builder
            .Property(o => o.DateTermination)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("DateTermination");

        builder
            .Property(o => o.TerminationReason)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("TerminationReason")
            .HasMaxLength(500);

        builder
            .Property(o => o.Email)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("Email")
            .HasMaxLength(500);

        builder
            .Property(o => o.Phone)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("Phone")
            .HasMaxLength(50);

        builder
            .Property(o => o.IdTeam)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("IdTeam")
            .IsRequired();

        builder.OwnsOne(
            o => o.Address,
            a =>
            {
                a.Property(o => o.Address1)
                    .UsePropertyAccessMode(PropertyAccessMode.Field)
                    .HasColumnName("Address1")
                    .HasMaxLength(500);

                a.Property(o => o.Address2)
                    .UsePropertyAccessMode(PropertyAccessMode.Field)
                    .HasColumnName("Address2")
                    .HasMaxLength(500);

                a.Property(o => o.City)
                    .UsePropertyAccessMode(PropertyAccessMode.Field)
                    .HasColumnName("City")
                    .HasMaxLength(500);

                a.Property(o => o.State)
                    .UsePropertyAccessMode(PropertyAccessMode.Field)
                    .HasColumnName("State")
                    .HasMaxLength(500);

                a.Property(o => o.ZipCode)
                    .UsePropertyAccessMode(PropertyAccessMode.Field)
                    .HasColumnName("Zip")
                    .HasMaxLength(500);

                a.WithOwner();
            });

        builder.Property(b => b.CreatedBy)
            .HasColumnName("CreatedBy")
            .HasMaxLength(500);

        builder.Property(b => b.CreatedDate)
            .HasColumnName("DateCreated")
            .ValueGeneratedOnAdd()
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(b => b.ModifiedBy)
            .HasColumnName("ModifiedBy")
            .HasMaxLength(500);

        builder.Property(b => b.ModifiedDate)
            .HasColumnName("DateModified")
            .HasDefaultValueSql("GETUTCDATE()");
    }
}

