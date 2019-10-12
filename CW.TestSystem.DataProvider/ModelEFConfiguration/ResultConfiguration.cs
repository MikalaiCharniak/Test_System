using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CW.TestSystem.Model.CoreEntities;

namespace CW.TestSystem.DataProvider.ModelEFConfiguration
{
    public class ResultConfiguration : IEntityTypeConfiguration<Result>
    {
        public void Configure(EntityTypeBuilder<Result> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasOne(x => x.Test).
                WithMany(x => x.Results).
                HasForeignKey(x => x.TestId);

            builder.HasOne(x => x.User).
                WithMany(x => x.Results).
                HasForeignKey(x => x.UserId);
        }
    }
}
